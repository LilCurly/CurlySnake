using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLabelScore : MonoBehaviour
{

    void Awake() {
        GetComponent<Text>().text = $"You ate {GameManager.instance.score} apples!";
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
