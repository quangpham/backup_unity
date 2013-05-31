using UnityEngine;
using System.Collections;

public class MainViewContainerController : MonoBehaviour {
	public int MenuLevelCount {get; set;} 
	
	public int CurrentPosition {get; set;} 
	
	public void OnAddSubView()
	{
		this.MenuLevelCount++;
	}
	
	public void OnSlideNext ()
	{
		CurrentPosition++;
		TweenPosition.Begin(gameObject, 0.5f, new Vector3 (-Screen.width*CurrentPosition, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z));
	}
	
	public void OnSlideBack ()
	{
		CurrentPosition--;
		if (CurrentPosition<0) CurrentPosition = 0;
		TweenPosition.Begin(gameObject, 0.5f, new Vector3 (-Screen.width*CurrentPosition, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z));	}
}
