using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BLEFramework.Unity;

/*
 * Detects the distance of the fire when active, and modifies the color of low parts of the vest.
 * 
 * Assigned to back_bottom_left. 
 */
public class TempBackLeft : MonoBehaviour {

	public static GameObject fire, textFire;
	float bodyPosX, bodyPosZ, firePosX, firePosZ, dist;
	static Text fireDist;
	Renderer rend;

	// Use this for initialization
	void Start () {
		fire = GameObject.Find("Fire");
		textFire = GameObject.FindGameObjectWithTag ("textfire");
		fireDist = textFire.GetComponent<Text> ();
		rend = GetComponent<Renderer> ();
		myBLEController.SendData("9");
	}

	// Update is called once per frame
	void Update () {
		bodyPosX = transform.position.x;
		bodyPosZ = transform.position.z;
		firePosX = fire.transform.position.x;
		firePosZ = fire.transform.position.z;
		dist = Mathf.Sqrt (Mathf.Pow(bodyPosX-firePosX,2)+Mathf.Pow(bodyPosZ-firePosZ,2));
		//fireDist.text = "Dist: "+Mathf.Round(100f*dist)/10f;
		//fireDist.color = Color.LerpUnclamped (Color.red, Color.black, dist);
		rend.material.shader = Shader.Find ("Standard");
		rend.material.color = Color.LerpUnclamped (Color.red, Color.gray, dist);
		/*
		print ("Fuego "+firePosX+" "+firePosZ);
		print ("Cuerpo "+bodyPosX+" "+bodyPosZ);
		print ("Distancia " + dist);
		*/

	}

	void ResetColor () {
		rend.material.shader = Shader.Find ("Standard");
		rend.material.color = Color.gray;
	}
}
