using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveButton : MyButton
{
    public override void Awake()
    {
        GameOverHandler.instance.saveButton = gameObject;
        base.Awake();
    }

    public override void PlayerDidSubmit()
    {
        GameOverHandler.instance.SavePlayerScore();
    }
}
