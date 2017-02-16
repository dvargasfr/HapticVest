namespace BLEFramework.Unity
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;

	public class myBLEControllerEventHandler : MonoBehaviour {

		//native events
		public delegate void OnBleDidConnectEventDelegate();
		public static event OnBleDidConnectEventDelegate OnBleDidConnectEvent;

		public delegate void OnBleDidDisconnectEventDelegate();
		public static event OnBleDidDisconnectEventDelegate OnBleDidDisconnectEvent;

		public delegate void OnBleDidReceiveDataEventDelegate(byte[] data, int numOfBytes);
		public static event OnBleDidReceiveDataEventDelegate OnBleDidReceiveDataEvent;

		public delegate void OnBleDidInitializeEventDelegate();
		public static event OnBleDidInitializeEventDelegate OnBleDidInitializeEvent;

		public delegate void OnBleDidCompletePeripheralScanEventDelegate(List<object> peripherals);
		public static event OnBleDidCompletePeripheralScanEventDelegate OnBleDidCompletePeripheralScanEvent;

		//errors
		public delegate void OnBleDidInitializeErrorEventDelegate(string errorMessage);
		public static event OnBleDidInitializeErrorEventDelegate OnBleDidInitializeErrorEvent;

		public delegate void OnBleDidConnectErrorEventDelegate(string errorMessage);
		public static event OnBleDidConnectErrorEventDelegate OnBleDidConnectErrorEvent;

		public delegate void OnBleDidDisconnectErrorEventDelegate(string errorMessage);
		public static event OnBleDidDisconnectErrorEventDelegate OnBleDidDisconnectErrorEvent;

		public delegate void OnBleDidCompletePeripheralScanErrorEventDelegate(string errorMessage);
		public static event OnBleDidCompletePeripheralScanErrorEventDelegate OnBleDidCompletePeripheralScanErrorEvent;



		void OnBleDidInitialize(string message){
			if (message=="Success"){
				if (OnBleDidInitializeEvent!=null){
					OnBleDidInitializeEvent();
				}
			}
			else if (OnBleDidInitializeErrorEvent!=null){
				OnBleDidInitializeErrorEvent(message);
			}
		}

		void OnBleDidConnect(string message){
			if (message=="Success"){
				if (OnBleDidConnectEvent!=null){
					OnBleDidConnectEvent();
				}
			}
			else if (OnBleDidConnectErrorEvent!=null){
				OnBleDidConnectErrorEvent(message);
			}
		}

		void OnBleDidDisconnect(string message){
			if (message=="Success"){
				if (OnBleDidDisconnectEvent!=null){
					OnBleDidDisconnectEvent();
				}
			}
			else if (OnBleDidDisconnectErrorEvent!=null){
				OnBleDidDisconnectErrorEvent(message);
			}
		}
	}
}
