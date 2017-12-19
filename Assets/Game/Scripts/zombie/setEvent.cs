using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class setEvent : MonoBehaviour {
	private float time;
	private GameObject gun;
	private EventTrigger trigger;
	private EventTrigger.Entry entry;

	void Start()
    {
		time = 1f;
		gun = GameObject.Find ("PM-40_Variant4");
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback = new EventTrigger.TriggerEvent();
		entry.callback.AddListener((data) => {OnSelectOptionDelegate ((PointerEventData)data); });
		trigger.triggers.Add(entry);
    }

	void Update () {
		time -= 1 * Time.deltaTime;
	}

	private void OnSelectOptionDelegate(PointerEventData data)
	{
		//Debug.Log (data.pointerCurrentRaycast.worldPosition);
		bulletNav.target = data.pointerCurrentRaycast.worldPosition;
		if (time <= 0f) {
			gun.GetComponent<gunShoot>().Shoot();
			time = 0.5f;
		}
    }
}
