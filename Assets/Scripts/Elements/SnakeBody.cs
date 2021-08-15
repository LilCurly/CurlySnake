using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{

    Vector3 lastPosition;

    [HideInInspector]
    SnakeBody nextBodyPart;

    public void MoveTo(Vector3 position) {
        lastPosition = transform.position;
        transform.position = position;

        GameManager.instance.SnakePartDidMove(lastPosition, transform.position);

        if (nextBodyPart != null) {
            nextBodyPart.MoveTo(lastPosition);
        }
    }

    public void GrowSnake() {
        if (nextBodyPart == null) {
            nextBodyPart = Instantiate(ObjectsHandler.instance.snakeBody, lastPosition, Quaternion.identity, GameManager.instance.transform).GetComponent<SnakeBody>();
        } else {
            nextBodyPart.GrowSnake();
        }
    }
}
