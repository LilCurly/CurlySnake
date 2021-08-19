using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewGameButton : MyButton
{
    public override void PlayerDidSubmit()
    {
        SceneHandler.instance.LoadInGameScenes();
    }
}
