using UnityEngine;

public class GameManager : MonoBehaviour {

    public static class GAME_STATE {
        public const int GAME_STATE_READY = 0;
        public const int GAME_STATE_PLAY = 1;
        public const int GAME_STATE_DIE = 2;
        public const int GAME_STATE_SIZE = 3;
    }

    [HideInInspector]

    public int _gameState;

    public static GameManager _instance;

    public static GameManager Instance {
        get { return _instance; }
    }

    // Awake
    void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start() {
        SetGameState(GAME_STATE.GAME_STATE_READY);
    }

    public void SetGameState(int newGameSate) {
        _gameState = newGameSate;
        InitGameState(_gameState);
    }

    public void MoveToNextGameState() {
        SetGameState((_gameState + 1) % GAME_STATE.GAME_STATE_SIZE);
    }

    public void InitGameState(int gameState) {
        switch (gameState) {
            case GAME_STATE.GAME_STATE_READY:
                // AudioManager.Instance.PlayAudio("READY_BGM");
                // PlayerManager.InitPlayer();
                break;
            case GAME_STATE.GAME_STATE_PLAY:
                // AudioManager.Instance.PlayAudio("PLAY_BGM");
                // EnemyManager.Instance.SpawnEnemy();
                break;
            case GAME_STATE.GAME_STATE_DIE:
                // AudioManager.Instance.PlayAudio("PLAY_DIE");
                // EnemyManager.Instance.StopSpwan();
                break;
            default:
                Debug.LogError("Wrong Game State!");
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        switch (_gameState) {
            case GAME_STATE.GAME_STATE_READY:
                if (ViveManager.Instance.GetTrigger()) {
                    MoveToNextGameState();
                }
                break;
            case GAME_STATE.GAME_STATE_PLAY:
                break;
            case GAME_STATE.GAME_STATE_DIE:
                break;
            default:
                Debug.LogError("Wrong Game State!");
                break;
        }
    }

}
