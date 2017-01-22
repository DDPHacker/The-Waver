using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject BladePrefab;
    public GameObject BladePrefab_2;
    public float bladeLength;

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
        blade1 = Instantiate(BladePrefab);
        blade1.GetComponent<Blade>().Initialize(0, bladeLength, 0.2f, new Color(1f, 0.7f, 0.7f));
        blade2 = Instantiate (BladePrefab_2);
        blade2.GetComponent<Blade>().Initialize(1, bladeLength, 0.2f, new Color(0.7f, 0.7f, 1f));
    }

    void Update() {

    }

}
