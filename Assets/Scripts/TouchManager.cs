using UnityEngine;
using System.Collections;

/*
 * Script to interact with the app using a touch device.
 * Tested with Unity Remote 4.
 * 
 * Assigned to Main Camera.
 */
public class TouchManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//UnityEngine.Touch[] mytouches = Input.touches;
		for (int i = 0; i < Input.touchCount; i++) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)){
				GameObject recipient = hit.transform.gameObject;

				if (Input.GetTouch (i).phase == TouchPhase.Began) {
					print ("Enviado changecolor a " + recipient.name);
					recipient.SendMessage ("ChangeColor", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
