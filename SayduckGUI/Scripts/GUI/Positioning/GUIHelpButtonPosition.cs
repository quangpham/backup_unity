using UnityEngine;
using System.Collections;

public class GUIHelpButtonPosition : MonoBehaviour {
	
	void OnEnable() {
		StartCoroutine(refreshPosition());
		
		OrientationChangeController.OrientationChangedEvent += handleOrientationChangedEvent;
	}
	
	void OnDisable() {
		OrientationChangeController.OrientationChangedEvent -= handleOrientationChangedEvent;
	}
	
	private IEnumerator refreshPosition() {
		yield return new WaitForEndOfFrame();
		
		float posX = Screen.width * 0.9f;
		float posY = Screen.height * 0.9f;
		
		transform.localPosition = new Vector3(posX - (Screen.width / 2), posY, 0f);
	}
	
	private void handleOrientationChangedEvent() {
		StartCoroutine(refreshPosition());
	}
	
}
