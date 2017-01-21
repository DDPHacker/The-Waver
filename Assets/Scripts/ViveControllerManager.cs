using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Security.Cryptography.X509Certificates;

public class ViveControllerManager : MonoBehaviour {

	public ViveControllerInput[] viveControllers;

	public Vector2 GetAxis(int index) {
		return viveControllers[index].GetViveAxis();
	}

	public bool GetTrigger(int index) {
		return viveControllers[index].GetViveTrigger();
	}

	public bool GetTriggerDown(int index) {
		return viveControllers[index].GetViveTriggerDown();
	}

	public bool GetTriggerUp(int index) {
		return viveControllers[index].GetViveTriggerUp();
	}

	public bool GetGrip(int index) {
		return viveControllers[index].GetViveGrip();
	}

	public bool GetGripDown(int index) {
		return viveControllers[index].GetViveGripDown();	
	}

	public bool GetGripUp(int index) {
		return viveControllers[index].GetViveGripUp();
	}

}
