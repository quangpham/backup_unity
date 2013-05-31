using UnityEngine;
using System.Collections;

public class IntroTextWrapper : MonoBehaviour {

	void OnEnable() {
		UILabel label = GetComponent<UILabel>();
		
		float xOffset = Screen.width * 0.02f;
		float wrapWidth = (Screen.width / 2) - xOffset*2;
		
		transform.localPosition = new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y, transform.localPosition.z);
		//label.MaxWidthPixels = (int)wrapWidth;
	}
	
}
