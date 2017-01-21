using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	enum GAME_STATE {
		GAME_STATE_READY,
		GAME_STATE_SHOW_SWORD,
		GAME_STATE_PLAY,
		GAME_STATE_DIE,
	};

	public int gameState;
	public AudioManager audioManager;
	public PlayerManager playerManager;
	public EnemyManager enemyManager;
	public ViveControllerInput viveControllerInput;

	void Awake() {
		// Awake
		gameState = (int)GAME_STATE.GAME_STATE_READY;
	}

	// Use this for initialization
	void Start() {
		audioManager = new AudioManager();
		playerManager = new PlayerManager();
		enemyManager = new EnemyManager();
	}
	
	// Update is called once per frame
	void Update() {

	}

}
