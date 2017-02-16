namespace BLEFramework.Unity{
    
	using UnityEngine;	
	using System.Collections;
	using System.Runtime.InteropServices;


	public class myBLEController{

		public static bool InitBLEFramework (){
			bool result = false;
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if  UNITY_ANDROID
			if (Application.platform == RuntimePlatform.Android){
				using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
					using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
						using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
							using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
								result = androidPlugin.Call<bool>("_InitBLEFramework");
							}
						}
					}
				}
			}
			#endif

			return result;
		}

		public static void ScanForPeripherals (){
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if  UNITY_ANDROID
			if (Application.platform == RuntimePlatform.Android){
				using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
					using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
						using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
							using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
								androidPlugin.Call("_ScanForPeripherals");
							}
						}
					}
				}
			}
			#endif
		}

		public static bool IsDeviceConnected (){
			bool result = false;
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if  UNITY_ANDROID
			if (Application.platform == RuntimePlatform.Android){
				using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
					using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
						using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
							using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
								result = androidPlugin.Call<bool>("_IsDeviceConnected");
							}
						}
					}
				}
			}
			#endif

			return result;
		}

		public static bool SearchDeviceDidFinish (){
			bool result = false;
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if  UNITY_ANDROID
			if (Application.platform == RuntimePlatform.Android){
				using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
					using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
						using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
							using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
								result = androidPlugin.Call<bool>("_SearchDeviceDidFinish");
							}
						}
					}
				}
			}
			#endif

			return result;
		}

		public static string GetListOfDevices (){
			string result = "";
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if  UNITY_ANDROID
			if (Application.platform == RuntimePlatform.Android){
				using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
					using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
						using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
							using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
								result = androidPlugin.Call<string>("_GetListOfDevices");
							}
						}
					}
				}
			}
			#endif

			return result;
		}

		public static string GetPairedDevices (){
			string result = "";
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if  UNITY_ANDROID
			//if (Application.platform == RuntimePlatform.Android){
				using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
					using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
						using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
							using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
								result = androidPlugin.Call<string>("_GetPairedDevices");
							}
						}
					}
				}
			//}
			#endif

			return result;
		}
		
		public static bool ConnectPeripheral(string peripheralID){
			bool result = false;
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if UNITY_ANDROID
			using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
				using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
					using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
						using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
							result = androidPlugin.Call<bool>("_ConnectPeripheral", peripheralID);
						}
					}
				}
            }
			#endif
			
			return result;
		}
			
		public static void SendData(string data){
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if UNITY_ANDROID
			using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
				using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
					using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
						using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
							androidPlugin.Call("_SendData", data);
						}
					}
				}
            }
			#endif
		}


		/*
		public static string SendData(){
			string result = "";
			// We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
			#if UNITY_ANDROID
			using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
				using (AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")){
					using (AndroidJavaClass bleFrameworkClass = new AndroidJavaClass("com.hapticvest.david.ble_framework2.MainActivity")){
						using (AndroidJavaObject androidPlugin = bleFrameworkClass.CallStatic<AndroidJavaObject>("getInstance", currentActivity)){
							result = androidPlugin.Call<string>("_SendData");
						}
					}
				}
			}
			#endif

			return result;
		}
		*/
	}
}