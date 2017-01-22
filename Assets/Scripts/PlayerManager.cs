using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject BladePrefab;
<<<<<<< HEAD
	public GameObject BladePrefab_2;
=======
    public float bladeLength;
>>>>>>> dc5451adce169634495beb25cd0e248bb751c752

    private GameObject blade1;
	private GameObject blade2;

    public static PlayerManager _instance;

    public static PlayerManager Instance {
        get { return _instance; }
    }

    // Awake
    void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    void Start() {
        blade1 = Instantiate (BladePrefab);
        blade1.GetComponent<Blade> ().Initialize (0, bladeLength, 0.2f);
		blade2 = Instantiate (BladePrefab_2);
		blade2.GetComponent<Blade> ().Initialize (1, bladeLength, 0.2f);
    }

    void Update() {

    }

}
