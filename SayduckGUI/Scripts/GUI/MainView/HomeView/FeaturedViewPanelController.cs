using UnityEngine;
using System.Collections;

/*
public delegate void ARViewButtonDelegate();
public delegate void ProductViewButtonDelegate();
public delegate void BrowseCategoriesButtonDelegate();
*/
 
public class FeaturedViewPanelController :MonoBehaviour { //PanelController {

	/*
	public static event ARViewButtonDelegate ARViewButtonPressedEvent;
	public static event ProductViewButtonDelegate ProductViewButtonPressedEvent;
	public static event BrowseCategoriesButtonDelegate BrowseCategoriesButtonPressedEvent;
	
	public GameObject MainUIAnchor;
	
	public GameObject productBrowsePanelPrefab;
	public GameObject productInfoPanelPrefab;
	public TweenPosition tweenPosition;
	
	public GameObject[] featurePanels;
	
	void OnEnable() {
		tweenPosition.to = new Vector3(-Screen.width, 0f, 0f);
	}
	
	public void PanelDismissed() {		
		Disable();
	}
	
	public void PanelWillDisplay() {
		Enable();
	}
	
	public void gotoARView(string productId) {
		Debug.Log("FeaturedViewPanelController: goto3DView()");
		if (ARViewButtonPressedEvent != null) {
			ARViewButtonPressedEvent();
		}
	}
	
	public void gotoProductView(string productId) {
		Debug.Log("FeaturedViewPanelController: gotoProductView()");
		if (ProductViewButtonPressedEvent != null) {
			ProductViewButtonPressedEvent();
		}
	}
	
	public void BrowseCategoriesButtonPressed() {
		if (BrowseCategoriesButtonPressedEvent != null) {
			BrowseCategoriesButtonPressedEvent();
		}
		
		AnimateExit();
	}
	
	public void AnimateExit() {
		tweenPosition.eventReceiver = this.gameObject;
		tweenPosition.callWhenFinished = "PanelDismissed";
		tweenPosition.Play(true);
	}
	
	public void AnimateEnter() {
		tweenPosition.eventReceiver = null;
		tweenPosition.callWhenFinished = "";
		PanelWillDisplay();
		tweenPosition.Play(false);
	}
	*/
}
