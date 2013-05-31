using UnityEngine;
using System.Collections;

public class FadePanel : MonoBehaviour {
	
    public float duration = 1f;
	public bool fadeIn = true;
	
	public bool doFade = false;
	
    float mStart = 0f;
    UIWidget[] mWidgets;
 
    void Start () {
        mStart = Time.realtimeSinceStartup;
        mWidgets = GetComponentsInChildren<UIWidget>();
    }
 
    void Update () {
		if (doFade) {
	        float alpha = (duration > 0f) ? 1f - Mathf.Clamp01((Time.realtimeSinceStartup - mStart) / duration) : 0f;
	 
	        foreach (UIWidget w in mWidgets) {
	            Color c = w.color;
				if (fadeIn) c.a = 1-alpha;
	            else c.a = alpha;
	            w.color = c;
	        }
	        if (alpha == 0f) {
				doFade = false;
				//this.GetComponent<PanelController>().Disable();
			}
		}
    }
}