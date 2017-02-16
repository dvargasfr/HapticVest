using UnityEngine;
using System.Collections;

/*
 * Mueve la mano con el ratón al hacer click en ella.
 * 
 * Asignado a Hand.
 */
public class MoveHand : MonoBehaviour {
	float mouseInitPosX, mouseInitPosY, handInitPosX, handInitPosY, handInitPosZ, posx, posy, handInitRotW, handInitRotX, handInitRotY, handInitRotZ;
	bool click = false;
	float scale = 0.01f;
	public static Transform sphere;

	/*
	public GameObject particle;
	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
				Instantiate(particle, transform.position, transform.rotation);
		}
	}
	*/


	void OnMouseDown () {
		print ("Mano tocada!");
		click = true;
		handInitPosX = transform.position.x;
		handInitPosY = transform.position.y;
		handInitPosZ = transform.position.z;
		handInitRotW = transform.rotation.w;
		handInitRotX = transform.rotation.x;
		handInitRotY = transform.rotation.y;
		handInitRotZ = transform.rotation.z;
		mouseInitPosX = Input.mousePosition.x;
		mouseInitPosY = Input.mousePosition.y;
		posx = Input.mousePosition.x;
		posy = Input.mousePosition.y;
		print ("Hand Position: X " + handInitPosX + " Y " + handInitPosY);
		print ("Mouse Position: X " + mouseInitPosX + " Y " + mouseInitPosY);
	}

	void ResetPosition() {
		transform.position = new Vector3 (handInitPosX, handInitPosY, handInitPosZ);
	}

	// Use this for initialization
	void Start () {
		sphere = transform.Find ("TouchZone");
	}

	// Update is called once per frame
	void Update () {
		if (click) {
			///*
			float currentPosX = (Input.mousePosition.x - mouseInitPosX)*scale + handInitPosX;
			float currentPosY = (Input.mousePosition.y - mouseInitPosY)*scale + handInitPosY;
			float currentPosZ = -2.0f;
			transform.position = new Vector3 (currentPosX, currentPosY, currentPosZ);
			transform.rotation = new Quaternion(handInitRotX,handInitRotY,handInitRotZ,handInitRotW);

			//*/
			/*
			float diffx = Input.mousePosition.x - posx;
			float diffy = Input.mousePosition.y - posy;

			transform.Translate (	0, 
									diffy * Time.deltaTime,
									diffx * Time.deltaTime);
			
			posx = Input.mousePosition.x;
			posy = Input.mousePosition.y;
			*/
		}
	}
}
