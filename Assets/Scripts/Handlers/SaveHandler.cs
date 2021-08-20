using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveHandler
{
    public static void SaveScore(Score toSave) {
        string fullFilePath = GetScorePath();
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        ScoreContainer scores = LoadScore();

        if (scores == null) {
            scores = new ScoreContainer();
        }

        scores.scores.Add(toSave);

        using (FileStream fileStream = new FileStream(fullFilePath, FileMode.Create)) {
            binaryFormatter.Serialize(fileStream, scores);
        }
    }

    public static ScoreContainer LoadScore() {
        string fullFilePath = GetScorePath();

        if (File.Exists(fullFilePath)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            ScoreContainer scores = null;

            using (FileStream fileStream = new FileStream(fullFilePath, FileMode.Open)) {
                if (fileStream.Length > 0) {
                    scores = (ScoreContainer) binaryFormatter.Deserialize(fileStream);
                }
            }

            return scores;
        }
        return null;
    }

    private static string GetScorePath() {
        return Application.persistentDataPath + "/" + "scores.bin";
    }
}
