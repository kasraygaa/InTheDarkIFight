using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp1 : MonoBehaviour {
	private float time;
	// Use this for initialization
	void Start () {
		time = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		time -= 1 * Time.deltaTime;
		if (time <= 0) {
			transform.GetChild (0).gameObject.SetActive (false);
			transform.GetChild (1).gameObject.SetActive (false);
			if (time <= -1.5f) {
				transform.GetChild (0).gameObject.SetActive (true);
				transform.GetChild (1).gameObject.SetActive (true);
				time = 1.5f;
			}
		}
	}
}
