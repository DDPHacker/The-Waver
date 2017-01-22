using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameObject BladePrefab;
	public GameObject BladePrefab_2;

    private GameManager _gameManager;
    private GameObject blade1;
	private GameObject blade2;

    public float bladeLength;

    void Awake() {

    }

    void Start() {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        blade1 = Instantiate (BladePrefab);
        blade1.GetComponent<Blade> ().Initialize (0, bladeLength, 0.2f);
		blade2 = Instantiate (BladePrefab_2);
		blade2.GetComponent<Blade> ().Initialize (1, bladeLength, 0.2f);
    }

    void Update() {

    }

}
