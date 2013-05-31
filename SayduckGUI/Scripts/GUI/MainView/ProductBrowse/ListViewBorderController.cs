using UnityEngine;
using System.Collections;

public class ListViewBorderController : MonoBehaviour {
	
	public int borderSize; // Multiplier needed for retina
	
	private float navSliceHeight;
	
	// horizontal borders
	public GameObject borderTop;
	public GameObject borderHeaderLogoBottom;
	public GameObject borderHeaderImageBottom;
	public GameObject borderNavTop;
	
	// vertical borders
	public GameObject borderScreenLeft;
	public GameObject borderScreenRight;
	
	void Start() {
		navSliceHeight = GameObject.Find("BG_NavTab").transform.localScale.y;
		
		float logoHeaderHeight = Screen.height * 0.075f;
		
		float scrContentHeightTop = (Screen.height / 3) - logoHeaderHeight;
		float scrContentHeightBottom = ((Screen.height / 3) * 2) - navSliceHeight;
		float scrContentHeight = Screen.height - navSliceHeight - logoHeaderHeight;
		
		if (AppGUISettings.IS_RETINA) {
			borderSize *= 2; // multiply bordersize for retina
		}
		
		float scrHeight = Screen.height - navSliceHeight;
		
		borderTop.transform.localPosition = new Vector3(0f, Screen.height / 2, 0f);
		borderTop.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
			
		borderHeaderImageBottom.transform.localPosition = new Vector3(0f, (Screen.height / 2) - logoHeaderHeight - scrContentHeightTop, 0f);
		borderHeaderImageBottom.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
		
		
		//logoHeaderPanel.clipRange = new Vector4( 0.0f, (Screen.height / 2) - (logoHeaderHeight / 2), Screen.width, logoHeaderHeight);
		
		borderHeaderLogoBottom.transform.localPosition = new Vector3(0f, (Screen.height / 2) - logoHeaderHeight, 0f);
		borderHeaderLogoBottom.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
		
		borderNavTop.transform.localPosition = new Vector3(0f, -(scrHeight / 2) + (navSliceHeight / 2), 0f);
		borderNavTop.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
		
		borderScreenLeft.transform.localPosition = new Vector3(-(Screen.width / 2), navSliceHeight/2, 0f);
		borderScreenLeft.transform.localScale = new Vector3(borderSize, Screen.height - navSliceHeight, 0f);
		
		borderScreenRight.transform.localPosition = new Vector3((Screen.width / 2), navSliceHeight/2, 0f);
		borderScreenRight.transform.localScale = new Vector3(borderSize, Screen.height - navSliceHeight, 0f);
	}
}
