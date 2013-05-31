using UnityEngine;
using System.Collections;

public class MainViewController : MonoBehaviour {
	
	public GameObject homeViewPanelPrefab;
	public GameObject listViewPanelPrefab;
	public GameObject productViewPanelPrefab;
	
	public GameObject UIAnchor;
	
	public GameObject currentViewPanel;
	public View currentView;
	
	public enum View {
		HomeView,
		CategoryListView,
		ProductListView,
		ProductView
	};
	
	void OnEnable() {
		// Instantiate HomeView at start
		currentViewPanel = (GameObject)Instantiate(homeViewPanelPrefab);
		currentViewPanel.transform.parent = UIAnchor.gameObject.transform;
		currentViewPanel.transform.localScale = Vector3.one;
		currentView = View.HomeView;
		
		// Register for events
		//FeaturedViewPanelController.BrowseCategoriesButtonPressedEvent += doBrowseCategories;
		
		ListElementController.ActionButtonPressedEvent += handleListElementActionButtonPressed;
	}
	
	void OnDisable() {
		// De-register for events
		//FeaturedViewPanelController.BrowseCategoriesButtonPressedEvent -= doBrowseCategories;
		
		ListElementController.ActionButtonPressedEvent -= handleListElementActionButtonPressed;
	}
	
	public void ViewWillChange() {
		//currentView = newView;
		
		Debug.Log("View will change to: " + currentView);
		
	}
	
	// Initial view of category browsing
	private void doBrowseCategories() {
		/*
		// Instantiate ProductBrowseView and animate it on screen
		GameObject productBrowsePanel = (GameObject)Instantiate(productBrowsePanelPrefab);
		productBrowsePanel.transform.parent = UIAnchor.transform;
		productBrowsePanel.transform.localPosition = new Vector3(Screen.width, 0f, 0f);
		productBrowsePanel.transform.localScale = Vector3.one;
		
		// Init sample data
		productBrowsePanel.GetComponent<ProductBrowsePanelController>().initDemoSampleData();
		
		// trigger tweens - should do this in the actual controller?
		productBrowsePanel.GetComponent<ProductBrowsePanelController>().AnimateEnter(true);
		
		currentView = View.CategoryBrowseView;
		currentViewPanel = productBrowsePanel;
		
		ViewWillChange();
		*/
	}
	
	// back button handler - decides which view 
	private void handleBackButtonPressed() {
		/*
		if (currentView == View.CategoryBrowseView) {
			Debug.Log("Navigating back to home screen");
			
			currentViewPanel.GetComponent<ProductBrowsePanelController>().AnimateEnter(false);
			GameObject featureViewPanel = GameObject.Find("FeatureViewPanel");
			featureViewPanel.GetComponent<FeaturedViewPanelController>().AnimateEnter();
			
			currentView = View.FeaturedView;
		} else if (currentView == View.ProductBrowseView) {
			Debug.Log("Navigating back to category state");
			
			// DEMO DATA
			currentViewPanel.GetComponent<ProductBrowsePanelController>().doNewBrowseList(currentView);
			currentViewPanel.GetComponent<ProductBrowsePanelController>().doNewCategoryImage(false, 0);
			
			currentView = View.CategoryBrowseView;
		} else if (currentView == View.ProductView) {
			// Stuff here
		}
		
		ViewWillChange();
		*/
	}
	
	// 
	private void handleListElementActionButtonPressed(string elementId, ListElementController.ListType type) {
		if (currentView == View.CategoryListView) {
			//currentViewPanel.GetComponent<ProductBrowsePanelController>().doNewBrowseList(currentView);
			//currentViewPanel.GetComponent<ProductBrowsePanelController>().doNewCategoryImage(true, 1);
			currentView = View.CategoryListView;
		}
	}
}
