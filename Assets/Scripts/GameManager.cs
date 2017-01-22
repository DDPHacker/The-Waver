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
    }

    public void MoveToNextGameState() {
        _gameState = (_gameState + 1) % GAME_STATE.GAME_STATE_SIZE;
        InitGameState(_gameState);
    }

    public void InitGameState(int gameState) {
        switch (gameState) {
            case GAME_STATE.GAME_STATE_READY:
                // AudioManager.PlayAudio("READY_BGM");
                // PlayerManager.InitPlayer();
                break;
            case GAME_STATE.GAME_STATE_PLAY:
                // AudioManager.PlayAudio("PLAY_BGM");
                // EnemyManager.StartSpwan();
                break;
            case GAME_STATE.GAME_STATE_DIE:
                // AudioManager.PlayAudio("PLAY_DIE");
                // EnemyManager.StopSpwan();
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
                if (ViveControllerManager.Instance.GetTrigger()) {
                    // PlayerManager.ShowSword();
                    Debug.Log("Show sword!!!!!!!!!");
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
