using UnityEngine;
using System;
using System.Collections;

public class UIHelper : MonoBehaviour {
	
	private static UIHelper instance = null;
	
	private UIHelper ()
	{
	}
	
	public static UIHelper Instance {
		get {
			if (instance == null) {
				instance = new UIHelper ();
			}
			return instance;
		}
	}
	
	void Awake ()
	{
		instance = this;
	}

	public void addFirstListView ()
	{
		GameObject mainViewContainer = GameObject.Find("MainViewContainer");
		GameObject firstListView = (GameObject)Instantiate(Resources.Load("_Ndata/FirstListView"));
		firstListView.transform.parent = mainViewContainer.transform;
		firstListView.transform.localScale = new Vector3 (1,1,1);
	}
}