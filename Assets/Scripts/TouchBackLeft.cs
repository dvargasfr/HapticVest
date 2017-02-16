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
 * Assigned to back_top_left.
 */
public class TouchBackLeft : MonoBehaviour {

	void OnMouseDown () {
		//Connection.WriteToArduino("LEFTBACK");
		//print(Connection.ReadFromArduino(100));
		myBLEController.SendData("5");
	}
}
