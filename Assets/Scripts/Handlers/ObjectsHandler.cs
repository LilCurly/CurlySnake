using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHandler : MonoBehaviour
{
    public static ObjectsHandler instance;

    public GameObject background;
    public GameObject snakeHead;
    public GameObject apple;
    public GameObject snakeBody;

    void Awake() {
        if (instance == null) instance = this;
    }
}
