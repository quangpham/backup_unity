using UnityEngine;
using System.Collections;

public class FeaturedPanelBorderController : MonoBehaviour {
	
	public int borderSize; // Multiplier needed for retina
	public int navSliceHeight; // Multiplier needed for retina
	
	// horizontal borders
	public GameObject borderTop;
	public GameObject borderSponsoredTop;
	public GameObject borderSponsoredBottom;
	public GameObject borderNavTop;
	
	// vertical borders
	public GameObject borderScreenLeft;
	public GameObject borderScreenRight;
	public GameObject borderScreenCenterTop;
	public GameObject borderScreenCenterBottom;
	
	void Start() {
		if (AppGUISettings.IS_RETINA) {
			borderSize *= 2; // multiply bordersize for retina
			navSliceHeight *= 2; // multiply navSliceHeight for retina
		}
		
		int scrHeight = Screen.height - navSliceHeight;
		
		borderTop.transform.localPosition = new Vector3(0f, Screen.height / 2, 0f);
		borderTop.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
			
		borderSponsoredTop.transform.localPosition = new Vector3(0f, ((scrHeight / 3) / 2) + (navSliceHeight / 2), 0f);
		borderSponsoredTop.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
		
		borderSponsoredBottom.transform.localPosition = new Vector3(0f, -((scrHeight / 3) / 2) + (navSliceHeight / 2), 0f);
		borderSponsoredBottom.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
		
		borderNavTop.transform.localPosition = new Vector3(0f, -(scrHeight / 2) + (navSliceHeight / 2), 0f);
		borderNavTop.transform.localScale = new Vector3(Screen.width, borderSize, 0f);
		
		borderScreenLeft.transform.localPosition = new Vector3(-(Screen.width / 2), navSliceHeight/2, 0f);
		borderScreenLeft.transform.localScale = new Vector3(borderSize, Screen.height - navSliceHeight, 0f);
		
		borderScreenRight.transform.localPosition = new Vector3((Screen.width / 2), navSliceHeight/2, 0f);
		borderScreenRight.transform.localScale = new Vector3(borderSize, Screen.height - navSliceHeight, 0f);
		
		borderScreenCenterTop.transform.localPosition = new Vector3(0f, (Screen.height / 2), 0f);
		borderScreenCenterTop.transform.localScale = new Vector3(borderSize, (scrHeight / 3), 0f);
		
		borderScreenCenterBottom.transform.localPosition = new Vector3(0f, -(scrHeight / 2) + (navSliceHeight / 2), 0f);
		borderScreenCenterBottom.transform.localScale = new Vector3(borderSize, (scrHeight / 3), 0f);
	}
}
