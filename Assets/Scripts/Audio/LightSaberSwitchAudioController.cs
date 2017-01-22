using UnityEngine;

public class LightSaberSwitchAudioController : MonoBehaviour {

    public AudioClip _lightSaberClip;
    public AudioClip _lightSaberOnClip;
    public AudioClip _lightSaberOffClip;
    public AudioSource _lightSaberAudioSource;
    private bool _lightSaberSwitch;

    void Start() {
        _lightSaberSwitch = false;
    }

    public void SetLightSaberVolume(float volume) {
        if (!_lightSaberAudioSource.isPlaying)
            PlayLightSaberSound();
        _lightSaberAudioSource.volume = Mathf.Clamp(volume, 0.0f, 1.0f);
    }

    public bool ShouldPlayLightSaberSound() {
        return !_lightSaberAudioSource.isPlaying || _lightSaberAudioSource.clip == _lightSaberClip;
    }

    public void PlaySwitchLightSaberSound() {
        if (_lightSaberSwitch) {
            PlayLightSaberSwitchOff();
        } else {
            PlayLightSaberSwitchOn();
        }
        _lightSaberSwitch = !_lightSaberSwitch;
    }

    public void PlayLightSaberSound() {
        _lightSaberAudioSource.clip = _lightSaberClip;
        _lightSaberAudioSource.loop = true;
        _lightSaberAudioSource.Play();
    }

    void PlayLightSaberSwitchOn() {
        _lightSaberAudioSource.Stop();
        _lightSaberAudioSource.clip = _lightSaberOnClip;
        _lightSaberAudioSource.loop = false;
        _lightSaberAudioSource.volume = 1.0f;
        _lightSaberAudioSource.Play();
    }

    void PlayLightSaberSwitchOff() {
        _lightSaberAudioSource.Stop();
        _lightSaberAudioSource.clip = _lightSaberOffClip;
        _lightSaberAudioSource.loop = false;
        _lightSaberAudioSource.volume = 1.0f;
        _lightSaberAudioSource.Play();
    }

}
