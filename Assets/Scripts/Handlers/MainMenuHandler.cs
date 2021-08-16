using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : BaseUiHandler
{
    public override void Awake()
    {
        if (instance == null) instance = this;
        ObjectsHandler.instance.mainMenuHandler = gameObject;
        Time.timeScale = 1;
    }
}
