using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAI : MonoBehaviour {
	public Transform cam;
	public float offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!OhhInput.OnTouchPad) {
			//knig.Pos = cam.Pos
			transform.position = cam.position;
			//ngasih offset
			transform.position = new Vector3 (cam.position.x, offset, cam.position.z);
			Vector3 rotate = cam.rotation.eulerAngles;
			rotate = new Vector3 (0, rotate.y, 0);
			transform.rotation = Quaternion.Euler (rotate);
		}
	}
}
