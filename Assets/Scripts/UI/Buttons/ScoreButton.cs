using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreButton : MyButton
{
    public override void PlayerDidSubmit()
    {
        Debug.Log("Score button");
    }
}
