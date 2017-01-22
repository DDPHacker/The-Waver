using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager _instance;

    public static EnemyManager Instance {
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

    }

    // Update is called once per frame
    void Update() {

    }

}
