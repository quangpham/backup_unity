using UnityEngine;
using System.Collections;
using System;

public class ListHeaderPanelController : PanelController {
	
	public UITexture contentImage;
	public UITexture partnerLogo;
	public UILabel contentLabel;
	
	protected override void Init () {
		// retina
		if (AppGUISettings.IS_RETINA) {
			//contentLabel.FontSize *= 2;
		}
		
		base.Init();
	}
	
	protected override IEnumerator LoadContent(Action onComplete) {
		
		yield return new WaitForSeconds(1.0f); // Simulate loading
		
		Texture2D logoTexture = DemoContentServer.Instance.homePageLogos[1];
		
		partnerLogo.mainTexture = logoTexture;
		partnerLogo.MakePixelPerfect();
		
		Texture2D contentTexture = DemoContentServer.Instance.homePagePictures[1];
		contentImage.mainTexture = contentTexture;
		contentImage.MakePixelPerfect();
		
		// resize textures if non-retina display (only scales the GameObject at the moment)
		if (!AppGUISettings.IS_RETINA) {
			partnerLogo.transform.localScale = new Vector3(logoTexture.width / 2, logoTexture.height / 2, 0f);
		}
		
		// scale image to fit the panel
		UIPanel panel = GetComponent<UIPanel>();
		float panelClippingX = panel.clipRange.z;
		float panelClippingY = panel.clipRange.w;
		float scaleMultX = panelClippingX / contentImage.transform.localScale.x;
		float scaleMultY = panelClippingY / contentImage.transform.localScale.y;
		if (scaleMultX > scaleMultY)
			contentImage.transform.localScale = new Vector3(contentTexture.width * scaleMultX, contentTexture.height * scaleMultX, 0f);
		else
			contentImage.transform.localScale = new Vector3(contentTexture.width * scaleMultY, contentTexture.height * scaleMultY, 0f);
		
		
		// Need to set the pivot here as it's not exposed when no texture present in the editor
		partnerLogo.pivot = UIWidget.Pivot.TopLeft;
		
		contentLabel.text = DemoContentServer.Instance.homePageProductNames[1];
		
		onComplete();
		
		yield return null;
	}
}
