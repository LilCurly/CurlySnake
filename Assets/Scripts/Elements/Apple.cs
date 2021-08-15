using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<SnakeHead>() != null) {
            Destroy(gameObject);
        }
    }
}
