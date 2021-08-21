using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewContainer : MonoBehaviour
{
    public void AddItem(string rank, string name, string score) {
        GameObject addedItem = Instantiate(ScoreSceneHandler.instance.uniqueScoreLine, transform);

        addedItem.GetComponent<UniqueScoreContainer>().SetupScoreLine(rank, name, score);

        RectTransform rt = (RectTransform) addedItem.transform;

        ((RectTransform) gameObject.transform).sizeDelta += new Vector2(0, rt.rect.height);
    }
}
