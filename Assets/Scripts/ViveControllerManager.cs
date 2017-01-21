using UnityEngine;

public class ViveControllerManager : MonoBehaviour {

    public ViveControllerInput[] _viveControllers;

    // Use this for initialization
    void Start() {

    }

    public Vector2 GetAxis(int index) {
        return _viveControllers[index].GetViveAxis();
    }

    public bool GetTrigger(int index) {
        return _viveControllers[index].GetViveTrigger();
    }

    public bool GetTriggerDown(int index) {
        return _viveControllers[index].GetViveTriggerDown();
    }

    public bool GetTriggerUp(int index) {
        return _viveControllers[index].GetViveTriggerUp();
    }

    public bool GetGrip(int index) {
        return _viveControllers[index].GetViveGrip();
    }

    public bool GetGripDown(int index) {
        return _viveControllers[index].GetViveGripDown();
    }

    public bool GetGripUp(int index) {
        return _viveControllers[index].GetViveGripUp();
    }

}
