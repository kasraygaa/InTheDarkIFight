using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {
	private float time;
	private EventTrigger trigger;
	private EventTrigger.Entry entry;
	private GameObject tag;
	void Start()
	{
		time = 3f;
		EventTrigger trigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback = new EventTrigger.TriggerEvent();
		entry.callback.AddListener((data) => {OnSelectOptionDelegate ((PointerEventData)data); });
		trigger.triggers.Add(entry);
		tag = null;
	}

	void Update () {
		try {
			if (tag.name.Equals ("Exit")) {
				Debug.Log (time);
				time = time - 1 * Time.deltaTime;
				if (time <= 0f) {
					Application.Quit ();
				}
			}
		} catch (NullReferenceException) {
			return;
		}
	}


	private void OnSelectOptionDelegate(PointerEventData data)
	{

	}

	public void OnEnter(Collider coll){
		tag = coll.gameObject;
		time = 3f;
	}

	public void OnExit(Collider coll){
		tag = null;
	}
}
