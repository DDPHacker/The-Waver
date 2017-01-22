using UnityEngine;

public class Shot : MonoBehaviour {
    private bool hit;
    public float shotRange;

    public AudioClip[] _laserClashClips;
    public AudioSource _shotAudioSource;

    public void Initialize(Vector3 velocity){
        GetComponent<Rigidbody> ().velocity = velocity;
        hit = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "blade" && !hit) {
            int index = Random.Range(0, _laserClashClips.Length);
            _shotAudioSource.clip = _laserClashClips[index];
            _shotAudioSource.Play();

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

            enemyDirection += new Vector3 (
                Random.Range(-shotRange, shotRange), Random.Range(-shotRange, shotRange), Random.Range(-shotRange, shotRange));

            Vector3 newVelocity = enemyDirection * Vector3.Magnitude(GetComponent<Rigidbody> ().velocity);
            GetComponent<Rigidbody> ().velocity = newVelocity;
            GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(newVelocity);
            hit = true;
        }

        if (other.gameObject.tag == "Enemy" && hit) {
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
