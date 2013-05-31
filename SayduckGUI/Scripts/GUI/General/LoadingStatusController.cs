using UnityEngine;
using System.Collections;

public class LoadingStatusController : MonoBehaviour {

	public UISprite spinner;
	
	void OnEnable() {
		spinner.MakePixelPerfect();
	}
	
}
