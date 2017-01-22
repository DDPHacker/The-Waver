using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    private GameManager _gameManager;

    public GameObject trianglePrefab;

    private Vector3 lastPosition;
    private Vector3 lastForward;
    private float length = 0;
    private float blockStayTime = 0;
    private int bladeIndex;

    public void Initialize (int bladeIndex, float length, float blockStayTime) {
        this.length = length;
        this.blockStayTime = blockStayTime;
        this.bladeIndex = bladeIndex;
    }

    void Start () {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        lastPosition = _gameManager._viveControllerManager.GetPosition (bladeIndex);
        lastForward = _gameManager._viveControllerManager.GetForward (bladeIndex);
    }

    void Update () {
        if (_gameManager._viveControllerManager.GetTriggerDown (bladeIndex)){
            GetComponentInChildren<lightssaber> ().showBlade ();
        }

        transform.position = _gameManager._viveControllerManager.GetPosition (bladeIndex);
        transform.forward = _gameManager._viveControllerManager.GetForward (bladeIndex);

        if (lastPosition != null && lastForward != null)
            pushNewBladeTriangles (lastPosition, lastForward, transform.position , transform.forward);
        lastPosition = transform.position;
        lastForward = transform.forward;
    }

    private void pushNewBladeTriangles(Vector3 a, Vector3 aDirection, Vector3 b, Vector3 bDirection){
        Vector3 aa = a + aDirection * length;
        Vector3 bb = b + bDirection * length;

        GameObject t1 = Instantiate (trianglePrefab);
        t1.GetComponent<Triangle>().Initialize(new Vector3[]{a, aa, bb}, blockStayTime);
        GameObject t2 = Instantiate (trianglePrefab);
        t2.GetComponent<Triangle>().Initialize(new Vector3[]{a, bb, b}, blockStayTime);
    }
}
