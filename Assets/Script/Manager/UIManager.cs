using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Image fader;
    private PauseManager pauseManager;

    protected override void Awake()
    {
        base.Awake();
        if (fader != null)
        {
            fader.gameObject.SetActive(false);
        }
    }
    public virtual void FadeOn(bool state, float duration)
    {
        fader.gameObject.SetActive(true);
        if (state)
        {
            StartCoroutine(FadeInOut.FadeImage(fader, duration, new Color(0f, 0f, 0f, 1f)));
        }
        else
        {
            StartCoroutine(FadeInOut.FadeImage(fader, duration, new Color(0f, 0f, 0f, 0f)));
        }
    }
}
