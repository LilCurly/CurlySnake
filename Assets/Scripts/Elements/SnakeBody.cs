using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{

    Vector3 lastPosition;

    public Sprite _snakeBodyRight;
    public Sprite _snakeBodyLeft;

    [HideInInspector]
    SnakeBody nextBodyPart;

    public void MoveTo(Vector3 position) {
        lastPosition = transform.position;
        transform.position = position;

        GetComponent<SpriteRenderer>().sprite = GetNextBodySprite();

        GameManager.instance.SnakePartDidMove(new Position(lastPosition), new Position(transform.position));

        if (nextBodyPart != null) {
            nextBodyPart.MoveTo(lastPosition);
        }
    }

    public void GrowSnake() {
        if (nextBodyPart == null) {
            nextBodyPart = Instantiate(ObjectsHandler.instance.snakeBody, lastPosition, Quaternion.identity, GameManager.instance.transform).GetComponent<SnakeBody>();
            nextBodyPart.GetComponent<SpriteRenderer>().sprite = GetNextBodySprite();
        } else {
            nextBodyPart.GrowSnake();
        }
    }

    private Sprite GetNextBodySprite() {
        if (GetComponent<SpriteRenderer>().sprite == _snakeBodyRight) {
            return _snakeBodyLeft;
        } else {
            return _snakeBodyRight;
        }
    }
}
