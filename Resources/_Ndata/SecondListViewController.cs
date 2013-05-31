using UnityEngine;
using System.Collections;

public class SecondListViewController : UIViewController {
	
	public GameObject appBackground;
	public UIPanel listPanel;
	public UIPanel listDraggablePanel;
	
	protected override void Start() {
		base.Start();
		doPanelClipping();
	}
	
	private void doPanelClipping() {
		float logoHeaderHeight = Screen.height * 0.075f;
		
		float scrContentHeightTop = (Screen.height / 3) - logoHeaderHeight;
		float scrContentHeightBottom = ((Screen.height / 3) * 2) - navSliceHeight;
		float scrContentHeight = Screen.height - navSliceHeight - logoHeaderHeight;
		
		appBackground.gameObject.transform.localScale = new Vector3(Screen.width, Screen.height, 0);
		listPanel.clipRange = new Vector4( 0.0f, -(Screen.height / 2) + navSliceHeight + (scrContentHeightBottom / 2), Screen.width, scrContentHeightBottom);
		//listPanel.clipRange = new Vector4(0,0,200,200);
		Debug.Log (listPanel.clipRange.ToString());
		listDraggablePanel.clipRange = new Vector4( 0.0f, -(Screen.height / 2) + navSliceHeight + (scrContentHeightBottom / 2), Screen.width, scrContentHeightBottom);
	}
}
