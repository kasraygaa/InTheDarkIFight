using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthing : MonoBehaviour {
	private int _health = 100;
	public int health{
		set { _health = value; }
		get { return _health; }
	}

	public void takeDamage(int damage){
		health -= damage;
	}
}
