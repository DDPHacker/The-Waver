using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public void Initialize(Vector3 velocity){
		GetComponent<Rigidbody> ().velocity = velocity;
		GetComponent<Rigidbody> ().detectCollisions = false;
	}

}
