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
 * Assigned to shoulder_right.
 */
public class TouchShoulderRight : MonoBehaviour {

	void OnMouseDown () {
		//Connection.WriteToArduino("RIGHTSHOULDER");
		myBLEController.SendData("3");
		//print(Connection.ReadFromArduino(100));
	}
}
