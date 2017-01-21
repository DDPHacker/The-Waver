using UnityEngine;

public class GameManager : MonoBehaviour {

    enum GAME_STATE {
        GAME_STATE_READY,
        GAME_STATE_SHOW_SWORD,
        GAME_STATE_PLAY,
        GAME_STATE_DIE,
    };

    private int gameState;
    private AudioManager _audioManager;
    private PlayerManager _playerManager;
    private EnemyManager _enemyManager;
    private ViveControllerManager _viveControllerManager;

    // Awake
    void Awake() {
        gameState = (int)GAME_STATE.GAME_STATE_READY;
    }

    // Use this for initialization
    void Start() {
        _audioManager = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioManager>();
        _playerManager = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerManager>();
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyManager>();
        _viveControllerManager = GameObject.FindGameObjectWithTag("ViveController").GetComponent<ViveControllerManager>();
    }

    // Update is called once per frame
    void Update() {

    }

}
