using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SceneSystem : MonoBehaviour {
	private GameObject obj;
	private Transform resPos;
	public static int q;
	private GameObject zombie;

	void Start () {
		resPos = null;
		q = 1;
	}

	public void Queue1(){
		obj = (GameObject)Resources.Load ("Prefabs/Characters/zombie", typeof(GameObject));
		resPos = GameObject.Find ("zombie ResPos-1").transform;
		Instantiate (obj, resPos.position, obj.transform.rotation);
		Debug.Log (q);
	}
	public void Queue2(){
		obj = (GameObject)Resources.Load ("Prefabs/Characters/zombie", typeof(GameObject));
		resPos = GameObject.Find ("zombie ResPos-2").transform;
		Instantiate (obj, resPos.position, obj.transform.rotation);
		Debug.Log (q);
	}
	public void Queue3(){
		obj = (GameObject)Resources.Load ("Prefabs/Characters/zombieFast", typeof(GameObject));
		resPos = GameObject.Find ("zombie ResPos-3").transform;
		zombie = Instantiate (obj, resPos.position, obj.transform.rotation);
		Debug.Log (q);
	}
}
