using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    Dictionary<Vector3, bool> gridPositions;

    public void SetupScene() {
        CreateGrid();
        
        Vector3 baseSnakePosition = new Vector3(0, 0, 0);
        GameObject snakeHead = Instantiate(ObjectsHandler.instance.snakeHead, baseSnakePosition, Quaternion.identity, transform);
        GameManager.instance.AddSnakePart(snakeHead);

        gridPositions[baseSnakePosition] = true;

        SpawnApple();
    }

    public void CreateGrid() {
        gridPositions = new Dictionary<Vector3, bool>();

        for (int i = GameManager.instance.minPos; i <= GameManager.instance.maxPos; i++) {
            for (int j = GameManager.instance.minPos; j <= GameManager.instance.maxPos; j++) {
                gridPositions.Add(new Vector3(i, j, 0), false);
            }
        }
    }

    public void UpdateGrid(Vector3 from, Vector3 to) {
        gridPositions[from] = false;
        gridPositions[to] = true;
    }

    public void SpawnApple() {
        List<Vector3> validPositions = gridPositions.Where(element => element.Value == false).Select(element => element.Key).ToList<Vector3>();
        Vector3 applePosition = validPositions[UnityEngine.Random.Range(0, validPositions.Count - 1)];
        Instantiate(ObjectsHandler.instance.apple, applePosition, Quaternion.identity, transform);
    }
}
