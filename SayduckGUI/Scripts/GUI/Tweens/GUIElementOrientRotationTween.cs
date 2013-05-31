using UnityEngine;
using System.Collections;

public class GUIElementOrientRotationTween : UITweener {
	
	public Vector3 from;
	public Vector3 to;

	Transform mTrans;

	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }
	public Quaternion rotation { get { return cachedTransform.localRotation; } set { cachedTransform.localRotation = value; } }
	
	void OnEnable() {
		base.OnEnable();
		
		method = UITweener.Method.EaseOut;
		duration = 0.5f;
		
		if (AppGUISettings.AUTO_ORIENT_GUI) {
			this.enabled = false;
		} else {
			OrientationChangeController.OrientationChangedToEvent += handleOrientationChangedToEvent;
		}
	}
	
	void OnDisable() {
		if (!AppGUISettings.AUTO_ORIENT_GUI) {
			OrientationChangeController.OrientationChangedToEvent -= handleOrientationChangedToEvent;
		}
			
	}
	
	override protected void OnUpdate (float factor, bool isFinished) {
		cachedTransform.localRotation = Quaternion.Slerp(Quaternion.Euler(from), Quaternion.Euler(to), factor);
	}

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenRotation Begin (GameObject go, float duration, Quaternion rot) {
		TweenRotation comp = UITweener.Begin<TweenRotation>(go, duration);
		comp.from = comp.rotation.eulerAngles;
		comp.to = rot.eulerAngles;
		return comp;
	}
	
	private void handleOrientationChangedToEvent(DeviceOrientation newOrientation) {
		from = transform.localRotation.eulerAngles;
		
		if (newOrientation == DeviceOrientation.LandscapeRight) {
			to = new Vector3(0f, 0f, 90f);
		}
		
		if (newOrientation == DeviceOrientation.LandscapeLeft) {
			to = new Vector3(0f, 0f, -90f);
		}
		
		if (newOrientation == DeviceOrientation.Portrait) {
			to = new Vector3(0f, 0f, 0f);
		}
		
		if (newOrientation == DeviceOrientation.PortraitUpsideDown) {
			to = new Vector3(0f, 0f, -180f);
		}
		
		Play(true);
	}
	
}
