using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInputFieldContainer : MonoBehaviour
{
    void Awake() {
        GameOverHandler.instance.userNameEditText = gameObject;
    }
}
