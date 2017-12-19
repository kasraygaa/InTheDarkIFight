using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {
	private TextMesh txt;

	void Start () {
		txt = GetComponent<TextMesh> ();
		txt.text = "High Score: " + PlayerPrefs.GetInt ("Score").ToString ();
	}
}
