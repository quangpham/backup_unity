using UnityEngine;
using System.Collections;
using System;

public class SponsoredPanelController : PanelController {

	public UITexture contentImage;
	public UITexture partnerLogo;
	public UILabel contentHeaderLabel;
	public UILabel contentDescriptionLabel;
	
	protected override void Init() {
		// retina
		if (AppGUISettings.IS_RETINA) {
			//contentHeaderLabel.FontSize *= 2;
			//contentDescriptionLabel.FontSize *= 2;
		}
		
		UIPanel panel = GetComponent<UIPanel>();
		float panelClippingX = panel.clipRange.z;
		//contentHeaderLabel.MaxWidthPixels = (int)(panelClippingX * 0.95f);
		//contentDescriptionLabel.MaxWidthPixels = (int)(panelClippingX * 0.95f);
		
		base.Init();
	}
	
	protected override IEnumerator LoadContent(Action onComplete) {
		yield return new WaitForSeconds(0.75f); // Simulate loading
		
		Texture2D logoTexture = DemoContentServer.Instance.sponsoredLogo;
		
		partnerLogo.mainTexture = logoTexture;
		partnerLogo.MakePixelPerfect();
		
		Texture2D contentTexture = DemoContentServer.Instance.sponsoredPicture;
		contentImage.mainTexture = contentTexture;
		contentImage.MakePixelPerfect();
		
		// resize textures if non-retina display (only scales the GameObject at the moment)
		if (!AppGUISettings.IS_RETINA) {
			partnerLogo.transform.localScale = new Vector3(logoTexture.width / 2, logoTexture.height / 2, 0f);
			//contentImage.transform.localScale = new Vector3(contentTexture.width / 2, contentTexture.height / 2, 0f);
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
		partnerLogo.pivot = UIWidget.Pivot.BottomRight;
		
		contentHeaderLabel.text = DemoContentServer.Instance.sponsoredHeader;
		contentDescriptionLabel.text = DemoContentServer.Instance.sponsoredDescription;
		contentHeaderLabel.MakePixelPerfect();
		contentDescriptionLabel.MakePixelPerfect();
		
		onComplete();
		
		yield return null;
	}
	
}
