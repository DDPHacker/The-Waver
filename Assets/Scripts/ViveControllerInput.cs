﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ViveControllerInput : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	public Vector2 GetViveAxis() {
		return Controller.GetAxis();
	}

	public bool GetViveTrigger() {
		return Controller.GetHairTrigger();
	}

	public bool GetViveTriggerDown() {
		return Controller.GetHairTriggerDown();
	}
 
	public bool GetViveTriggerUp() {
		return Controller.GetHairTriggerUp();
	}

	public bool GetViveGrip() {
		return Controller.GetPress(SteamVR_Controller.ButtonMask.Grip);
	}

	public bool GetViveGripDown() {
		return Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip);
	}

	public bool GetViveGripUp() {
		return Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip);
	}

}
