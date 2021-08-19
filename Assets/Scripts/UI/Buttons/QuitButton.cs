using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitButton : MyButton
{
    public override void PlayerDidSubmit()
    {
        Application.Quit();
    }
}
