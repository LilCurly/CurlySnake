using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public Score(string playerName, string playerScore) {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }

    public string playerName;
    public string playerScore;
}
