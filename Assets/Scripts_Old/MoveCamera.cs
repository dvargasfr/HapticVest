using UnityEngine;
using System.Collections;

/*
 * Hace girar la cámara alrededor del chaleco.
 * 
 * Asignado a Main Camera.
 */
public class MoveCamera : MonoBehaviour {
	Vector3 pos;
	float r, angle, x, y, z, rotx, roty, rotz;
	float currentRotation = 0.0f;
	Quaternion rotation;
	public static GameObject vest;

	// Use this for initialization
	void Start () {
		pos.Set (transform.position.x, transform.position.y, transform.position.z);
		vest = GameObject.FindGameObjectWithTag ("vest");
		r = Mathf.Sqrt (
			Mathf.Pow(transform.position.x - vest.transform.position.x, 2) + 
			Mathf.Pow(transform.position.y - vest.transform.position.y, 2) + 
			Mathf.Pow(transform.position.z - vest.transform.position.z, 2)
		);
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
		rotx = transform.rotation.eulerAngles.x;
		roty = transform.rotation.eulerAngles.y;
		rotz = transform.rotation.eulerAngles.z;
		print ("r: "+r);
		print ("rotx "+rotx+" roty "+roty+" rotz "+rotz);
	}
	
	// Update is called once per frame
	void Update () {
		angle += 0.01f;
		roty = (Mathf.Rad2Deg * angle) + 180;

		print ("angle " + angle);

		x = vest.transform.position.x + Mathf.Sin(angle)*r; 
		z = vest.transform.position.z + Mathf.Cos(angle)*r;

		transform.position = new Vector3 (x, y, z);
		transform.rotation = Quaternion.Euler(new Vector3(rotx, roty, rotz));

		/*
		if (Input.GetKey (KeyCode.LeftArrow)) {
			alpha -= 0.01f;
			pos.x -= r * Mathf.Cos (alpha);
			pos.y -= r * Mathf.Sin (alpha);
			print ("x - "+r * Mathf.Cos (alpha));
			print ("y - "+r * Mathf.Sin (alpha));
			print ("x: "+pos.x+" y "+pos.y);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			alpha += 0.01f;
			pos.x += r * Mathf.Cos (alpha);
			pos.y += r * Mathf.Sin (alpha);
			print ("x + "+r * Mathf.Cos (alpha));
			print ("y + "+r * Mathf.Sin (alpha));
			print ("x "+pos.x+" y "+pos.y);
		}

		*/

		/*
		currentRotation += Input.GetAxis("Horizontal")*Time.deltaTime*100;
		rotation.eulerAngles = Vector3(0, currentRotation, 0);
		transform.position = rotation * r;
			

		transform.position = Vector3.MoveTowards (transform.position, pos, 0.8f*Time.deltaTime);
		
		transform.Rotate (		Input.GetAxis ("Vertical") * 0.8f * Time.deltaTime,
								0,
								0);
		*/
	}
}
