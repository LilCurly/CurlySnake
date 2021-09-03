using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    public enum SnakeOrientation {
        Horizontal,
        Vertical
    }

    Vector3 lastRecordedMovementAxis = new Vector3(1, 0, 0);
    Vector3 currentIllegalMovement = new Vector3(-1, 0, 0);
    Vector3 lastPosition = new Vector3(0, 0, 0);

    public Sprite _snakeTop;
    public Sprite _snakeBottom;
    public Sprite _snakeLeft;
    public Sprite _snakeRight;

    SnakeBody nextBodyPart;

    SnakeOrientation currentHeadOrientation;

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

        SpriteRenderer spriteRender = GetComponent<SpriteRenderer>();
        bool orientationDidChange = false;
        if (lastRecordedMovementAxis == Vector3.up) {
            orientationDidChange = UpdateSnakeOrientation(SnakeOrientation.Vertical);
            spriteRender.sprite = _snakeTop;
        } else if (lastRecordedMovementAxis == Vector3.down) {
            orientationDidChange = UpdateSnakeOrientation(SnakeOrientation.Vertical);
            spriteRender.sprite = _snakeBottom;
        } else if (lastRecordedMovementAxis == Vector3.left) {
            orientationDidChange = UpdateSnakeOrientation(SnakeOrientation.Horizontal);
            spriteRender.sprite = _snakeLeft;
        } else if (lastRecordedMovementAxis == Vector3.right) {
            orientationDidChange = UpdateSnakeOrientation(SnakeOrientation.Horizontal);
            spriteRender.sprite = _snakeRight;
        }

        if (nextBodyPart != null) {
            nextBodyPart.MoveTo(lastPosition, transform.position, orientationDidChange);
        }
    }

    public bool UpdateSnakeOrientation(SnakeOrientation currentSnakeOrientation) {
        bool orientationDidChange = false;
        if (currentSnakeOrientation != this.currentHeadOrientation) {
            orientationDidChange = true;
            this.currentHeadOrientation = currentSnakeOrientation;
        }

        return orientationDidChange;
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
