using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
 
public class FirstViewUi : EZData.Context
{
	#region Collection RootUIMenuItem
	private readonly EZData.Collection<UIMenuItem> _privateRootUIMenuItem = new EZData.Collection<UIMenuItem>(false);
	public EZData.Collection<UIMenuItem> RootUIMenuItem { get { return _privateRootUIMenuItem; } }
	#endregion

	public void BackButtonClick()
	{
		UIHelper.Instance.slideBack();
	}

}
 
public class SayduckViewModel : MonoBehaviour
{
	public NguiRootContext View;
	public FirstViewUi Context;
 
	void Awake ()
	{
		Context = new FirstViewUi ();
		View.SetContext (Context);
	}
	
	void Start () 
	{
		StartCoroutine("GetMenuData");
	}
	
	IEnumerator GetMenuData ()
	{
		WWW www = new WWW ("http://dl.dropboxusercontent.com/u/14181582/_temp/sayduckuiconfig.js");
		float elapsedTime = 0.0f;
		
		while (!www.isDone) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= 10.0f)
				break;
			yield return null;  
		}
		
		if (!www.isDone || !string.IsNullOrEmpty (www.error)) 
		{
			Debug.LogError (string.Format ("Fail Whale!\n{0}", www.error));
			yield break;

		}
		
		string response = www.text;
		
		IDictionary uiconfig = (IDictionary)Json.Deserialize (response);
		
		if (uiconfig["menu-items"] != null) {
			
			UIHelper.Instance.addFirstListView();
			//UIHelper.Instance.addChildView(1);
			
			foreach (IDictionary item in (IList)uiconfig["menu-items"]) 
			{
				UIMenuItem menuItem = new UIMenuItem();
				menuItem.AddMenuItemData(item);
				Context.RootUIMenuItem.Add(menuItem);
			}
		}
	}
}
