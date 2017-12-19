using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour {
	public float time;
	private float sTime;
	private GameObject obj;
	private int choose;
	private Transform resPos;
	void Start () {
		sTime = time;
		obj = (GameObject)Resources.Load ("Prefabs/Characters/zombie", typeof(GameObject));
		resPos = GameObject.Find ("zombie ResPos-1").transform;
	}

	void Update () {
		time -= 1 * Time.deltaTime;
		if (time < 0f) {
			Instantiate (obj, resPos.position, obj.transform.rotation);
			time = sTime;
		}

	}

//	private Vector3 Randomness(){
//		choose = Random.Range (1, 4);
//		if (choose == 1)
//			return new Vector3 (200, 0, 200);
//		else if (choose == 2)
//			return new Vector3 (130, 0, 130);
//		else if (choose == 3)
//			return new Vector3 (200, 0, 60);
//		else
//			return new Vector3 (270, 0, 130);
//	}
}
