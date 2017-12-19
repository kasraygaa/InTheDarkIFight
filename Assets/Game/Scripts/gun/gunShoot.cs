using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour {
	public AudioClip flareShotSound;
	private GameObject gun;
	private GameObject bullet;
	private GameObject gunTip;

	void Start () {
		gun = GameObject.Find ("PM-40_Variant4");
		gun.transform.GetChild (4).transform.GetChild (0).transform.GetComponent<ParticleSystem> ().Stop ();
		bullet = (GameObject)Resources.Load ("Prefabs/bullet", typeof(GameObject));
		gunTip = GameObject.Find ("PM-40_Tip");
	}

	public void Shoot(){
		GetComponent<AudioSource>().PlayOneShot(flareShotSound);
		gun.transform.GetChild (4).transform.GetChild (0).transform.GetComponent<ParticleSystem> ().Play ();
		Instantiate (bullet, gunTip.transform.position, gunTip.transform.rotation);
	}
}
