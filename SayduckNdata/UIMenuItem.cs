using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class Tag : EZData.Context
{
	#region Property Name
	private readonly EZData.Property<string> _privateNameProperty = new EZData.Property<string>();
	public EZData.Property<string> NameProperty { get { return _privateNameProperty; } }
	public string Name
	{
	get    { return NameProperty.GetValue();    }
	set    { NameProperty.SetValue(value); }
	}
	#endregion
}

public class UIMenuItem : EZData.Context
{
	#region Property Text
	private readonly EZData.Property<string> _privateTextProperty = new EZData.Property<string>();
	public EZData.Property<string> TextProperty { get { return _privateTextProperty; } }
	public string Text
	{
	get    { return TextProperty.GetValue();    }
	set    { TextProperty.SetValue(value); }
	}
	#endregion
	
	#region Property HeaderImage
	private readonly EZData.Property<string> _privateHeaderImageProperty = new EZData.Property<string>();
	public EZData.Property<string> HeaderImageProperty { get { return _privateHeaderImageProperty; } }
	public string HeaderImage
	{
	get    { return HeaderImageProperty.GetValue();    }
	set    { HeaderImageProperty.SetValue(value); }
	}
	#endregion
	
	#region Collection Tags
	private readonly EZData.Collection<Tag> _privateTags = new EZData.Collection<Tag>(false);
	public EZData.Collection<Tag> Tags { get { return _privateTags; } }
	#endregion
	
	public void AddMenuItemData (IDictionary item)
	{
		if (item["text"] != null) 
		{
			this.Text = (string)item["text"];
		}
		
		if (item["header-image"] != null) 
		{
			this.HeaderImage = (string)item["header-image"];
		}
		
		if (item["tags"] != null)
		{
			foreach (string tag in (IList)item["tags"]) 
			{
				this.Tags.Add (new Tag {Name = tag});
			}
		
		}
		
		if (item["menu-items"] != null)
		{
			foreach (IDictionary submenu  in (IList)item["menu-items"]) 
			{
				UIMenuItem submenuItem = new UIMenuItem();
				submenuItem.AddMenuItemData(submenu);
				this.SubMenuItems.Add(submenuItem);
			}
		}
		
	}
	
	#region Collection SubMenuItems
	private readonly EZData.Collection<UIMenuItem> _privateSubMenuItems = new EZData.Collection<UIMenuItem>(false);
	public EZData.Collection<UIMenuItem> SubMenuItems { get { return _privateSubMenuItems; } }
	#endregion
	
	public void UIMenuItemClick ()
	{
		//GameObject.Find("RootPanelController").GetComponent<RootPanelController>().SlideNext();
	}

}