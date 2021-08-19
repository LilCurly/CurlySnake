using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{

    public static PauseHandler instance;

    void Awake() {
        if (instance == null) instance = this;
        HideScene();
    }

    public void StartScene() {
        gameObject.SetActive(true);
    }

    public void HideScene() {
        gameObject.SetActive(false);
    }
}
