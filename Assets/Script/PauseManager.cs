using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
    [SerializeField]
    private AudioMixerSnapshot paused,unpaused;
    [SerializeField]
    private CanvasGroup pauseGroup;
    [SerializeField]
    private CanvasGroup settingGroup;

    private bool isPaused = true;

    private Stack<CanvasGroup> canvasGroupStack = new Stack<CanvasGroup>();
    private List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();

    private void Start()
    {
        Pause();
        Displaymenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
    }
    private void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }
    public void Pause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseGroup.alpha = isPaused ? 1 : 0;
        pauseGroup.interactable = isPaused ? true : false;
        Lowpass();
    }
    public void Setting()
    {
        canvasGroupStack.Push(settingGroup);
        //pauseGroup.alpha = 0;
        //pauseGroup.interactable = false;
        //pauseGroup.blocksRaycasts = false;
        Displaymenu();    
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
    private void Esc()
    {
        if (!isPaused && canvasGroupStack.Count == 0)
        {
            Pause();
            canvasGroupStack.Push(pauseGroup);
        }
        else
        {
            if (canvasGroupStack.Count > 0)
                canvasGroupStack.Pop();
        }
        if (canvasGroupStack.Count == 0)
        {
            Pause();
        }
        Displaymenu();
    }
    private void Displaymenu()
    {
        foreach (var item in canvasGroupList)
        {
            item.alpha = 0;
            item.interactable = false;
            item.blocksRaycasts = false;
        }
        if (canvasGroupStack.Count > 0)
        {
            CanvasGroup cg = canvasGroupStack.Peek();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
        Time.timeScale = isPaused ? 0 : 1;
        Lowpass();
    }
}
