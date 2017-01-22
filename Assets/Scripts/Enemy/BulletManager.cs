using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	// Use this for initialization
	LineRenderer lineRend;
	public Transform startPos;
	public Transform endPos;

	void Start () {
		lineRend = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		lineRend.SetPosition (0, startPos.position);
		lineRend.SetPosition (1, endPos.position);
	}
}
