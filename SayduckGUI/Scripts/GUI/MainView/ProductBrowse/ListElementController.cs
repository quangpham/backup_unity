using UnityEngine;
using System.Collections;
using System;

public delegate void ActionButtonDelegate(string elementId, ListElementController.ListType type);

public class ListElementController : PanelController {
	
	public static event ActionButtonDelegate ActionButtonPressedEvent;
	
	public UITexture thumbnail;
	public UISlicedSprite thumbnailBg;
	public UILabel thumbnailLabel;
	public UILabel titleText;
	public UILabel descriptionText;
	public UISlicedSprite bgSprite;
	
	public ListType type { get; set; }
	public string elementId;
	
	public enum ListType {
		Category,
		SubCategory,
		Product
	};
	
	//void Start() {
	//	Init();
	//}
	
	protected override void Init() {
		thumbnailLabel.text = "";
		
		// Retina code
		if (AppGUISettings.IS_RETINA) {
			bgSprite.transform.localScale = new Vector3(Screen.width, 250f, 1f);
			//titleText.FontSize *= 2;
			//descriptionText.FontSize *= 2;
			//thumbnailLabel.FontSize *= 2;
			thumbnailBg.transform.localScale = new Vector3(thumbnailBg.transform.localScale.x * 2f, thumbnailBg.transform.localScale.y * 2f, 1f);
			//thumbnailLabel.MaxWidthPixels *= 2;
		} else {
			bgSprite.transform.localScale = new Vector3(Screen.width, 125f, 1f);
		}
		
		base.Init();
		
		//spinner.transform.parent = panelAnchor.transform;
		UIAnchor anchor = spinner.GetComponent<UIAnchor>();
		anchor.panelContainer = null;
		anchor.widgetContainer = thumbnailBg;
		
		NGUITools.AddWidgetCollider(gameObject);
	}
	
	public void ActionButtonPressed() {
		Debug.Log("ListElementController: ActionButtonPressed() on " + this.titleText.text);
		
		if (ActionButtonPressedEvent != null) {
			ActionButtonPressedEvent(this.elementId, this.type);
		}
	}
	
	protected override IEnumerator LoadContent(Action onComplete) {
		yield return new WaitForSeconds( UnityEngine.Random.Range(0.75f, 1.25f)); // simulate loading
		
		thumbnailLabel.text = "thumbnail not available";
		
		onComplete();
		
		yield return null;
	}
	
}
