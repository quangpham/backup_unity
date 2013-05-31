using UnityEngine;
using System.Collections;

public class MainViewContainerController : MonoBehaviour {
	public int MenuLevelCount {get; set;} 
	
	/*
	public MainViewContainerController() {
		this.MenuLevelCount = 10;
	}
	*/
	
	public void OnAddSubView()
	{
		this.MenuLevelCount++;
	}
}
