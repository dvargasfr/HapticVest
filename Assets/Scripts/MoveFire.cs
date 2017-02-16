using UnityEngine;
using System.Collections;

/*
 * Move fire with arrow keys.
 * 
 * Assigned to Fire.
 */
public class MoveFire : MonoBehaviour {

	float fireInitPosX, fireInitPosY, fireInitPosZ, fireAccelInitPosX, fireAccelInitPosZ, translationx, translationz;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		fireInitPosX = transform.position.x;
		fireInitPosY = transform.position.y;
		fireInitPosZ = transform.position.z;
		fireAccelInitPosX = Input.acceleration.x;
		fireAccelInitPosZ = Input.acceleration.z;
		pos.Set (fireInitPosX, fireInitPosY, fireInitPosZ);
	}

	void ResetPosition() {
		transform.position = new Vector3 (fireInitPosX, fireInitPosY, fireInitPosZ);
	}
	
	// Update is called once per frame
	void Update () {
		/******* Move fire with arrow keys *******
		 
		transform.Translate (	Input.GetAxis ("Horizontal") * -0.8f * Time.deltaTime, 
								0,
								Input.GetAxis ("Vertical") * -0.8f * Time.deltaTime);

		/******* Move fire with WASD keys *******

		if (Input.GetKey (KeyCode.A))
			pos.x += 0.01f;
		if (Input.GetKey (KeyCode.D))
			pos.x -= 0.01f;
		if (Input.GetKey (KeyCode.W))
			pos.z -= 0.01f;
		if (Input.GetKey (KeyCode.S))
			pos.z += 0.01f;
		
		transform.position = Vector3.MoveTowards (transform.position, pos, 0.8f*Time.deltaTime);
		*/

		/******* Move fire with accelerometer *******/
		transform.Translate (-Input.acceleration.x/100, 0, Input.acceleration.z/100);

		//translationx = fireAccelInitPosX + Input.acceleration.x;
		//translationz = fireAccelInitPosZ - Input.acceleration.z;
		//transform.Translate (-translationx/100, 0, translationz/100);
	}

}
