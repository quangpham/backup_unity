using UnityEngine;
using System.Collections;

public class ListViewController : UIViewController {
	
	public UIPanel logoHeaderPanel;
	public UIPanel headerImagePanel;
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
		
		
		logoHeaderPanel.clipRange = new Vector4( 0.0f, (Screen.height / 2) - (logoHeaderHeight / 2), Screen.width, logoHeaderHeight);
		headerImagePanel.clipRange = new Vector4( 0.0f, (Screen.height / 2) - logoHeaderHeight - (scrContentHeightTop / 2), Screen.width, scrContentHeightTop);
		listPanel.clipRange = new Vector4( 0.0f, -(Screen.height / 2) + navSliceHeight + (scrContentHeightBottom / 2), Screen.width, scrContentHeightBottom);
		listDraggablePanel.clipRange = new Vector4( 0.0f, -(Screen.height / 2) + navSliceHeight + (scrContentHeightBottom / 2), Screen.width, scrContentHeightBottom);
	}
}
