using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour {
    public float startTime;

    private Vector2[] UV = new Vector2[] {new Vector2 (0, 0), new Vector2 (0, 1), new Vector2 (1, 1)};
    private int[] triangles = new int[]{0, 1, 2};
    private float blockStayTime;

    void Start() {
        startTime = Time.time;
    }

    public void Initialize(Vector3[] vertices, float blockStayTime){
        this.blockStayTime = blockStayTime;
        transform.position = new Vector3 (0, 0, 0);
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = UV;
        mesh.triangles = triangles;
    }

    void Update(){
        if (Time.time - startTime > blockStayTime) {
            Destroy (this.gameObject);
            return;
        }
        Color color = this.gameObject.GetComponent<MeshRenderer> ().material.color;
        color.a = (Time.time - startTime) / blockStayTime;
        color.g = color.b = 0.7f;
        this.gameObject.GetComponent<MeshRenderer> ().material.color = color;
    }
}
