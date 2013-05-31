using UnityEngine;
using System.Collections;

public class GUISliceScreenScale : MonoBehaviour {
	
	public bool matchX = true;
	public bool matchY = false;
	
	void OnEnable() {
		StartCoroutine(refreshScale());
		
		OrientationChangeController.OrientationChangedEvent += handleOrientationChangedEvent;
	}
	
	void OnDisable() {
		OrientationChangeController.OrientationChangedEvent -= handleOrientationChangedEvent;
	}

	private IEnumerator refreshScale() {
		yield return new WaitForEndOfFrame();
		
		if (matchX) {
			transform.localScale = new Vector3(Screen.width, transform.localScale.y, transform.localScale.z);
		}
		
		if (matchY) {
			transform.localScale = new Vector3(transform.localScale.x, Screen.height, transform.localScale.z);
		}
	}
	
	private void handleOrientationChangedEvent() {
		StartCoroutine(refreshScale());
	}
	
}
