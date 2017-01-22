using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	public float speed = 1f;

	void Start () {
		Vector3 playerPos = new Vector3 (0, 0, 0);
		StartCoroutine (Shoot (playerPos));
	}

	IEnumerator Shoot (Vector3 playerPos) {
		Vector3 relativePos;
		Quaternion shotRotation;
		GameObject newShot;
		Vector3 velocity;

		yield return new WaitForSeconds (1);
		//while (true) {
			relativePos = playerPos - transform.position;
			shotRotation = Quaternion.LookRotation (relativePos);
			newShot = Instantiate (shot, transform.position, shotRotation,
				GameObject.FindGameObjectWithTag("Shots").GetComponent<Transform>());
		newShot.GetComponent<Shot> ().Initialize ((-newShot.transform.position).normalized);
		//	yield return new WaitForSeconds (2);
		//}
	}
}
