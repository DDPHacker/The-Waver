using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightssaber : MonoBehaviour {

	// Use this for initialization
	LineRenderer lineRend;
	public Transform startPos;
	public Transform endPos;

	public bool on_blade = true;
	private float textureOffset = 0f;
	private Vector3 endPosExtendedPos;

	void Start () {
		lineRend = GetComponent<LineRenderer> ();
		endPosExtendedPos = endPos.localPosition;
	}

    public void showBlade(){
		if (on_blade) {
			on_blade = false;
        } else {
			on_blade = true;
        }
    }
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			if (on_blade) {
				on_blade = false;
			} else {
				on_blade = true;
			}
		}
		//extend the line
		if (on_blade) {
			endPos.localPosition = Vector3.Lerp (endPos.localPosition, endPosExtendedPos, Time.deltaTime * 5f);
		}
		//Hide line
		else {
			endPos.localPosition = Vector3.Lerp (endPos.localPosition, startPos.localPosition, Time.deltaTime * 5f);
		}

		//update line positions
		lineRend.SetPosition(0,startPos.position);
		lineRend.SetPosition(1,endPos.position);

		//pan texture
		textureOffset -= Time.deltaTime*2f;
		if(textureOffset < -10f){
			textureOffset += 10f;
	}
		lineRend.sharedMaterials [1].SetTextureOffset ("_MainTex",new Vector2(textureOffset,0f));
	}
}
