using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bulletNav : MonoBehaviour {
	public static Vector3 target;
	private float speed;
	private Vector3 targetTemp;
	private ParticleSystem blood;
	private Healthing zombieHP;
	private int damage;
	private int random;
	void Start () {
		speed = 200f;
		targetTemp = target;
		blood = transform.GetChild (0).transform.GetComponent<ParticleSystem> ();
		blood.Stop ();
		damage = 25;
	}

	void Update() {
		transform.position = Vector3.MoveTowards (transform.position, targetTemp, speed * Time.deltaTime);
		if (gameObject.activeInHierarchy) {
			Destroy (gameObject, 0.3f);
		}
	}

	void OnTriggerStay(Collider coll){
		try {
			blood.Play ();
			zombieHP = coll.transform.root.gameObject.GetComponent<Healthing> ();
			random = UnityEngine.Random.Range (1, 3);
			if (coll.gameObject.tag.Equals ("Head")) {
				damage += 10;
				if (random <= 2) {
					damage += 25;
					coll.transform.root.GetChild (1).transform.gameObject.SetActive (false);
					coll.gameObject.SetActive (false);
				}
			}
			else if (coll.gameObject.tag.Equals ("LHandOut")) {
				if (random <= 2) {
					damage += 15;
					coll.transform.root.GetChild (2).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (3).transform.gameObject.SetActive (false);
					if (coll.gameObject.name.Equals ("Bip01 L Hand")) {
						coll.gameObject.transform.parent.gameObject.SetActive (false);
						coll.gameObject.SetActive (false);
					}else
						coll.gameObject.SetActive (false);
				}
			}
			else if (coll.gameObject.tag.Equals ("LHandMid")) {
				if (random <= 2) {
					damage += 15;
					coll.transform.root.GetChild (2).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (3).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (4).transform.gameObject.SetActive (false);
					coll.gameObject.SetActive (false);
				}
			}
			else if (coll.gameObject.tag.Equals ("LHandIn")) {
				if (random <= 2) {
					damage += 15;
					coll.transform.root.GetChild (2).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (3).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (4).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (5).transform.gameObject.SetActive (false);
					coll.gameObject.SetActive (false);
				}
			}
			else if (coll.gameObject.tag.Equals ("RHandOut")) {
				if (random <= 2) {
					damage += 15;
					coll.transform.root.GetChild (6).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (7).transform.gameObject.SetActive (false);
					if (coll.gameObject.name.Equals ("Bip01 R Hand")) {
						coll.gameObject.transform.parent.gameObject.SetActive (false);
						coll.gameObject.SetActive (false);
					}else
						coll.gameObject.SetActive (false);
				}
			}
			else if (coll.gameObject.tag.Equals ("RHandMid")) {
				if (random <= 2) {
					damage += 20;
					coll.transform.root.GetChild (6).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (7).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (8).transform.gameObject.SetActive (false);
					coll.gameObject.SetActive (false);
				}
			}
			else if (coll.gameObject.tag.Equals ("RHandIn")) {
				if (random <= 2) {
					damage += 15;
					coll.transform.root.GetChild (6).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (7).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (8).transform.gameObject.SetActive (false);
					coll.transform.root.GetChild (9).transform.gameObject.SetActive (false);
					coll.gameObject.SetActive (false);
				}
			}
			zombieHP.takeDamage (damage);
			//Debug.Log (coll.gameObject);
			//Debug.Log (damage);
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			Destroy (gameObject, 0.1f);
		} catch (NullReferenceException ex) {
			return;
		}
	}
}
