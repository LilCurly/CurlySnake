using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSceneHandler : MonoBehaviour
{
    public static ScoreSceneHandler instance;

    public GameObject uniqueScoreLine;
    public GameObject scoresContainer;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        ScoreContainer scores = SaveHandler.LoadScore();
        
        scores.scores.Sort((x, y) => {
            return (Int32.Parse(y.playerScore)).CompareTo(Int32.Parse(x.playerScore));
        });

        for (int i = 0; i < scores.scores.Count; i++) {
            Score currentScore = scores.scores[i];

            scoresContainer.GetComponent<ScrollViewContainer>().AddItem((i + 1).ToString(), currentScore.playerName, currentScore.playerScore);
        }
    }
}
