using UnityEngine;
using System.Collections;

public delegate void OrientationChangedDelegate();
public delegate void OrientationChangedToDelegate(DeviceOrientation orientation);

public class OrientationChangeController : MonoBehaviour {
	
	public static event OrientationChangedDelegate OrientationChangedEvent; 
	public static event OrientationChangedToDelegate OrientationChangedToEvent;
	
	private DeviceOrientation currentOrientation = DeviceOrientation.Portrait;
	
	void LateUpdate() {
		DeviceOrientation newOrientation = Input.deviceOrientation;
		if (newOrientation != DeviceOrientation.FaceDown && newOrientation != DeviceOrientation.FaceUp && newOrientation != DeviceOrientation.Unknown) { 
			if (newOrientation != currentOrientation) {
				if (OrientationChangedToEvent != null) {
					OrientationChangedToEvent(newOrientation);
				}
				
				if (OrientationChangedEvent != null) {
					OrientationChangedEvent();
				}
				
				currentOrientation = newOrientation;
			}
		}
	}
}
