using UnityEngine;
using System.Collections;
using System;

public class PanelController : MonoBehaviour {
	
	public GameObject loadingSpinnerPrefab;
	public GameObject panelAnchor;
	
	protected GameObject spinner;
	
	void Start() {
		Init();
	}
	
	protected virtual void Init() {
		spinner = (GameObject)Instantiate(loadingSpinnerPrefab);
		spinner.transform.parent = panelAnchor.transform;
		UIAnchor anchor = spinner.AddComponent<UIAnchor>();
		anchor.panelContainer = GetComponent<UIPanel>();
		spinner.GetComponent<UISprite>().MakePixelPerfect();
		
		/*
		StartCoroutine(LoadContent( () => {
			Destroy(spinner);
		}));
		*/
	}
	
	protected virtual IEnumerator LoadContent(Action onComplete) {
		yield return null;
	}
	
	/*
	public void Enable () {
		UIPanel topPanel = GetComponent<UIPanel>();
		if (topPanel != null) {
			topPanel.enabled = true;
		}
		
		UIPanel[] panels = GetComponentsInChildren<UIPanel>();
		foreach (UIPanel panel in panels) {
			panel.enabled = true;
		}
	}
	
	public void Disable() {
		UIPanel topPanel = GetComponent<UIPanel>();
		if (topPanel != null) {
			topPanel.enabled = false;
		}
		
		UIPanel[] panels = GetComponentsInChildren<UIPanel>();
		foreach (UIPanel panel in panels) {
			panel.enabled = false;
		}
	}
	
	public void Destroy() {
		Destroy(this.gameObject);
	}
	*/
}

