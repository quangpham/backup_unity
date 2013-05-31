using UnityEngine;
using System.Collections;

public class GUIMainNavPosition : MonoBehaviour {
	
	private bool hasInit = false;
	
	public UISprite navBGSprite;

	void OnEnable() {
		StartCoroutine(refreshPosition());
		
		OrientationChangeController.OrientationChangedEvent += handleOrientationChangedEvent;
	}
	
	void OnDisable() {
		OrientationChangeController.OrientationChangedEvent -= handleOrientationChangedEvent;
	}
	
	private IEnumerator refreshPosition() {
		yield return new WaitForEndOfFrame();
		
		if (!hasInit) {
			transform.localPosition = new Vector3(0f, -(navBGSprite.cachedTransform.localScale.y * 0.9f), 0f);
			hasInit = true;
		}
	}
	
	private void handleOrientationChangedEvent() {
		StartCoroutine(refreshPosition());
	}
	
}
