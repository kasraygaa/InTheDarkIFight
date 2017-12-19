using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barHP : MonoBehaviour {
	private Healthing thisHP;
	private string hp;
	private TextMesh txt;

	void Start () {
		thisHP = GameObject.Find ("player").GetComponent<Healthing> ();
		txt = GetComponent<TextMesh> ();
		hp = thisHP.health.ToString ();
		txt.text = "HP: " + hp + "%";
	}
	
	void Update () {
		hp = thisHP.health.ToString ();
		txt.text = "HP: " + hp + "%";
	}
}
