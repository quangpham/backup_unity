using UnityEngine;
using System.Collections;

public class ProductBrowsePanelController : MonoBehaviour {//PanelController {
	
	/*
	public GameObject browseListPrefab;
	public GameObject CategoryImagePrefab;
	
	public TweenPosition tweenPositionEnter;
	public TweenPosition tweenPositionExit;
	
	public GameObject currentBrowseList { get; set; }
	public GameObject currentCategoryImage { get; set; }
	
	public Texture2D[] demoImages;
	
	public State state { get; set; }
	
	public enum State {
		categoryState,
		subCategoryState,
		productsState
	};
	
	void OnEnable() {
		tweenPositionEnter.from = new Vector3(Screen.width, 0f, 0f);
		tweenPositionExit.to = new Vector3(-Screen.width, 0f, 0f);
		
		currentBrowseList = (GameObject)Instantiate(browseListPrefab);
		currentBrowseList.name = "CategoryList";
		currentBrowseList.transform.parent = this.gameObject.transform;
		currentBrowseList.transform.localPosition = new Vector3(0f, 0f, 0f); // TODO: make procedural
		currentBrowseList.transform.localScale = Vector3.one;
		
		currentCategoryImage = (GameObject)Instantiate(CategoryImagePrefab);
		currentCategoryImage.transform.parent = this.gameObject.transform;
		currentCategoryImage.transform.localPosition = new Vector3(0f, 0f, 0f); // TODO: make procedural
		currentCategoryImage.transform.localScale = Vector3.one;
		
		state = State.categoryState; // Default to category state
	}
	
	void OnDisable() {

	}
	
	public void initDemoSampleData() {
		// Sample data
		Debug.Log("Init Sample Category data");
		currentBrowseList.GetComponent<BrowseListController>().initList("Category", 7);
		currentCategoryImage.GetComponent<CategoryImageController>().image.mainTexture = demoImages[0];
	}
	
	public void doNewBrowseList(MainViewController.View currentView) {
		// list products in the selected category
		GameObject newBrowseList = (GameObject)Instantiate(browseListPrefab);
		newBrowseList.transform.parent = this.gameObject.transform;
		newBrowseList.transform.localScale = Vector3.one;
		
		if (currentView == MainViewController.View.CategoryListView) {
			Debug.Log("Creating new product list");
			newBrowseList.name = "ProductList";
			newBrowseList.transform.localPosition = new Vector3(Screen.width, 0f, 0f);
			newBrowseList.GetComponent<BrowseListController>().initList("Product", 25); // Sample data - ONLY DEMO!
			
			currentBrowseList.GetComponent<BrowseListController>().AnimateExit(true);
			newBrowseList.GetComponent<BrowseListController>().AnimateEnter(true);
		} else {
			Debug.Log("Creating new category list");
			newBrowseList.name = "CategoryList";
			newBrowseList.transform.localPosition = new Vector3(-Screen.width, 0f, 0f);
			newBrowseList.GetComponent<BrowseListController>().initList("Category", 7); // Sample data - ONLY DEMO!
			
			currentBrowseList.GetComponent<BrowseListController>().AnimateEnter(false);
			newBrowseList.GetComponent<BrowseListController>().AnimateExit(false);
		}
		
		currentBrowseList = newBrowseList;
	}
	
	public void doNewCategoryImage(bool forward, int demoindex) {
		GameObject newCategoryImage = (GameObject)Instantiate(CategoryImagePrefab);
		newCategoryImage.transform.parent = this.gameObject.transform;
		newCategoryImage.transform.localScale = Vector3.one;
		
		newCategoryImage.GetComponent<CategoryImageController>().image.mainTexture = demoImages[demoindex];
		
		if (forward) {
			newCategoryImage.transform.localPosition = new Vector3(Screen.width, 0f, 0f);
			
			currentCategoryImage.GetComponent<CategoryImageController>().AnimateExit(forward);
			newCategoryImage.GetComponent<CategoryImageController>().AnimateEnter(forward);		
		} else {
			newCategoryImage.transform.localPosition = new Vector3(-Screen.width, 0f, 0f);
			
			currentCategoryImage.GetComponent<CategoryImageController>().AnimateEnter(forward);
			newCategoryImage.GetComponent<CategoryImageController>().AnimateExit(forward);
		}
		
		currentCategoryImage = newCategoryImage;
	}
	
	public void AnimateEnter(bool forward) {
		if (forward) {
			tweenPositionEnter.eventReceiver = null;
			tweenPositionEnter.callWhenFinished = "";
		} else {
			tweenPositionEnter.eventReceiver = this.gameObject;
			tweenPositionEnter.callWhenFinished = "Destroy";
		}
		tweenPositionEnter.Play(forward);
	}
	
	public void AnimateExit(bool forward) {
		if (!forward) {
			tweenPositionExit.eventReceiver = null;
			tweenPositionExit.callWhenFinished = "";
		} else {
			tweenPositionExit.eventReceiver = this.gameObject;
			tweenPositionExit.callWhenFinished = "Destroy";
		}
		tweenPositionExit.Play(forward);
	}
	*/
}
