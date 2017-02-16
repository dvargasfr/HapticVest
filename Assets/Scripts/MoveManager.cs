using UnityEngine;
using System.Collections;

public class MoveManager : MonoBehaviour {

	float zpos;
	// Use this for initialization
	void Start () {
		zpos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxis("Horizontal")*Time.deltaTime*10,0,Input.GetAxis("Vertical")*Time.deltaTime*10);
	}
}
