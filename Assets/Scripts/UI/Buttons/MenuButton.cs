using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MyButton
{
    public override void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("Did tap return to main menu");
    }
}
