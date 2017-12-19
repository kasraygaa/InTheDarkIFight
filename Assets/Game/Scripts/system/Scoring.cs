using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
	public static int score;
	private string hp;
	private TextMesh txt;

	void Start () {
		txt = GetComponent<TextMesh> ();
		score = 0;
		txt.text = "Kill: " + score;
	}
	
	void Update () {
		txt.text ="Kill: " + score;
		// "High Score: " + PlayerPrefs.GetInt ("Score") + "\n" +
	}
}
