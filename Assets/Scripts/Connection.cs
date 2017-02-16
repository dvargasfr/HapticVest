using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Text;
using System.Diagnostics;
using System.Threading;
using UnityEngine.UI;

/*
 * Manage the serial connection state of the app with Arduino.
 * 
 * Assigned to Main Camera.
 */

public class Connection : MonoBehaviour {

	static string port = "COM5";
	static int baudrate = 9600;

	public static SerialPort stream = new SerialPort(port, baudrate);

	public void OpenSerial() {
		stream.ReadTimeout = 50;
		stream.Open();
	}

	public static void WriteToArduino(string message) {
		stream.WriteLine(message);
		stream.BaseStream.Flush();
	}

	public static string ReadFromArduino(int timeout = 0){
		stream.ReadTimeout = timeout;
		try{
			return stream.ReadLine();
		}catch(TimeoutException){
			return null;
		}
	}

	public void Close(){
		stream.Close ();
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

	IEnumerator ConnectManager(){
		print ("IEnumerator");
		while (true) {
			if (stream.IsOpen) {
				try {
					WriteToArduino ("ping");
					Connection.ShowConnected ();
				} catch (Exception) {
					stream.Close ();
					Connection.ShowDisconnected ();
				}
			} else {
				try {
					stream.Open ();
					Connection.ShowConnected ();
				} catch (Exception) {
					Connection.ShowDisconnected ();
				}
			}
			yield return new WaitForSeconds(1.0f);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (ConnectManager ());
	}
}