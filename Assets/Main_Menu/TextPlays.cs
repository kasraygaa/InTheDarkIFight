using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPlays : MonoBehaviour {
	private TextMesh txt;
	private float fsec;
	private int sec;
	// Use this for initialization
	void Start () {
		txt = GetComponent<TextMesh> ();
		txt.text = "Welcome to The Death Game Player\nIn The Dark, You Fight!";
	}
	// Update is called once per frame
	void Update () {
		fsec += 1 * Time.deltaTime;
		sec = Mathf.FloorToInt (fsec);
		if (sec == 3) {
			txt.text = "Stay in your position!\nBefore you go alone, we will help to train you";
		} else if (sec == 6) {
			txt.text = "Hold the grip button to use the sword in your front!";
		} else if (sec == 9) {
			txt.text = "You can try to hit the dummy you want";
		} else if (sec == 12) {
			txt.text = "Okay good\n Now you can use the skill using trigger button\nTry to hit the dummy you want";
		} else if (sec == 14) {
			txt.text = "Okay enough!\nYou seem good on it";
		}
	}

}
