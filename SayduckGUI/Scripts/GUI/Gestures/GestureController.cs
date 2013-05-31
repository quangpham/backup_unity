using UnityEngine;
using System.Collections;

public delegate void MenuShouldDisplayDelegate();
public delegate void MenuShouldHideDelegate();

public class GestureController : MonoBehaviour {
	
	public static event MenuShouldDisplayDelegate MenuShouldDisplayEvent; 
	public static event MenuShouldHideDelegate MenuShouldHideEvent;
	
	// Init touch controls
	void OnEnable() {
		FingerGestures.OnFingerSwipe += FingerGestures_OnSwipe;
	}
	
	// De-init touch controls
	void OnDisable() {
		FingerGestures.OnFingerSwipe -= FingerGestures_OnSwipe;
	}
	
	// Controls the display of the main menu
	void FingerGestures_OnSwipe(int fingerIndex, Vector2 startPos, FingerGestures.SwipeDirection direction, float velocity) {
		if (direction == FingerGestures.SwipeDirection.Up) {
			if (startPos.y < Screen.height * 0.25) {
				if (MenuShouldDisplayEvent != null) {
					MenuShouldDisplayEvent();
				}
			}
		}
		
		if (direction == FingerGestures.SwipeDirection.Down) {
			if (startPos.y < Screen.height * 0.25) {
				if (MenuShouldHideEvent != null) {
					MenuShouldHideEvent();
				}
			}
		}
		
		// Do this when DeviceOrientation.Portrait
		if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.Unknown) {
			if (direction == FingerGestures.SwipeDirection.Left) {
				// next & swipe left
			} else if (direction == FingerGestures.SwipeDirection.Right) {
				// previous & swipe right
			}
		}
		
		// Do this when DeviceOrientation.LandscapeLeft
		if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && startPos.y > Screen.height * 0.25) {
			if (direction == FingerGestures.SwipeDirection.Up) {
				// next & swipe left
			} else if (direction == FingerGestures.SwipeDirection.Down) {
				// previous & swipe right
			}
		}
		
		// Do this when DeviceOrientation.LandscapeRight
		if (Input.deviceOrientation == DeviceOrientation.LandscapeRight  && startPos.y > Screen.height * 0.25) {
			if (direction == FingerGestures.SwipeDirection.Up) {
				// next & swipe right
			} else if (direction == FingerGestures.SwipeDirection.Down) {
				// previous & swipe left
			}
		}
	}
}
