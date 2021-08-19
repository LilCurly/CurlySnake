using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NameInputField : BaseInputField
{
    public override void Awake()
    {
        base.Awake();
        mInputField.onValueChanged.AddListener(playerName => GameOverHandler.instance.currentPlayerName = playerName);
    }
    
    void Update() {
        if (Input.GetKeyUp(KeyCode.Return) && isSelected) {
            GameOverHandler.instance.SavePlayerScore();
        }
    }
}
