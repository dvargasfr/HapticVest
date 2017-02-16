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
 * Assigned to back_top_right.
 */
public class TouchBackRight : MonoBehaviour {

	void OnMouseDown () {
		//Connection.WriteToArduino("RIGHTBACK");
		//print(Connection.ReadFromArduino(100));
		myBLEController.SendData("6");
	}
}
