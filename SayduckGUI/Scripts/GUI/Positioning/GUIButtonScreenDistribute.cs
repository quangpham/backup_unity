using UnityEngine;
using System.Collections;

public class GUIButtonScreenDistribute : MonoBehaviour {

	public GameObject[] buttons;
		
	void OnEnable() {
		StartCoroutine(refreshButtons());
		
		OrientationChangeController.OrientationChangedEvent += handleOrientationChangedEvent;
	}
	
	void OnDisable() {
		OrientationChangeController.OrientationChangedEvent -= handleOrientationChangedEvent;
	}
	
	private IEnumerator refreshButtons() {
		yield return new WaitForEndOfFrame();
		
		int screenW = Screen.width;
		int div = screenW / buttons.Length;
		float halfScreen = screenW / 2;
		
		for (int i = 0; i < buttons.Length; i++) {
			float posX = -halfScreen + (div * i) + (div / 2);
			
			if (AppGUISettings.IS_RETINA) {
				buttons[i].transform.localPosition = new Vector3(posX, buttons[i].transform.localPosition.y * 2, buttons[i].transform.localPosition.z);
			} else {
				buttons[i].transform.localPosition = new Vector3(posX, buttons[i].transform.localPosition.y, buttons[i].transform.localPosition.z);
			}
			
			buttons[i].GetComponentInChildren<UIWidget>().MakePixelPerfect();
		}
	}
	
	private void handleOrientationChangedEvent() {
		StartCoroutine(refreshButtons());
	}
	
}
