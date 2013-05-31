using UnityEngine;
using System.Collections;

public class FeaturePagePositionTween : UITweener {

	private Vector3 from;
	private Vector3 to;

	Transform mTrans;

	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }
	public Vector3 position { get { return cachedTransform.localPosition; } set { cachedTransform.localPosition = value; } }
	
	void OnEnable() {
		base.OnEnable();
		
		handleOrientationChanged();
		OrientationChangeController.OrientationChangedEvent += handleOrientationChanged;
	}
	
	void OnDisable() {
		OrientationChangeController.OrientationChangedEvent -= handleOrientationChanged;
	}
	
	void Start() {
		from = transform.localPosition;
		to = new Vector3(-Screen.width, 0f, 0f);
	}
	
	override protected void OnUpdate (float factor, bool isFinished) { cachedTransform.localPosition = from * (1f - factor) + to * factor; }
	
	private void handleOrientationChanged() {
		from = new Vector3(-Screen.width, 0f, 0f);
	}
	
	static public TweenPosition Begin (GameObject go, float duration, Vector3 pos) {
		Debug.Log("Begin FeaturePageTween");
		TweenPosition comp = UITweener.Begin<TweenPosition>(go, duration);
		comp.from = comp.position;
		comp.to = pos;
		return comp;
	}
	
	void Play(bool forward) {
		Debug.Log("Play FeaturePageTween");
		from = new Vector3(-Screen.width, 0f, 0f);
		Debug.Log("Updated screenshot tween from: " + from);
		base.Play(forward);
	}
}
