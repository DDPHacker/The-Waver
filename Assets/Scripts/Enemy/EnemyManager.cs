using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public int enemyCounter;
    public float enemyTime;
    private int enemyNum;
    private Vector3 playerPos;
    private IEnumerator spawn;
    private List<Vector3> enemiesPos = new List<Vector3> ();

    public static EnemyManager _instance;

    public static EnemyManager Instance {
        get { return _instance; }
    }

    // Awake
    void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        enemyNum = 0;
        Random.InitState (System.DateTime.UtcNow.Millisecond);
    }

    void Update () {
        playerPos = ViveManager.Instance.GetHeadPosition ();
    }

    public void StartSpawn (Vector2 inside, Vector2 outside, Vector2 floor) {
        spawn = Spawn (inside, outside, floor);
        StartCoroutine(spawn);
    }

    IEnumerator Spawn(Vector2 inside, Vector2 outside, Vector2 floor) {
        Vector3 enemyPos;
        Vector3 relativePos;
		GameObject newEnemy;
        Quaternion enemyRotation;
        int signX;
        int signZ;

        yield return new WaitForSeconds (1 + 2 * Random.value);

        while (true) {
            if (enemyNum >= enemyCounter) {
                yield return new WaitForSeconds (enemyTime + 2 * Random.value);
                continue;
            }

            if (Random.value > 0.5) signX = -1;
            else signX = 1;
            if (Random.value > 0.5) signZ = -1;
            else signZ = 1;

            enemyPos = new Vector3  (
                signX*(Random.value*(outside.x-inside.x) + inside.x),
                Random.value * (floor.y - floor.x) + floor.x,
                signZ*(Random.value*(outside.y-inside.y) + inside.y));

            relativePos = playerPos - enemyPos;
            enemyRotation = Quaternion.LookRotation (relativePos);

            newEnemy = Instantiate(enemy, enemyPos, enemyRotation,
                GameObject.FindGameObjectWithTag("Enemies").GetComponent<Transform>());
            newEnemy.GetComponent<EnemyController> ().Initialize (playerPos);
            enemiesPos.Add (enemyPos);
            enemyNum++;

            yield return new WaitForSeconds (enemyTime + 2 * Random.value);
        }
    }

    public Vector3 FindEnemyDirection (Vector3 position, Vector3 direction1, Vector3 direction2) {
        Vector3 enemyDirection;
        List<Vector3> enemyDirections = new List<Vector3>();
        foreach(Vector3 enemyPos in enemiesPos) {
            enemyDirection = enemyPos - position;
            if (Vector3.Dot (enemyDirection, direction1) >= 0 &&
               Vector3.Dot (enemyDirection, direction2) >= 0) {
                if (Vector3.Dot (Vector3.Cross (enemyDirection, direction1), Vector3.Cross (enemyDirection, direction2)) <= 0)
                    enemyDirections.Add (enemyDirection);
            }
        }
        if (enemyDirections.Count > 0)
            return enemyDirections[(int)(Random.value * (enemyDirections.Count - 0.000001))].normalized;
        Vector3 ranPosition = Random.value * direction1 + Random.value * direction2
            + (Random.value * 2 - 1) * Vector3.Cross (direction1, direction2).normalized;
        return ranPosition.normalized;
	}

    void DestroyEnemies () {
        Transform enemies = GameObject.FindGameObjectWithTag ("Enemies").GetComponent<Transform> ();
        foreach (Transform child in enemies) {
            Destroy (child.gameObject);
            enemyNum--;
        }
    }

    void StopSpawn () {
        StopCoroutine (spawn);
        DestroyEnemies ();
    }

    public void DestroyEnemy() {
        enemyNum--;
    }
}
