using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    // Previous position recorded
    Vector3 lastPosition;

    // Horizontal/Vertical body parts
    public Sprite _snakeBodyRight;
    public Sprite _snakeBodyLeft;
    public Sprite _snakeBodyTop;
    public Sprite _snakeBodyBottom;

    // Corner body parts
    public Sprite _cornerTopRightSprite;
    public Sprite _cornerTopLeftSprite;
    public Sprite _cornerBottomLeftSprite;
    public Sprite _cornerBottomRightSprite;

    SnakeBody nextBodyPart;

    bool orientationHasChanged = false;    

    public void MoveTo(Vector3 position, Vector3 previousBodyPosition, bool orientationDidChange) {
        lastPosition = transform.position;
        transform.position = position;

        GameManager.instance.SnakePartDidMove(new Position(lastPosition), new Position(transform.position));

        GetComponent<SpriteRenderer>().sprite = GetNextBodySprite(orientationDidChange, previousBodyPosition);

        if (nextBodyPart != null) {
            nextBodyPart.MoveTo(lastPosition, position, orientationHasChanged);
        }

        if (orientationDidChange) {
            orientationHasChanged = true;
        } else if (orientationHasChanged == true && orientationDidChange == false) {
            orientationHasChanged = false;
        }
    }

    public void GrowSnake() {
        if (nextBodyPart == null) {
            nextBodyPart = Instantiate(ObjectsHandler.instance.snakeBody, lastPosition, Quaternion.identity, GameManager.instance.transform).GetComponent<SnakeBody>();
            //TODO: replace to use tail sprite
            nextBodyPart.GetComponent<SpriteRenderer>().sprite = GetNextBodySprite(false, new Vector3(0, 0, 0));
        } else {
            nextBodyPart.GrowSnake();
        }
    }

    private Sprite GetNextBodySprite(bool orientationDidChange, Vector3 previousBodyPosition) {
        Vector3 originDirection = GetOriginDirection();
        bool isHorizontal = IsHorizontal(originDirection);

        if (orientationDidChange) {
            Vector3 destinationDirection = GetDestinationDirection(previousBodyPosition);
            if (originDirection == Vector3.left) {
                if (destinationDirection == Vector3.up) {
                    return _cornerTopLeftSprite;
                } else {
                    return _cornerBottomLeftSprite;
                }
            } else if (originDirection == Vector3.right) {
                if (destinationDirection == Vector3.up) {
                    return _cornerTopRightSprite;
                } else {
                    return _cornerBottomRightSprite;
                }
            } else if (originDirection == Vector3.up) {
                if (destinationDirection == Vector3.left) {
                    return _cornerTopLeftSprite;
                } else {
                    return _cornerTopRightSprite;
                }
            } else {
                if (destinationDirection == Vector3.left) {
                    return _cornerBottomLeftSprite;
                } else {
                    return _cornerBottomRightSprite;
                }
            }
        } else if (orientationHasChanged) {
            if (!isHorizontal) {
                return _snakeBodyRight;
            } else {
                return _snakeBodyBottom;
            }
        }

        Sprite currentBodySprite = GetComponent<SpriteRenderer>().sprite;
        if (isHorizontal) {
            if (currentBodySprite == _snakeBodyBottom) {
                return _snakeBodyTop;
            } else {
                return _snakeBodyBottom;
            }
        } else {
            if (currentBodySprite == _snakeBodyRight) {
                return _snakeBodyLeft;
            } else {
                return _snakeBodyRight;
            }
        }
    }

    private bool IsHorizontal(Vector3 direction) {
        return direction == Vector3.left || direction == Vector3.right;
    }

    private Vector3 GetOriginDirection() {
        return lastPosition - transform.position;
    }

    private Vector3 GetDestinationDirection(Vector3 previousBodyPosition) {
        return  previousBodyPosition - transform.position;
    }
}
