using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MyButton<GameOverHandler>
{
    public override void Awake()
    {
        base.SetUiHandler(ObjectsHandler.instance.gameOverHandler.GetComponent<GameOverHandler>());
        base.Awake();
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        SceneHandler.instance.LoadMainMenuScene();
    }
}
