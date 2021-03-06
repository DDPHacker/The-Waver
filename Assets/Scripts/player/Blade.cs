using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject trianglePrefab;
    public float audioAmplifySpeed;

    private Vector3 lastPosition;
    private Vector3 lastForward;
    private float length = 0;
    private float blockStayTime = 0;
    private int bladeIndex;
    private lightssaber[] sabers;
    private LightSaberSwitchAudioController saberSwitchAudioController;
    private Color color;
    private bool doubleBlade;

    public void Initialize(int bladeIndex, float length, float blockStayTime, Color color, bool doubleBlade) {
        this.length = length;
        this.blockStayTime = blockStayTime;
        this.bladeIndex = bladeIndex;
        this.color = color;
        this.doubleBlade = doubleBlade;
    }

    void Start() {
        lastPosition = ViveManager.Instance.GetPosition(bladeIndex);
        lastForward = ViveManager.Instance.GetForward(bladeIndex);
        sabers = GetComponentsInChildren<lightssaber>();
        saberSwitchAudioController = GetComponent<LightSaberSwitchAudioController>();
    }

    void Update() {
        if (ViveManager.Instance.GetTriggerDown(bladeIndex)) {
            foreach (lightssaber saber in sabers) {
                saber.ShowBlade();
            }
            saberSwitchAudioController.PlaySwitchLightSaberSound();
        }

        transform.position = ViveManager.Instance.GetPosition(bladeIndex);
        transform.forward = ViveManager.Instance.GetForward(bladeIndex);

        bool has_blade = sabers[0].on_blade;
        if (has_blade) {
            pushNewBladeTriangles(lastPosition, lastForward, transform.position, transform.forward);
            if (doubleBlade) 
                pushNewBladeTriangles(lastPosition, -lastForward, transform.position, -transform.forward);
        }

        Vector3 mid_1 = lastPosition + lastForward * length / 2;
        Vector3 mid_2 = transform.position + transform.forward * length / 2;
        float speed = Mathf.Abs(Vector3.Distance(mid_1, mid_2));

        if (has_blade && saberSwitchAudioController.ShouldPlayLightSaberSound()) {
            saberSwitchAudioController.SetLightSaberVolume(0.2f + speed * audioAmplifySpeed);
        }

        lastPosition = transform.position;
        lastForward = transform.forward;
    }

    private void pushNewBladeTriangles(Vector3 a, Vector3 aDirection, Vector3 b, Vector3 bDirection) {
        Vector3 aa = a + aDirection * length;
        Vector3 bb = b + bDirection * length;

        GameObject t1 = Instantiate(trianglePrefab);
        t1.GetComponent<Triangle>().Initialize(new Vector3[]{a, aa, bb}, blockStayTime, this.color);
        GameObject t2 = Instantiate(trianglePrefab);
        t2.GetComponent<Triangle>().Initialize(new Vector3[]{bb, a, b}, blockStayTime, this.color);
    }
}
