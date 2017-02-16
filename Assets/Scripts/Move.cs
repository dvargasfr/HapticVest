using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Move the vest in rotation.
 * 
 * Assigned to Vest.
 */
public class Move : MonoBehaviour {

	float rot;
	static Slider slider;
	float lastsliderval;
	static GameObject sliderVest;
	int ntouches;
	UnityEngine.Touch t;

	// Use this for initialization
	void Start () {
		// rot = transform.rotation.eulerAngles.y;
		// print ("chaleco rot " + rot);
		sliderVest = GameObject.Find("Slider");
		slider = sliderVest.GetComponent<Slider> ();
		lastsliderval = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Input.GetAxis ("Horizontal") * 0.5f * Time.deltaTime, 0, 0);

		/******* Rotate the vest with arrow keys *******
		 * 
		if (Input.GetKey (KeyCode.LeftArrow))
			rot += 1f;
		if (Input.GetKey (KeyCode.RightArrow))
			rot -= 1f;

		transform.rotation = Quaternion.Euler(new Vector3(0, rot, 0));
		********/

		/******* Rotate the vest dragging the finger horizontally on the screen *******
		*
		if (Input.touchCount > 0) {
			switch (Input.GetTouch(0).phase) {
			case TouchPhase.Began:
				startPosition = Input.GetTouch(0).position;
				directionChosen = false;
				break;
			case TouchPhase.Moved:
				direction = Input.GetTouch(0).position - startPosition;
				break;
			case TouchPhase.Ended:
				directionChosen = true;
				break;
			}
		}
		if (directionChosen) {
			transform.rotation = Quaternion.Euler(new Vector3(0, direction.x, 0));
			print ("direction.x " + direction.x);
		}
		********/

		/******* Rotate the vest with slider *******/
		float diffval = slider.value - lastsliderval;
		Vector3 center = new Vector3(0, 1.22f, -0.05f);
		transform.RotateAround (center, new Vector3 (0, 1, 0), diffval);
		lastsliderval = slider.value;
	}
}
