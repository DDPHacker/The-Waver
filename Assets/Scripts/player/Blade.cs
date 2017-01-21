using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    private GameManager _gameManager;

    public GameObject trianglePrefab;

    private Queue bladeTriangles = new Queue();
    private Vector3 lastPosition;
    private Vector3 lastPointer;
    private int length = 0;
    private float blockStayTime = 0;
    private int bladeIndex;

    void Start () {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        lastPosition = transform.position;
    }

    void Update () {
        transform.position = _gameManager._viveControllerManager.GetPosition (bladeIndex);

        popOutdatedBladeTriangles ();

        if (lastPosition != null && lastPointer != null)
            pushNewBladeTriangles (lastPosition, lastPointer, transform.position , _gameManager._viveControllerManager.GetForward(bladeIndex));
        lastPosition = transform.position;
    }

    private void popOutdatedBladeTriangles(){
        while (bladeTriangles.Count > 0) {
            GameObject triangle = (GameObject)bladeTriangles.Peek ();
            if (Time.time - triangle.GetComponent<Triangle> ().startTime < blockStayTime)
                break;
            
            Destroy((GameObject)bladeTriangles.Dequeue ());
            Destroy((GameObject)bladeTriangles.Dequeue ());
        }
    }

    private void pushNewBladeTriangles(Vector3 a, Vector3 aDirection, Vector3 b, Vector3 bDirection){
        Vector3 aa = a + aDirection * length;
        Vector3 bb = b + bDirection * length;

        GameObject t1 = Instantiate (trianglePrefab);
        t1.GetComponent<Triangle>().Initialize(new Vector3[]{a, aa, bb});
        GameObject t2 = Instantiate (trianglePrefab);
        t2.GetComponent<Triangle>().Initialize(new Vector3[]{a, bb, b});
        bladeTriangles.Enqueue (t1);
        bladeTriangles.Enqueue (t2);
    }

    void Initialize (int bladeIndex, int length, float blockStayTime) {
        this.length = length;
        this.blockStayTime = blockStayTime;
        this.bladeIndex = bladeIndex;
    }
}
