using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniqueScoreContainer : MonoBehaviour
{
    public GameObject rankObject;
    public GameObject nameObject;
    public GameObject scoreObject;

    public void SetupScoreLine(string rank, string name, string score) {
        rankObject.GetComponent<Text>().text = rank;
        nameObject.GetComponent<Text>().text = name;
        scoreObject.GetComponent<Text>().text = score;
    }
}
