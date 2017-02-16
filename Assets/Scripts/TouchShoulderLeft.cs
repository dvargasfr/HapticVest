using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;
using System.Text;
using System.Diagnostics;
using BLEFramework.Unity;

/*
 * Detects clicks on this part and calls to a specific Arduino function.
 * 
 * Assigned to shoulder_left.
 */
public class TouchShoulderLeft : MonoBehaviour {

	void OnMouseDown () {
		//Connection.WriteToArduino("LEFTSHOULDER");
		myBLEController.SendData("4");
		print(Connection.ReadFromArduino(100));
	}
}
