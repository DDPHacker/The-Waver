using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameObject BladePrefab;

    private GameManager _gameManager;
    private GameObject blade1;

    void Awake() {

    }

    void Start() {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        blade1 = Instantiate (BladePrefab);
        blade1.GetComponent<Blade> ().Initialize (0, 1, 0.3f);
    }

    void Update() {

    }

}
