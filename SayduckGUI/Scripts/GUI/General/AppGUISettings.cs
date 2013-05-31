using UnityEngine;
using System.Collections;

public class AppGUISettings : MonoBehaviour {
	
	public UIRoot uiRoot;
	
	public GameObject arViewGUI_SD;
	public GameObject arViewGUI_HD;
	
	public UIAtlas referenceAtlas;
	public UIAtlas sdAtlas;
	public UIAtlas hdAtlas;
	
	public bool autoOrientGUI;
	public static bool AUTO_ORIENT_GUI;
	
	public static bool IS_RETINA;
	
	void OnEnable() {
		AUTO_ORIENT_GUI = autoOrientGUI;
		
		uiRoot.manualHeight = Screen.height;
		
		if (Screen.height > 1200) {
			Debug.Log ("Using Retina GUI");
			Debug.Log("Manual height set at: " + uiRoot.manualHeight);
			IS_RETINA = true;
			
			referenceAtlas.replacement = hdAtlas;
		} else {
			Debug.Log ("Using Standard GUI");
			IS_RETINA = false;
			
			referenceAtlas.replacement = sdAtlas;
		}
		
	}
	
	
}
