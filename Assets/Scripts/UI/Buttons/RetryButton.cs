using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetryButton : MyButton
{
    public override void Awake()
    {
        GameOverHandler.instance.retryButton = gameObject;
        base.Awake();
    }
    
    public override void PlayerDidSubmit()
    {
        GameManager.instance.Retry();
    }
}
