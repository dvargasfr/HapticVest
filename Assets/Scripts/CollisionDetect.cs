using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log ("Entra en colision");
	}
	void OnCollisionStay(Collision col){
		Debug.Log ("Mantiene en colision");
	}
	void OnCollisionExit(Collision col){
		Debug.Log ("Sale de colision");
	}
}