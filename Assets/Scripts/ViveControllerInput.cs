using UnityEngine;

public class ViveControllerInput : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller {
        get {
            return (int)trackedObj.index == -1 ? null: SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    // Awake
    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start() {

    }

    public bool ControllerAccessiable() {
        return Controller != null;
    }

    public Vector2 GetViveAxis() {
        return ControllerAccessiable() ? Controller.GetAxis() : new Vector2(0, 0);
    }

    public bool GetViveTrigger() {
        return ControllerAccessiable() && Controller.GetHairTrigger();
    }

    public bool GetViveTriggerDown() {
        return ControllerAccessiable() && Controller.GetHairTriggerDown();
    }

    public bool GetViveTriggerUp() {
        return ControllerAccessiable() && Controller.GetHairTriggerUp();
    }

    public bool GetViveGrip() {
        return ControllerAccessiable() && Controller.GetPress(SteamVR_Controller.ButtonMask.Grip);
    }

    public bool GetViveGripDown() {
        return ControllerAccessiable() && Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip);
    }

    public bool GetViveGripUp() {
        return ControllerAccessiable() && Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip);
    }

}
