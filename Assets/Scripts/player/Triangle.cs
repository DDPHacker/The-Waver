using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public float startTime;

    private Vector2[] UV = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
    private int[] triangles = new int[] { 0, 1, 2 };
    private float blockStayTime;
    private Color color;

    void Start()
    {
        startTime = Time.time;
    }

    public void Initialize(Vector3[] vertices, float blockStayTime, Color color)
    {
        this.blockStayTime = blockStayTime;
        this.color = color;
        transform.position = new Vector3(0, 0, 0);
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = UV;
        mesh.triangles = triangles;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void Update()
    {
        if (Time.time - startTime > blockStayTime)
        {
            Destroy(this.gameObject);
            return;
        }
        Color color = this.gameObject.GetComponent<MeshRenderer>().material.color;
        color.a = 1 - (Time.time - startTime) / blockStayTime;
        color.r = this.color.r + (1 - this.color.r) * (Time.time - startTime) / blockStayTime;
        color.g = this.color.g + (1 - this.color.g) * (Time.time - startTime) / blockStayTime;
        color.b = this.color.b + (1 - this.color.b) * (Time.time - startTime) / blockStayTime;
        this.gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
    
}
