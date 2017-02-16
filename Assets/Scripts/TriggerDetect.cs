using UnityEngine;
using System.Collections;

public class TriggerDetect : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		Debug.Log ("Entra en collider");
	}
	void OnTriggerStay(Collider col){
		Debug.Log ("Mantiene en collider");
	}
	void OnTriggerExit(Collider col){
		Debug.Log ("Sale de collider");
	}
}
