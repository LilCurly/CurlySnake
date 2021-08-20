using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreContainer
{
    public ScoreContainer() {
        scores = new List<Score>();
    }

    public List<Score> scores;
}
