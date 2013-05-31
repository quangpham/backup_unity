using UnityEngine;
using System.Collections;

public class ProductViewController : UIViewController {

	public UIPanel logoHeaderPanel;
	public UIPanel productImagePanel;
	public UIPanel productDescriptionPanel;
	public UIPanel productDataPanel;
	
	protected override void Start() {
		base.Start();
		doPanelClipping();
	}
	
	private void doPanelClipping() {
		float logoHeaderHeight = Screen.height * 0.075f;
		
		float scrContentHeightBottom = (Screen.height / 2) - navSliceHeight;
		float scrContentHeightTop = (Screen.height / 2) - logoHeaderHeight;
		float scrContentHeight = Screen.height - navSliceHeight - logoHeaderHeight;
		
		logoHeaderPanel.clipRange = new Vector4( 0.0f, (Screen.height / 2) - (logoHeaderHeight / 2), Screen.width, logoHeaderHeight);
		productImagePanel.clipRange = new Vector4( 0.0f, scrContentHeightTop / 2, Screen.width, scrContentHeightTop);
		
		productDescriptionPanel.clipRange = new Vector4( -(Screen.width / 4), -(scrContentHeightBottom / 2), Screen.width / 2, scrContentHeightBottom);
		productDataPanel.clipRange = new Vector4( Screen.width / 4, -(scrContentHeightBottom / 2), Screen.width / 2, scrContentHeightBottom);
	}
}
