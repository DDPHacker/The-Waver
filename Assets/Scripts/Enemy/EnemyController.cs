using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject shot;
    public float speed;
    public float randomScale;

    //void Start () {
    //    Vector3 playerPos = new Vector3 (0, 0, 0);
    //    StartCoroutine (Shoot (playerPos));
    //}

    public void Initialize (Vector3 playerPos) {
        StartShoot (playerPos);
    }

    public void StartShoot (Vector3 playerPos) {
        StartCoroutine (Shoot (playerPos));
    }

    IEnumerator Shoot (Vector3 playerPos) {
        Vector3 relativePos;
        Quaternion shotRotation;
        GameObject newShot;
        Vector3 randomPos;

        yield return new WaitForSeconds (1);
        while (true) {
            randomPos = playerPos + new Vector3(
                Random.Range(-randomScale, randomScale),
                Random.Range(-2*randomScale, 0),
                Random.Range(-randomScale, randomScale));
            relativePos = randomPos - transform.position;
            shotRotation = Quaternion.LookRotation (relativePos);
            newShot = Instantiate (shot, transform.position, shotRotation,
                GameObject.FindGameObjectWithTag("Shots").GetComponent<Transform>());
            newShot.GetComponent<Shot> ().Initialize (-(newShot.transform.position - randomPos).normalized * speed);
          yield return new WaitForSeconds (2);
        }
    }
}
