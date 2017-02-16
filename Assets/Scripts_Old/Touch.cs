using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Text;
using System.Diagnostics;
using System.Threading;

/*
 * Manage clicks on the vest.
 * Depending on the frequency, Arduino calls one function or another.
 * 
 * It is assigned to differents parts of the vest.
 */

public class Touch : MonoBehaviour {

	string port = "COM3";
	int baudrate = 9600;

	private SerialPort stream;

	Thread touchManager;

	public void OpenSerial() {
		stream = new SerialPort(port, baudrate);
		stream.ReadTimeout = 50;
		print ("Waiting for connection");
		stream.Open();
		print ("Connection established!");
	}

	public void WriteToArduino(string message) {
		stream.WriteLine(message);
		stream.BaseStream.Flush();
	}

	public string ReadFromArduino(int timeout = 0){
		stream.ReadTimeout = timeout;
		try{
			return stream.ReadLine();
		}catch(TimeoutException){
			return null;
		}
	}

	public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity) {
		DateTime initialTime = DateTime.Now;
		DateTime nowTime;
		TimeSpan diff = default(TimeSpan);

		string dataString = null;

		do {
			try {
				dataString = stream.ReadLine ();
			} catch (TimeoutException) {
				dataString = null;
			}

			if (dataString != null) {
				callback (dataString);
				yield return null;
			} else
				yield return new
				WaitForSeconds (0.05f);

			nowTime = DateTime.Now;
			diff = nowTime - initialTime;
		} while (diff.Milliseconds < timeout);

		if (fail != null)
			fail ();
		yield return null;
	}

	public void Close(){
		stream.Close ();
	}

	// Use this for initialization
	void Start () {
	}

	void BaseColor() {
		Renderer rend = GetComponent<Renderer> ();
		rend.material.shader = Shader.Find ("Standard");
		rend.material.SetColor ("_Color", Color.gray);
	}

	void ChangeColor() {
		Renderer rend = GetComponent<Renderer> ();
		rend.material.shader = Shader.Find ("Standard");
		rend.material.SetColor ("_Color", Color.yellow);
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Coroutine function which reads the number of touches on the vest after 1 second.
	IEnumerator TouchManager(){
		yield return new WaitForSeconds(1.0f);
		print ("ScriptInterface.nTouches "+ScriptInterface.nTouches);
		OpenSerial();
		switch (ScriptInterface.nTouches) {
		case 1:
			WriteToArduino ("PING1");
			ScriptInterface.nTouches = 0;
			print(ReadFromArduino(100));
			break;
		case 2:
			WriteToArduino ("PING2");
			ScriptInterface.nTouches = 0;
			print(ReadFromArduino(100));
			break;
		default:
			break;
		}
		Close();
	}

	void OnMouseDown () {
		// Start a thread running the coroutine.
		ScriptInterface.nTouches++;
		ChangeColor ();
		if (ScriptInterface.nTouches == 1) {
			StartCoroutine (TouchManager ());
		}
	}
}