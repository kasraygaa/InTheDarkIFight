using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhhInput : MonoBehaviour {
	public GameObject player;
	public GameObject col;
	public GameObject cam;
	public bool follow;
	public Transform ob;
	public bool isGrip;
	public float speed;
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId appBackButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
	float x, z;
	Rigidbody fis;
	bool isHolding;
	Vector3 touchPos;
	bool isWalking;
	public static bool OnTouchPad;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.GetPress (gripButton)) {
			Debug.Log ("grip00");
			isGrip = true;
		} else {
			isGrip = false;
		}
		if (controller.GetPressDown (triggerButton)) {
			Debug.Log("trg");
		}
		if (controller.GetPressDown (appBackButton)) {
			Debug.Log("rew");
		}
		if (controller.GetTouch (SteamVR_Controller.ButtonMask.Touchpad)) {
			OnTouchPad = true;
			touchPos = controller.GetAxis (touchPad);
			x =  touchPos.x;
			z =  touchPos.y;
			player.transform.position += new Vector3 (x, 0, z) * speed * Time.deltaTime;
			//cam.transform.position += new Vector3 (x, 0, z) * speed * Time.deltaTime;
			Debug.Log ("x "+touchPos.x.ToString()+"y "+touchPos.y.ToString());
		}


		//

		if (isGrip) {
			if (follow) {
				ob = col.transform;
				ob = transform;
				col.gameObject.transform.SetParent (transform);
				if (!isHolding) {
					fis = col.GetComponent<Rigidbody> (); // pedang
					fis.constraints = RigidbodyConstraints.FreezeAll;
					isHolding = true;
				}
			}
		} else {
			if (col != null) {
				col.gameObject.transform.parent = null;
				if (isHolding) {
					fis.constraints = RigidbodyConstraints.None;
					fis.useGravity = true;
					isHolding = false;
					col = null;
				}
				Debug.Log ("free");
			}
		}

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Sword")) {
			if (this.col == null) {
				follow = true;
				col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
				this.col = col.gameObject;
			}
		}
	}
}
