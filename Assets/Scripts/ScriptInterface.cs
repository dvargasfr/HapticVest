using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Manage the actions on the interface (actives toggles and modifies texts)
 * 
 * Assigned to Canvas under Main Camera
 */
public class ScriptInterface : MonoBehaviour {

	static GameObject toggleFire;
	static Toggle moveFire;

	public static int nTouches;

	public static GameObject fire;
	public static GameObject rightfront;
	public static GameObject rightback;
	public static GameObject leftfront;
	public static GameObject leftback;
	public static GameObject rightside;
	public static GameObject leftside;
	public static GameObject textFire;
	public static GameObject textMoveFire;
	public static GameObject textConnected;
	public static GameObject textDisconnected;
	public static GameObject imageTick;
	public static GameObject imageCross;
	public static GameObject sliderVest;

	public static Text statustxt;

	// Use this for initialization
	void Start () {
		statustxt = GameObject.FindGameObjectWithTag ("statustxt").GetComponent<Text>();
		textConnected = GameObject.FindGameObjectWithTag ("textconnected");
		textConnected.GetComponent<Text> ().enabled = false;
		imageTick = GameObject.FindGameObjectWithTag ("imagetick");
		imageTick.GetComponent<RawImage> ().enabled = false;
		textDisconnected = GameObject.FindGameObjectWithTag ("textdisconnected");
		imageCross = GameObject.FindGameObjectWithTag ("imagecross");
		toggleFire = GameObject.FindGameObjectWithTag ("togglefire");
		textFire = GameObject.FindGameObjectWithTag ("textfire");
		textMoveFire = GameObject.FindGameObjectWithTag ("textmovefire");
		moveFire = toggleFire.GetComponent<Toggle> ();
		sliderVest = GameObject.FindGameObjectWithTag ("slidervest");
		fire = GameObject.Find("Fire");
		rightfront = GameObject.Find("abdomen_bottom_right");
		rightback = GameObject.Find("back_bottom_right");
		leftfront = GameObject.Find("abdomen_bottom_left");
		leftback = GameObject.Find("back_bottom_left");
		rightside = GameObject.Find("side_right");
		leftside = GameObject.Find("side_left");
		moveFire.onValueChanged.AddListener (delegate {
			toggleFireValueChangedHandler (moveFire);
		});
	}

	// Toggle 'Move Fire'
	void toggleFireValueChangedHandler (Toggle toggletarget) {
		print("Toggle fuego cambiado");
		if (!toggletarget.isOn){
			fire.SendMessage ("ResetPosition");
			rightfront.SendMessage ("ResetColor");
			rightback.SendMessage ("ResetColor");
			leftfront.SendMessage ("ResetColor");
			leftback.SendMessage ("ResetColor");
			rightside.SendMessage ("ResetColor");
			leftside.SendMessage ("ResetColor");
		}
		fire.GetComponent<MoveFire> ().enabled = toggletarget.isOn;
		textFire.GetComponent<Text> ().enabled = toggletarget.isOn;
		textMoveFire.GetComponent<Text> ().enabled = toggletarget.isOn;
		//rightfront.GetComponent<Temperature> ().enabled = toggletarget.isOn;
		rightfront.GetComponent<TempFrontRight> ().enabled = toggletarget.isOn;
		//rightback.GetComponent<Temperature> ().enabled = toggletarget.isOn;
		rightback.GetComponent<TempBackRight> ().enabled = toggletarget.isOn;
		//leftfront.GetComponent<Temperature> ().enabled = toggletarget.isOn;
		leftfront.GetComponent<TempFrontLeft> ().enabled = toggletarget.isOn;
		//leftback.GetComponent<Temperature> ().enabled = toggletarget.isOn;
		leftback.GetComponent<TempBackLeft> ().enabled = toggletarget.isOn;
		rightside.GetComponent<Temperature> ().enabled = toggletarget.isOn;
		leftside.GetComponent<Temperature> ().enabled = toggletarget.isOn;
		sliderVest.GetComponent<Slider> ().enabled = !toggletarget.isOn;
	}

	// Update is called once per frame
	void Update () {
		if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
			Screen.orientation = ScreenOrientation.Landscape;
		}
	}
}
