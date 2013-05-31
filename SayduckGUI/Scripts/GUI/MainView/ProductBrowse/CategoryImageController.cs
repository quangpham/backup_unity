using UnityEngine;
using System.Collections;

public class CategoryImageController : MonoBehaviour {

	public UITexture image;
	
	public TweenPosition tweenPositionEnter;
	public TweenPosition tweenPositionExit;
	
	void OnEnable() {
		tweenPositionEnter.from = new Vector3(Screen.width, 0f, 0f);
		tweenPositionExit.to = new Vector3(-Screen.width, 0f, 0f);
	}
	
	public void AnimateEnter(bool forward) {
		if (forward) {
			tweenPositionEnter.eventReceiver = null;
			tweenPositionEnter.callWhenFinished = "";
		} else {
			tweenPositionEnter.eventReceiver = this.gameObject;
			tweenPositionEnter.callWhenFinished = "Destroy";
		}
		//Debug.Log("Playing BrowseList tween enter: " + forward);
		tweenPositionEnter.Play(forward);
	}
	
	public void AnimateExit(bool forward) {
		if (!forward) {
			tweenPositionExit.eventReceiver = null;
			tweenPositionExit.callWhenFinished = "";
		} else {
			tweenPositionExit.eventReceiver = this.gameObject;
			tweenPositionExit.callWhenFinished = "Destroy";
		}
		//Debug.Log("Playing BrowseList tween exit: " + forward);
		tweenPositionExit.Play(forward);
	}
	
	public void Destroy() {
		Destroy(this.gameObject);
	}
	
}
