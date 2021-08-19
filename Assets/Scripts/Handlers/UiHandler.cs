using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public static UiHandler instance;

    [HideInInspector]
    public GameObject selectedButton;

    void Awake() {
        if (instance == null) instance = this;
    }
}
