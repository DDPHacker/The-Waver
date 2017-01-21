using UnityEngine;

public class AudioManager : MonoBehaviour {

    private GameManager _gameManager;

    // Awake
    void Awake() {

    }

    // Use this for initialization
    void Start() {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {

    }

}
