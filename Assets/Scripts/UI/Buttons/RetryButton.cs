using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetryButton : MyButton<GameOverHandler>
{
    public override void Awake()
    {
        base.SetUiHandler(ObjectsHandler.instance.gameOverHandler.GetComponent<GameOverHandler>());
        base.Awake();
    }

    override public void OnSubmit(BaseEventData baseEventData) {
        GameManager.instance.Retry();
    }
}
