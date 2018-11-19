﻿using UnityEngine;
using UnityEngine.UI;

public class EndSceneUIController : MonoBehaviour
{
    [SerializeField]
    private Text m_TextBestResult;

    [SerializeField]
    private Text m_TextCurrentResult;

    void Awake()
    {
        if(GlobalData.Score > GlobalData.MaxScore)
        {
            GlobalData.MaxScore = GlobalData.Score;
        }

        m_TextBestResult.text = "Best result: " + GlobalData.MaxScore.ToString();
        m_TextCurrentResult.text = "Current result: " + GlobalData.Score.ToString();
    }

    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardUI();
    }

    public void Restart()
    {
        //Reset all data
        GlobalData.Score = 0;
        GlobalData.Lives = 3;
        GlobalData.Acceleration = 1f;
        GlobalData.ItemsOnSkewer.Clear();

        //Load main scene
        LevelChanger.FadeToLevel(0);
    }
}
