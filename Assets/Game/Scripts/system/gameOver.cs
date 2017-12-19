using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour {
	private GameObject player;
	private Healthing thisHP;
	public static bool ea;

	// Use this for initialization
	void Start () {
		ea = false;
		player = GameObject.Find ("player");
		thisHP = player.GetComponent<Healthing> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisHP.health <= 0) {
			ea = true;
			Time.timeScale = 1;
			SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
			Time.timeScale = 1;
		}
			
	}
}
