using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    Vector3 lastRecordedMovementAxis = new Vector3(1, 0, 0);
    Vector3 currentIllegalMovement = new Vector3(-1, 0, 0);
    Vector3 lastPosition = new Vector3(0, 0, 0);

    [HideInInspector]
    SnakeBody nextBodyPart;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeMovement", 0, GameManager.instance.speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == GameManager.GameState.InPlay) {
            int horizontalMovement = 0;
            int verticalMovement = 0;

            if (lastRecordedMovementAxis.x == 0) horizontalMovement = (int) Input.GetAxisRaw("Horizontal");
            else verticalMovement = (int) Input.GetAxisRaw("Vertical");

            if ((horizontalMovement != 0 || verticalMovement != 0) && 
            (horizontalMovement != currentIllegalMovement.x || verticalMovement != currentIllegalMovement.y)) {
                lastRecordedMovementAxis.x = horizontalMovement;
                lastRecordedMovementAxis.y = verticalMovement;
            }   
        }
    }

    protected void MakeMovement() {
        Vector3 nextPosition = transform.position + lastRecordedMovementAxis;

        if (nextPosition.x > GameManager.instance.boardManager.maxPos) {
            nextPosition.x = (nextPosition.x - 1) * -1;
        } else if (nextPosition.x < GameManager.instance.boardManager.minPos) {
            nextPosition.x = (nextPosition.x + 1) * -1;
        } else if (nextPosition.y > GameManager.instance.boardManager.maxPos) {
            nextPosition.y = (nextPosition.y - 1) * -1;
        } else if (nextPosition.y < GameManager.instance.boardManager.minPos) {
            nextPosition.y = (nextPosition.y + 1) * -1;
        }

        lastPosition = transform.position;
        transform.position = nextPosition;
        currentIllegalMovement = lastRecordedMovementAxis * -1;

        GameManager.instance.SnakePartDidMove(new Position(lastPosition), new Position(transform.position));

        if (nextBodyPart != null) {
            nextBodyPart.MoveTo(lastPosition);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<Apple>() != null) {
            if (nextBodyPart == null) {
                nextBodyPart = Instantiate(ObjectsHandler.instance.snakeBody, lastPosition, Quaternion.identity, GameManager.instance.transform).GetComponent<SnakeBody>();
            } else {
                nextBodyPart.GrowSnake();
            }
            GameManager.instance.DidEatApple();
        } else if (collider.gameObject.GetComponent<SnakeBody>() != null) {
            GameManager.instance.GameOver();
        }
    }
}
