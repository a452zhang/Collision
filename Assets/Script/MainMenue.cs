using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenue : MonoBehaviour
{
    [SerializeField]
    private string loadSceneName;
    [SerializeField]
    private CanvasGroup mainMenuGroup;
    [SerializeField]
    private CanvasGroup optionGroup;
    [SerializeField]
    private CanvasGroup creditGroup;

    private Stack<CanvasGroup> canvasGroupStack = new Stack<CanvasGroup>();
    private List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();

    private void Start()
    {
        UIManager.Instance.FadeOn(false, 1f);
        canvasGroupList.Add(mainMenuGroup);
        canvasGroupList.Add(optionGroup);
        canvasGroupList.Add(creditGroup);

        canvasGroupStack.Push(mainMenuGroup);
        Displaymenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
    }

    public void Esc()
    {
        if (canvasGroupStack.Count <= 1)
        {
            canvasGroupStack.Pop();
            Displaymenu();
        }
    }

    public void StartButton()
    {
        UIManager.Instance.FadeOn(true, 1f);
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
    }
}
