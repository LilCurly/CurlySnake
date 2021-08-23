using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MyButton
{
    public override void PlayerDidSubmit()
    {
        SceneHandler.instance.LoadMainMenuScene();
    }
}
