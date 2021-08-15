using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public static GameOverHandler instance;

    [HideInInspector]
    public GameObject selectedButton;

    void Awake() {
        if (instance == null) instance = this;
        ObjectsHandler.instance.gameOverHandler = gameObject;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
