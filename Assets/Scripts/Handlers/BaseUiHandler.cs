using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseUiHandler: MonoBehaviour
{
    public static BaseUiHandler instance;

    [HideInInspector]
    public GameObject selectedButton;

    abstract public void Awake();
}
