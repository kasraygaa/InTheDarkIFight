using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDied : MonoBehaviour {
	// Use this for initialization
	public void Died(Animator anim){
		anim.SetBool ("run", false);
		anim.SetBool ("atk", false);
		anim.SetBool ("died", true);
	}
}
