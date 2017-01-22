using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    private bool hit;

    public void Initialize(Vector3 velocity){
        GetComponent<Rigidbody> ().velocity = velocity;
        hit = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "blade" && !hit) {
            GameObject blade = other.gameObject;
            Vector3[] vertices = blade.GetComponent<MeshFilter> ().mesh.vertices;
            Vector3 mid1 = (vertices [1] + vertices [0]) / 2;
            Vector3 mid2 = (vertices [2] + vertices [0]) / 2;
            Vector3 swipeDirection = (mid2 - mid1).normalized;

            Vector3 side1 = vertices [1] - vertices [0];
            Vector3 side2 = vertices [2] - vertices [0];
            Vector3 prep = Vector3.Cross (side1, side2).normalized;
            if (Vector3.Dot (GetComponent<Rigidbody> ().velocity, prep) > 0)
                prep = -prep;
            Vector3 enemyDirection = EnemyManager.Instance.FindEnemyDirection (transform.position, prep, swipeDirection);

            Vector3 newVelocity = enemyDirection * Vector3.Magnitude(GetComponent<Rigidbody> ().velocity);
            GetComponent<Rigidbody> ().velocity = newVelocity;
            GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(newVelocity);
            hit = true;
        }

        if (other.gameObject.tag == "enemy" && hit) {
            Destroy (this.gameObject);
            Destroy (other.gameObject);
        }
    }

    void Update () {
        if (Vector3.Magnitude (transform.position) > 50) {
            Destroy (this.gameObject);
        }
    }
}
