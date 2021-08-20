using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public static GameOverHandler instance;

    [HideInInspector]
    public string currentPlayerName;

    [HideInInspector]
    public GameObject userNameEditText;
    [HideInInspector]
    public GameObject saveButton;
    [HideInInspector]
    public GameObject retryButton;
    [HideInInspector]
    public GameObject mainMenuButton;

    void Awake() {
        if (instance == null) instance = this;
        gameObject.SetActive(false);
    }

    public void StartScene() {
        gameObject.SetActive(true);
        SetEditState();
    }

    public void SavePlayerScore() {
        Score playerScore = new Score(currentPlayerName, GameManager.instance.score.ToString());
        SaveHandler.SaveScore(playerScore);
        SetMenuState();
    }

    public void SetMenuState() {
        userNameEditText.SetActive(false);
        saveButton.SetActive(false);
        retryButton.SetActive(true);
        mainMenuButton.SetActive(true);

        retryButton.GetComponent<Button>().Select();
    }

    public void SetEditState() {
        retryButton.SetActive(false);
        mainMenuButton.SetActive(false);
    }
}
