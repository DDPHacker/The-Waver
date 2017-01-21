using UnityEngine;

public class ViveControllerManager : MonoBehaviour {

    public ViveControllerInput[] _viveControllers;

    // Use this for initialization
    void Start() {

    }

    public Vector3 GetPosition(int index) {
        return _viveControllers[index].GetVivePosition();
    }

    public Vector3 GetOrientation(int index) {
        return _viveControllers[index].GetViveOrientation();
    }

    public Vector2 GetAxis(int index) {
        return _viveControllers[index].GetViveAxis();
    }

    public bool GetTrigger(int index = -1) {
        if (index == -1) {
            foreach (ViveControllerInput _viveController in _viveControllers) {
                if (_viveController.GetViveTrigger()) {
                    return true;
                }
            }
            return false;
        }
        return _viveControllers[index].GetViveTrigger();
    }

    public bool GetTriggerDown(int index = -1) {
        if (index == -1) {
            foreach (ViveControllerInput _viveController in _viveControllers) {
                if (_viveController.GetViveTriggerDown()) {
                    return true;
                }
            }
            return false;
        }
        return _viveControllers[index].GetViveTriggerDown();
    }

    public bool GetTriggerUp(int index = -1) {
        if (index == -1) {
            foreach (ViveControllerInput _viveController in _viveControllers) {
                if (_viveController.GetViveTriggerUp()) {
                    return true;
                }
            }
            return false;
        }
        return _viveControllers[index].GetViveTriggerUp();
    }

    public bool GetGrip(int index = -1) {
        if (index == -1) {
            foreach (ViveControllerInput _viveController in _viveControllers) {
                if (_viveController.GetViveGrip()) {
                    return true;
                }
            }
            return false;
        }
        return _viveControllers[index].GetViveGrip();
    }

    public bool GetGripDown(int index = -1) {
        if (index == -1) {
            foreach (ViveControllerInput _viveController in _viveControllers) {
                if (_viveController.GetViveGripDown()) {
                    return true;
                }
            }
            return false;
        }
        return _viveControllers[index].GetViveGripDown();
    }

    public bool GetGripUp(int index = -1) {
        if (index == -1) {
            foreach (ViveControllerInput _viveController in _viveControllers) {
                if (_viveController.GetViveGripUp()) {
                    return true;
                }
            }
            return false;
        }
        return _viveControllers[index].GetViveGripUp();
    }

}
