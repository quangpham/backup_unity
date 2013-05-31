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
		
		GameObject view = (GameObject)Instantiate(Resources.Load("_Ndata/FirstListView"));
		view.transform.parent = mainViewContainer.transform;
		view.transform.localScale = new Vector3 (1,1,1);
		
		mainViewContainer.GetComponent<MainViewContainerController>().MenuLevelCount = 0;
	}
	
	public void addChildView ()
	{
		GameObject mainViewContainer = GameObject.Find("MainViewContainer");
		mainViewContainer.GetComponent<MainViewContainerController>().OnAddSubView();
		int childLevel = mainViewContainer.GetComponent<MainViewContainerController>().MenuLevelCount;
		
		GameObject view = (GameObject)Instantiate(Resources.Load("_Ndata/ChildListView"));
		view.name = "Child_" + childLevel.ToString();
		view.transform.parent = mainViewContainer.transform;
		view.transform.localScale = new Vector3 (1,1,1);
		view.transform.localPosition = new Vector3 (Screen.width*childLevel, view.transform.localPosition.y, view.transform.localPosition.z);
		
		string itemSourceBindingString = "RootUIMenuItem";
		for (int i = 0; i<childLevel; i++)
		{
			itemSourceBindingString += ".SelectedItem.SubMenuItems";
		}
		NguiItemsSourceBinding itemsSourceBinding = GameObject.Find("Child_" + childLevel.ToString() + "/PanelsParent/3.ListViewPanel/DraggablePanel/UIGrid").GetComponent<NguiItemsSourceBinding>();
		itemsSourceBinding.Path = itemSourceBindingString;
	}
}