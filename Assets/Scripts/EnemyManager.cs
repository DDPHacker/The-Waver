using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    private GameManager _gameManager;
	public GameObject enemy;
	private IEnumerator spawn;
	private static int enemyNum;
	private static int enemyCounter = 7;

    // Awake
    void Awake() {

    }

    // Use this for initialization
    void Start () {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

		enemyNum = 0;
		Random.InitState ((int)(Time.time*100));

		//Vector3 playerPos = new Vector3 (0, 0, 0);
		//Vector2 inside = new Vector2 (3, 3);
		//Vector2 outside = new Vector2 (7, 7);
		//Vector2 floor = new Vector2 (0, 3);
		//StartSpawn (playerPos, inside, outside, floor);
    }

	void StartSpawn (Vector3 playerPos, Vector2 inside, Vector2 outside, Vector2 floor) {
		spawn = Spawn (playerPos, inside, outside, floor);
		StartCoroutine(spawn);
	}

	IEnumerator Spawn(Vector3 playerPos, Vector2 inside, Vector2 outside, Vector2 floor) {
		Vector3 enemyPos;
		Vector3 relativePos;
		int signX;
		int signZ;
		float height;

		yield return new WaitForSeconds (3 + 2 * Random.value);

		while (true) {
		//while (enemyNum < enemyCounter) {
			if (enemyNum >= enemyCounter) {
				yield return new WaitForSeconds (2 + 2 * Random.value);
				continue;
			}

			if (Random.value > 0.5) signX = -1;
			else signX = 1;
			if (Random.value > 0.5) signZ = -1;
			else signZ = 1;

			if (Random.value > 0.7) { //secondfloor
				height = floor.y;
				if (Random.value > 0.5) {
					enemyPos = new Vector3 (
						signX * outside.x,
						height,
						signZ * (Random.value * (outside.y - inside.y) + inside.y));
				} else {
					enemyPos = new Vector3	(
						signX*(Random.value*(outside.x-inside.x) + inside.x),
						height,
						signZ*outside.y);
				}
			} else {
				height = floor.x;
				enemyPos = new Vector3	(
					signX*(Random.value*(outside.x-inside.x) + inside.x),
					height,
					signZ*(Random.value*(outside.y-inside.y) + inside.y));
			}

			relativePos = playerPos - enemyPos;
			relativePos.y = 0;
			Quaternion enemyRotation = Quaternion.LookRotation (relativePos);

			Instantiate(enemy, enemyPos, enemyRotation,
				GameObject.FindGameObjectWithTag("Enemies").GetComponent<Transform>());
			enemyNum++;

			yield return new WaitForSeconds (2 + 2 * Random.value);
		}

		//yield return new WaitForSeconds (3);
		//DestroyEnemies ();
	}

	void DestroyEnemies () {
		Transform enemies = GameObject.FindGameObjectWithTag ("Enemies").GetComponent<Transform> ();
		foreach (Transform child in enemies) {
			Destroy (child.gameObject);
		}
	}

	void StopSpawn () {
		StopCoroutine (spawn);
		DestroyEnemies ();
	}
}
