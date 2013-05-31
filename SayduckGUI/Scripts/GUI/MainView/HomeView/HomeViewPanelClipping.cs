using UnityEngine;
using System.Collections;

public class HomeViewPanelClipping : MonoBehaviour {
		
	public bool topLeft;
	public bool topRight;
	public bool center;
	public bool bottomLeft;
	public bool bottomRight;
	
	public int navSliceHeight; // Multiplier needed for retina
	
	void OnEnable() {
		// Retina
		Debug.Log("Clipping checking for retina");
		if (AppGUISettings.IS_RETINA) {
			navSliceHeight *= 2;
			Debug.Log("Clipping with navSliceHeight: " + navSliceHeight);
		}
		
		int scrHeight = Screen.height - navSliceHeight;
		
		UIPanel panel = GetComponent<UIPanel>();
		if (topLeft) {
			panel.clipRange = new Vector4( -((Screen.width / 2) / 2), (scrHeight / 3), (Screen.width / 2), (scrHeight / 3));
		} else if (topRight) {
			panel.clipRange = new Vector4(((Screen.width / 2) / 2), (scrHeight / 3), (Screen.width / 2), scrHeight / 3);
		} else if (bottomLeft) {
			panel.clipRange = new Vector4(-((Screen.width / 2) / 2), -(scrHeight / 3), (Screen.width / 2), scrHeight / 3);
		} else if (bottomRight) {
			panel.clipRange = new Vector4(((Screen.width / 2) / 2), -(scrHeight / 3), (Screen.width / 2), scrHeight / 3);
		} else if (center) {
			panel.clipRange = new Vector4(0, 0, (Screen.width), (scrHeight/3));
		}
	}
}
