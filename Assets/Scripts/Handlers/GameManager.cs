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

    [HideInInspector]
    public BoardManager boardManager;

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
        InitGame();
        gameState = GameState.InPlay;
    }

    protected void InitGame() {
        boardManager.SetupScene();
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

    public void SnakePartDidMove(Position from, Position to) {
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
