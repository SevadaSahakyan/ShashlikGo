﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private static Animator m_Animator;

    private static int m_LevelToLoad;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public static void FadeToLevel(int levelIndex)
    {
        m_LevelToLoad = levelIndex;
        m_Animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        StartCoroutine(LoadAsynchrounously(m_LevelToLoad));
    }

    IEnumerator LoadAsynchrounously(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        if(sceneIndex == 1 && GlobalData.Score > 0) //if end scene loading
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventPostScore, "score", GlobalData.Score);
        }

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}