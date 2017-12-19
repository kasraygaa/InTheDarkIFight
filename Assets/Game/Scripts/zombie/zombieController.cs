// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class zombieController : MonoBehaviour {
	private UnityEngine.AI.NavMeshAgent agent;
	private float speedTemp;
	private Transform player;
	private float dist;
	private Animator anim;
	private Vector3 bunshin;
	private Healthing thisHP;
	private zombieDied zombie;
	private bool tag;
	private Collider[] childColliders;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		speedTemp = agent.speed;
		player = GameObject.Find ("player").transform;
		anim = GetComponent<Animator> ();
		bunshin = player.position;
		thisHP = GetComponent<Healthing> ();
		thisHP.health = 10;
		tag = true;
	}

	void Update () {
		if (tag) {
			bunshin = player.position;
			bunshin = new Vector3 (bunshin.x, 0, bunshin.z);
			dist = Vector3.Distance (transform.position, bunshin);
			if (thisHP.health <= 0) {
				tag = false;
				agent.SetDestination (transform.position);
				anim.SetBool ("run", false);
				anim.SetBool ("atk", false);
				anim.SetBool ("died", true);
				GetComponent<zombieDMG> ().enabled = false;
				DestroyColliders ();
				Destroy (gameObject, 1.8f);
				tag = false;
			} else {
				if (dist <= agent.stoppingDistance + 5f) {
					agent.SetDestination (bunshin);
					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
					anim.SetBool ("run", true);
					anim.SetBool ("atk", true);
				}else if(dist <= agent.stoppingDistance) {
					agent.SetDestination (transform.position);
					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
					anim.SetBool ("run", false);
					anim.SetBool ("atk", true);
				}else {
					agent.SetDestination (bunshin);
					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
					anim.SetBool ("run", true);
					anim.SetBool ("atk", false);
				}
			}
		}
	}

	void OnDestroy(){
		Scoring.score++;
		if (Scoring.score > PlayerPrefs.GetInt ("Score") && !gameOver.ea)
			PlayerPrefs.SetInt ("Score", Scoring.score);
	}

	private void DestroyColliders(){
		childColliders = GetComponentsInChildren<Collider> ();
		foreach (Collider collider in childColliders) {
			DestroyImmediate (collider);
		}
	}
}
