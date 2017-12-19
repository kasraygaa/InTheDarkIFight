using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOperations : MonoBehaviour {
	public Transform goalX, goalY;
	Animator anim;
	//float x, y;
	//float gX, gY;
	//Quaternion cam;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {/*
		x = Input.GetAxis ("Mouse X");
		y = Input.GetAxis ("Mouse Y");
		gX += x * 130f * Time.deltaTime;
		gY += y * 130f * Time.deltaTime;
		cam = Quaternion.Euler (gY * - 1, gX, 0.0f);
		Camera.main.transform.rotation = cam;
		if (Input.GetKey (KeyCode.D))
			transform.position = transform.position + new Vector3 (1, 0) * 2f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.A))
			transform.position = transform.position + new Vector3 (-1, 0) * 2f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.W))
			transform.position = transform.position + new Vector3 (0, 0, 1) * 2f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.S))
			transform.position = transform.position + new Vector3 (0, 0, -1) * 2f * Time.deltaTime;
		if (Input.GetKey (KeyCode.RightArrow))
			goal.transform.position = goal.transform.position + new Vector3 (1, 0) * 1f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.LeftArrow))
			goal.transform.position = goal.transform.position + new Vector3 (-1, 0) * 1f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.UpArrow))
			goal.transform.position = goal.transform.position + new Vector3 (0, 1, 0) * 1f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.DownArrow))
			goal.transform.position = goal.transform.position + new Vector3 (0, -1, 0) * 1f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.I))
			goal.transform.position = goal.transform.position + new Vector3 (0, 0, 1) * 1f * Time.deltaTime;
		else if (Input.GetKey (KeyCode.K))
			goal.transform.position = goal.transform.position + new Vector3 (0, 0, -1) * 1f * Time.deltaTime;*/
	}

	void OnAnimatorIK(){
		anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
		anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
		anim.SetIKPosition (AvatarIKGoal.RightHand, goalX.transform.position);
		anim.SetIKRotation (AvatarIKGoal.RightHand, goalX.transform.rotation);

		anim.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
		anim.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
		anim.SetIKPosition (AvatarIKGoal.LeftHand, goalY.transform.position);
		anim.SetIKRotation (AvatarIKGoal.LeftHand, goalY.transform.rotation);
	}
}
