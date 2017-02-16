namespace BLEFramework.Unity
{
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;

	public class myBLEControllerInitializer : MonoBehaviour {

		public static myBLEControllerInitializer Instance;

		void Awake(){
			if(Instance == null){
				Instance = this;
				gameObject.name = "myBLEControllerInitializer";
				GameObject.DontDestroyOnLoad(this.gameObject);
			}else{
				GameObject.Destroy(this.gameObject);
			}
		}

		void Start(){ }

		public bool InitBLEFramework(){
			return myBLEController.InitBLEFramework();
		}

		void OnEnable(){
			myBLEControllerEventHandler.OnBleDidInitializeEvent += HandleOnBleDidInitializeEvent;
			myBLEControllerEventHandler.OnBleDidInitializeErrorEvent += HandleOnBleDidInitializeErrorEvent;
		}

		void HandleOnBleDidInitializeEvent (){
			Debug.Log ("BLEControllerInitializer: HandleOnBleDidInitializeEvent: BLE Framework: successful initialization");
		}

		void HandleOnBleDidInitializeErrorEvent (string errorMessage){
			Debug.Log ("BLEControllerInitializer: HandleOnBleDidInitializeEvent: Error initializing BLE Framework: "+errorMessage);
		}

		void OnDisable(){
			myBLEControllerEventHandler.OnBleDidInitializeEvent -= HandleOnBleDidInitializeEvent;
			myBLEControllerEventHandler.OnBleDidInitializeErrorEvent -= HandleOnBleDidInitializeErrorEvent;
		}
	}
}