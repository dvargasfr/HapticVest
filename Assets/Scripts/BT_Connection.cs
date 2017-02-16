using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;
using System.IO.Ports;
using BLEFramework.Unity;

public class BT_Connection : MonoBehaviour {

	private static string BT_address = "5C:F8:21:8E:2A:CB";
	public bool initBLE = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (InitializeBLEFramework ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator InitializeBLEFramework(){
		int c = 0;
		ScriptInterface.statustxt.text = "Waiting for initBLE";
		while (myBLEControllerInitializer.Instance == null) {
			ScriptInterface.statustxt.text = "Waiting for initBLE "+c.ToString();
			c++;
			yield return null;
		}
		initBLE = myBLEControllerInitializer.Instance.InitBLEFramework ();
		if (initBLE) {
			myBLEController.GetPairedDevices();
			ScriptInterface.statustxt.text = "initBLE OK";
			btconnect ();
		} else {
			ScriptInterface.statustxt.text = "initBLE XXX";
		}
	}

	public void btconnect(){
		ScriptInterface.statustxt.text = "Trying to connect";
		if (myBLEController.ConnectPeripheral (BT_address)) {
			ScriptInterface.statustxt.text = "Connected1";
			ShowConnected ();
			ScriptInterface.statustxt.text = "Connected2";
		}
	}

	public static void ShowConnected() {
		ScriptInterface.textDisconnected.GetComponent<Text> ().enabled = false;
		ScriptInterface.imageCross.GetComponent<RawImage> ().enabled = false;
		ScriptInterface.textConnected.GetComponent<Text> ().enabled = true;
		ScriptInterface.imageTick.GetComponent<RawImage> ().enabled = true;
	}

	public static void ShowDisconnected() {
		ScriptInterface.textDisconnected.GetComponent<Text> ().enabled = true;
		ScriptInterface.imageCross.GetComponent<RawImage> ().enabled = true;
		ScriptInterface.textConnected.GetComponent<Text> ().enabled = false;
		ScriptInterface.imageTick.GetComponent<RawImage> ().enabled = false;
	}

	void OnEnable(){
		myBLEControllerEventHandler.OnBleDidInitializeEvent += HandleOnBleDidInitializeEvent;
		myBLEControllerEventHandler.OnBleDidInitializeErrorEvent += HandleOnBleDidInitializeErrorEvent;
	}

	void OnDisable(){
		myBLEControllerEventHandler.OnBleDidInitializeEvent -= HandleOnBleDidInitializeEvent;
		myBLEControllerEventHandler.OnBleDidInitializeErrorEvent -= HandleOnBleDidInitializeErrorEvent;
	}

	void HandleOnBleDidInitializeEvent(){
		print ("BLE Framework initialization: SUCCESS");
	}

	void HandleOnBleDidInitializeErrorEvent(string errorMessage){
		print ("ERROR: BLE initialization: "+errorMessage);
	}
		

}
