using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameState {
        InPlay,
        Pause,
        GameOver
    }

    public static GameManager instance;

    public int _boardSize = 10;

    public GameObject _floor;
    public Sprite[] _floorSprites;

    [HideInInspector]
    public List<Position> positions;

    [HideInInspector]
    public BoardManager boardManager;

    [HideInInspector]
    public int minPos;
    [HideInInspector]
    public int maxPos;

    [HideInInspector]
    public List<GameObject> snake;

    [HideInInspector]
    public int score = 0;

    [HideInInspector]
    private Text scoreLabel;

    [HideInInspector]
    public GameState gameState;

    public float speed = 0.1f;

    void Awake()
    {
        if (instance == null) instance = this;
        Time.timeScale = 1;
        boardManager = GetComponent<BoardManager>();
        scoreLabel = GameObject.Find("MyCanvas/ScoreValue").GetComponent<Text>();
        InstantiateBoardVariables();
        InitGame();
        gameState = GameState.InPlay;
    }

    protected void InitGame() {
        boardManager.SetupScene();
    }

    protected void InstantiateBoardVariables() {
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

        positions = new List<Position>();

        for (int row = minPos; row <= maxPos; row++) {
            for (int col = minPos; col <= maxPos; col++) {
                GameObject instantiatedFloor = Instantiate(_floor, new Vector3(row, col, 0), Quaternion.identity, transform);
                instantiatedFloor.GetComponent<SpriteRenderer>().sprite = _floorSprites[Random.Range(0, _floorSprites.Length)];

                positions.Add(new Position(row, col));
            }
        }
    }

    public void AddSnakePart(GameObject snakePart) {
        if (snake == null) snake = new List<GameObject>();
        this.snake.Add(snakePart);
        List<Vector3> positions = snake.Select(test => test.transform.position).ToList<Vector3>();
    }

    public void DidEatApple() {
        score += 1;
        scoreLabel.text = score.ToString();
        boardManager.SpawnApple();
    }

    public void SnakePartDidMove(Vector3 from, Vector3 to) {
        boardManager.UpdateGrid(from, to);
    }

    protected void PauseGame() {
        Time.timeScale = 0;
        gameState = GameState.Pause;
        PauseHandler.instance.StartScene();
    }

    protected void ResumeGame() {
        Time.timeScale = 1;
        gameState = GameState.InPlay;
        PauseHandler.instance.HideScene();
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameState = GameState.GameOver;
        GameOverHandler.instance.StartScene();
    }

    public void Retry() {
        Time.timeScale = 1;
        SceneHandler.instance.LoadInGameScenes();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (gameState == GameState.InPlay) {
                PauseGame();
            } else if (gameState == GameState.Pause) {
                ResumeGame();
            }
        }
    }
}
