using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public void Initialize(Vector3 velocity){
        GetComponent<Rigidbody> ().velocity = velocity;
        GetComponent<Rigidbody> ().detectCollisions = false;
    }

}
