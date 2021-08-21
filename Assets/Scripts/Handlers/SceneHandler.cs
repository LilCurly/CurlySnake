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
        LoadMainMenuScene();
    }

    public void LoadInGameScenes() {
        SceneManager.LoadSceneAsync("SampleScene");
        SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
    }

    public void LoadMainMenuScene() {
        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void LoadScoresScene() {
        /*Debug.Log("Loading scores scene...");
        ScoreContainer scores = SaveHandler.LoadScore();
        if (scores == null) {
            Debug.Log("No scores file found");
        } else {
            if (scores.scores.Count == 0) {
                Debug.Log("Scores file is empty");
            } else {
                scores.scores.ForEach(score => {
                    Debug.Log($"{score.playerName} : {score.playerScore}");
                });
            }
        }
        Debug.Log("Scores scene loaded!");*/
        SceneManager.LoadSceneAsync("ScoresScene");
    }
}
