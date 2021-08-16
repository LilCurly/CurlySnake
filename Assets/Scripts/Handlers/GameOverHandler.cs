using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : BaseUiHandler
{
    override public void Awake() {
        if (instance == null) instance = this;
        ObjectsHandler.instance.gameOverHandler = gameObject;
        gameObject.SetActive(false);
    }
}
