using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject trianglePrefab;

    private Vector3 lastPosition;
    private Vector3 lastForward;
    private float length = 0;
    private float blockStayTime = 0;
    private int bladeIndex;

    public void Initialize(int bladeIndex, float length, float blockStayTime) {
        this.length = length;
        this.blockStayTime = blockStayTime;
        this.bladeIndex = bladeIndex;
    }

    void Start() {
        lastPosition = ViveManager.Instance.GetPosition(bladeIndex);
        lastForward = ViveManager.Instance.GetForward(bladeIndex);
    }

    void Update() {
        if (ViveManager.Instance.GetTriggerDown(bladeIndex)) {
            lightssaber[] sabers = GetComponentsInChildren<lightssaber>();
            foreach (lightssaber saber in sabers) {
                saber.ShowBlade();
            }
        }

        transform.position = ViveManager.Instance.GetPosition(bladeIndex);
        transform.forward = ViveManager.Instance.GetForward(bladeIndex);

        if (GetComponentInChildren<lightssaber>().on_blade)
            pushNewBladeTriangles(lastPosition, lastForward, transform.position , transform.forward);

        lastPosition = transform.position;
        lastForward = transform.forward;
    }

    private void pushNewBladeTriangles(Vector3 a, Vector3 aDirection, Vector3 b, Vector3 bDirection) {
        Vector3 aa = a + aDirection * length;
        Vector3 bb = b + bDirection * length;

        GameObject t1 = Instantiate(trianglePrefab);
        t1.GetComponent<Triangle>().Initialize(new Vector3[]{a, aa, bb}, blockStayTime);
        GameObject t2 = Instantiate(trianglePrefab);
        t2.GetComponent<Triangle>().Initialize(new Vector3[]{a, bb, b}, blockStayTime);
    }
}
