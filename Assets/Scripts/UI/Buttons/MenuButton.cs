using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MyButton
{
    public override void Awake()
    {
        GameOverHandler.instance.mainMenuButton = gameObject;
        base.Awake();
    }

    public override void PlayerDidSubmit()
    {
        SceneHandler.instance.LoadMainMenuScene();
    }
}
