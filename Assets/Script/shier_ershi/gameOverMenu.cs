using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverMenu : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup gameOverGroup;
    private LevelDirector director;

    private void Start()
    {
        director = LevelDirector.Instance;
        //director.GameOverAction += DisplayText;
        gameOverGroup.alpha = 0;
        gameOverGroup.interactable = false;
        gameOverGroup.blocksRaycasts = false;
    }

    public void DisplayText()
    {
        gameOverGroup.alpha = 1;
        gameOverGroup.interactable = true;
        gameOverGroup.blocksRaycasts = true;
    }
}
