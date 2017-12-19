using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDMG : MonoBehaviour {
	private GameObject player;
	public SphereCollider[] handCollider;
	private int damage;
	private bool atck;
	private Healthing playerHP;
	private ParticleSystem bloodPlayer;

	void Start () {
		damage = 2;
		player = GameObject.Find ("player");
		playerHP = player.GetComponent<Healthing> ();
		atck = true;
		bloodPlayer = player.transform.GetChild (0).transform.GetChild (0).GetComponent<ParticleSystem> ();
		bloodPlayer.Stop ();
	}

	public bool RDoDamage(){
		return atck;
	}

	public bool LDoDamage(){
		return atck;
	}

	void OnTriggerEnter(Collider coll){
		if (coll.name.Equals(player.name)) {
			if ((player && RDoDamage()) ||  (player && LDoDamage())) {
				playerHP.takeDamage (damage);
				bloodPlayer.Play ();
			}
		}
	}
}
