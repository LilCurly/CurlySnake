using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int _boardSize = 10;

    public GameObject _floor;
    public Sprite[] _floorSprites;

    [HideInInspector]
    public Dictionary<Position, bool> positions;

    [HideInInspector]
    public int minPos;
    [HideInInspector]
    public int maxPos;

    public void SetupScene() {
        CreateGrid();

        Vector3 baseSnakePosition = new Vector3(0, 0, 0);
        GameObject snakeHead = Instantiate(ObjectsHandler.instance.snakeHead, baseSnakePosition, Quaternion.identity, transform);
        GameManager.instance.AddSnakePart(snakeHead);

        positions[new Position(baseSnakePosition)] = true;

        SpawnApple();
    }

    public void CreateGrid() {
        if (_boardSize % 2 == 0) {
            _boardSize += 1;
        }

        if (Screen.orientation == ScreenOrientation.Landscape) {
            // I want the board to be based on screen height
            Camera.main.orthographicSize = _boardSize / 2;
        } else {
            // I want the board to be based on screen width
            float aspectRatio = Screen.width / Screen.height;
            Camera.main.orthographicSize = (_boardSize / aspectRatio) / 2;
        }

        maxPos = ((_boardSize - 1) / 2);
        minPos = -maxPos;

        positions = new Dictionary<Position, bool>();

        for (int row = minPos; row <= maxPos; row++) {
            for (int col = minPos; col <= maxPos; col++) {
                GameObject instantiatedFloor = Instantiate(_floor, new Vector3(row, col, 0), Quaternion.identity, transform);
                instantiatedFloor.GetComponent<SpriteRenderer>().sprite = _floorSprites[Random.Range(0, _floorSprites.Length)];

                positions.Add(new Position(row, col), false);
            }
        }
    }

    public void UpdateGrid(Position from, Position to) {
        positions[from] = false;
        positions[to] = true;
    }

    public void SpawnApple() {
        List<Position> validPositions = positions.Where(element => element.Value == false).Select(element => element.Key).ToList<Position>();
        Position applePosition = validPositions[Random.Range(0, validPositions.Count)];
        Instantiate(ObjectsHandler.instance.apple, applePosition.position, Quaternion.identity, transform);
    }
}
