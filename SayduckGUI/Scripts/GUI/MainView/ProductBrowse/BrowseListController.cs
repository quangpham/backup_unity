using UnityEngine;
using System.Collections;

public class BrowseListController : MonoBehaviour {
	
	public UIGrid productListGrid;
	public GameObject listElementPrefab;
	
	void Start() {
		
		if (AppGUISettings.IS_RETINA) {
			productListGrid.cellHeight *= 2;
		}
		
		initList("Test", 15);
	}
	
	// SAMPLE DATA
	public void initList(string prefix, int count) {
		for (int i = 0; i < count; i++) {
			
			GameObject newListElement = (GameObject)Instantiate(listElementPrefab);
			
			NGUITools.Destroy(newListElement.GetComponent<UIPanel>());
			ListElementController listElementController = newListElement.GetComponent<ListElementController>();
			listElementController.titleText.text = "Element " + prefix + "_" + i;
			listElementController.descriptionText.text = "Description for element " + prefix + "_" + i;
			newListElement.transform.parent = productListGrid.transform;
			newListElement.transform.localScale = Vector3.one;
			newListElement.transform.localPosition = new Vector3(0f, 0f, -1f);
			
			//BoxCollider collider = NGUITools.AddWidgetCollider(newListElement);
			
			newListElement.AddComponent<UIDragPanelContents>();
			
			// Color
			UISlicedSprite bgSprite = newListElement.GetComponent<ListElementController>().bgSprite;
			if (i % 2 == 0) {
				bgSprite.color = new Color(0.35f, 0.35f, 0.35f);
			} else {
				bgSprite.color = new Color(0.5f, 0.5f, 0.5f);
			}
		}
		
		productListGrid.Reposition();
	}
}
