using UnityEngine;
using System.Collections;

public class UIViewController : MonoBehaviour {
	
	protected float navSliceHeight;
	
	// Use this for initialization
	protected virtual void Start () {		
		navSliceHeight = GameObject.Find("BG_NavTab").transform.localScale.y;
	}
	
	public void AnimateOn(bool fromScreenLeft) {
		
	}
	
	public void AnimateOff(bool toScreenLeft) {
		
	}
	
	public void Destroy() {
		Destroy(this.gameObject);
	}
	
}
