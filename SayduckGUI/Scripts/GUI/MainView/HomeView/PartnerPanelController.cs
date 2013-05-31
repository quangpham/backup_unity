using UnityEngine;
using System.Collections;
using System;

public class PartnerPanelController : PanelController {
	
	public string partnerId { get; set; }
	
	public UITexture partnerLogo;
	public UILabel header;
	public UILabel description;
	public UISlicedSprite bgSprite;
	
	private bool hasInit = false;
	
	protected override void Init() {
		// retina
		if (AppGUISettings.IS_RETINA) {
			//header.FontSize *= 2;
			//description.FontSize *= 2;
		}
		
		base.Init();
	}
	
	protected override IEnumerator LoadContent(Action onComplete) {
		yield return new WaitForSeconds(1.0f); // Simulate loading
		
		Texture2D logoTexture = DemoContentServer.Instance.getPartnerLogo();
		
		partnerLogo.mainTexture = logoTexture;
		partnerLogo.MakePixelPerfect();
		
		// resize textures if non-retina display (only scales the GameObject at the moment)
		if (!AppGUISettings.IS_RETINA) {
			partnerLogo.transform.localScale = new Vector3(logoTexture.width / 2, logoTexture.height / 2, 0f);
		}
		
		// Need to set the pivot here as it's not exposed when no texture present in the editor
		partnerLogo.pivot = UIWidget.Pivot.TopLeft;
		
		header.text = DemoContentServer.Instance.getPartnerHeader();
		description.text = DemoContentServer.Instance.getPartnerDescription();
		
		onComplete();
		
		yield return null;
	}
}
