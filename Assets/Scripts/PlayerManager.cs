using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject BladePrefab;
    public float bladeLength;

    private GameObject blade1;

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
    }

    void Update() {

    }

}
