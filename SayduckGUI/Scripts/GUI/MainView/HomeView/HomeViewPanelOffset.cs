using UnityEngine;
using System.Collections;

public class HomeViewPanelOffset : MonoBehaviour {

	void OnEnable() {
		if (AppGUISettings.IS_RETINA) {
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y * 2, transform.localPosition.z);
		}
	}
	
}
