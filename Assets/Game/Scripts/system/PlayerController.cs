using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	private float speed;
	private Vector3 dest;
	private SceneSystem Quest;
	private Vector3 begin;
	private GameObject door2;
	private GameObject door1;
	private float time;

	void Start () {
		Quest = new SceneSystem ();
		speed = 1;
		begin = transform.position;
		door2 = GameObject.Find ("Door (2)");
		door1 = GameObject.Find ("Door (3)");
		time = 6;
		gameObject.GetComponent<CapsuleCollider> ().enabled = false; //collider player is disabled
	}

	void Update () {
		time = time - 1 * Time.deltaTime;
		//Debug.Log ("EA: " + SceneSystem.q);
		if (SceneSystem.q.Equals (1) && time <= 0f) {
			dest = new Vector3 (187.85f, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
			if (transform.position.Equals (dest)) {
				Quest.Queue1 ();
				SceneSystem.q++;
			}
		} else if (SceneSystem.q.Equals (2) && Scoring.score.Equals (1)) {
			dest = new Vector3 (175.60f, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
			if (transform.position.Equals (dest)) {
				SceneSystem.q++;
			}
		} else if (SceneSystem.q.Equals (3)) {
			dest = new Vector3 (transform.position.x, transform.position.y, 52.47f);
			transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
			if (transform.position.Equals (dest)) {
				SceneSystem.q++;
			}
		} else if (SceneSystem.q.Equals (4)) {
			door2.transform.rotation = Quaternion.Slerp (door2.transform.rotation, Quaternion.Euler (0, -65, 0), 5 * Time.deltaTime);
			dest = new Vector3 (175.60f, -0.53f, 57.03f);
			transform.position = Vector3.MoveTowards (transform.position, dest, (speed + 1.5f) * Time.deltaTime);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, -90, -90), (speed + 1.5f) * Time.deltaTime);
			if (transform.position.Equals (dest)) {
				SceneSystem.q++;
			}
		} else if (SceneSystem.q.Equals (5)) {
			Quest.Queue2 ();
			SceneSystem.q++;
		} else if (SceneSystem.q.Equals (6) && Scoring.score.Equals (2)) {
			dest = new Vector3 (172f, 2, 55);
			door1.transform.localRotation = Quaternion.Slerp (door1.transform.localRotation, Quaternion.Euler (0, -65, 0), 5 * Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, -90, 0), (speed + 0.5f) * Time.deltaTime);
			if (transform.position.Equals (dest)) {
				SceneSystem.q++;
				Quest.Queue3 ();
			}
		} else if (SceneSystem.q.Equals (7)) {
			dest = new Vector3 (168f, 2, 55);
			transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, -90, 0), (speed + 1.5f) * Time.deltaTime);
			if (transform.position.Equals (dest)) {
				SceneSystem.q++;
			}
		} else if (SceneSystem.q.Equals (8)) {
			if (gameObject.GetComponent<CapsuleCollider> ().enabled.Equals (false))
				gameObject.GetComponent<CapsuleCollider> ().enabled = true;
			
			if (time <= 0) {
				Quest.Queue2 ();
				Quest.Queue3 ();
				time = 8;
			}

			if (Scoring.score.Equals (25))
				SceneSystem.q++;
		} else if (SceneSystem.q.Equals (9)) {
			SceneManager.LoadScene ("GameLast", LoadSceneMode.Single);
		}
	}
}
	