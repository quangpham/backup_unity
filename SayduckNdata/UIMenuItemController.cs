using UnityEngine;
using System.Collections;

public class UIMenuItemController : MonoBehaviour {

	public UISlicedSprite bgSprite;
	
	void Start() {
		Vector3 currentScale = bgSprite.transform.localScale;
		bgSprite.transform.localScale = new Vector3(Screen.width, currentScale.y, currentScale.z);
		NGUITools.AddWidgetCollider(gameObject);
	}
}
