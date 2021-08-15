using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;

    void Awake() {
        if (instance == null) instance = this;
        DontDestroyOnLoad(this);
        LoadInGameScenes();
    }

    public void LoadInGameScenes() {
        SceneManager.LoadSceneAsync("SampleScene");
        SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
    }
}
