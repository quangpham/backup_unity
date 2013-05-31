using UnityEngine;
using System.Collections;

public class MainUIPanelController : MonoBehaviour {
	
	void OnEnable() {
		if (AppGUISettings.IS_RETINA) {
			//bgSprite.transform.localScale = new Vector3(bgSprite.transform.localScale.x, bgSprite.transform.localScale.y * 2, bgSprite.transform.localScale.z);
			UIWidget[] widgets = GetComponentsInChildren<UIWidget>();
			
			foreach (UIWidget w in widgets) {
				if (w.transform.localScale.x == Screen.width) {
					w.transform.localScale = new Vector3(w.transform.localScale.x, w.transform.localScale.y * 2, w.transform.localScale.z);
				} else {
					w.transform.localScale = new Vector3(w.transform.localScale.x * 2, w.transform.localScale.y * 2, w.transform.localScale.z);
				}
			}
		}
	}
	
}
