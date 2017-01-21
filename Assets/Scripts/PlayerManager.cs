using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private GameManager _gameManager;

    void Awake() {

    }

    void Start() {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update() {
        
    }

}
