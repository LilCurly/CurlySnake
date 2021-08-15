using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetryButton : MyButton
{
    override public void OnSubmit(BaseEventData baseEventData) {
        GameManager.instance.Retry();
    }
}
