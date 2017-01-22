using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip _readyBGMClip;
    public AudioClip _playBGMClip;
    public AudioClip _dieBGMClip;
    public AudioSource _audioSource;

    public static AudioManager _instance;

    public static AudioManager Instance {
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

    // Used to play single sound clips.
    public void PlaySingle(AudioClip clip) {

    }

}
