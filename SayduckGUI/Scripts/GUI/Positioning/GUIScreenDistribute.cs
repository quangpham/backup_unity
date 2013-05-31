using UnityEngine;
using System.Collections;

public class GUIScreenDistribute : MonoBehaviour {
	
	public int copyCount = 3;
	private int divider;
	
	private UISprite mainSprite;
	
	void OnEnable() {
		divider = copyCount + 1;
		mainSprite = GetComponentsInChildren<UISprite>()[0];
		createSprites();
		StartCoroutine(refreshSprites());
		
		OrientationChangeController.OrientationChangedEvent += handleOrientationChangedEvent;
	}
	
	void OnDisable() {
		OrientationChangeController.OrientationChangedEvent -= handleOrientationChangedEvent;
	}
	
	private void createSprites() {
		for (int i = 0; i < copyCount; i++) {
			UISprite sprite = NGUITools.AddChild<UISprite>(gameObject);
			sprite.name = mainSprite.name;
			sprite.atlas = mainSprite.atlas;
			sprite.spriteName = mainSprite.spriteName;
			sprite.pivot = mainSprite.pivot;
			sprite.MakePixelPerfect();
			sprite.depth = NGUITools.CalculateNextDepth(transform.parent.gameObject);
			
			NGUITools.Destroy(mainSprite.gameObject);
		}
	}
	
	private IEnumerator refreshSprites() {
		yield return new WaitForEndOfFrame();
		
		int screenW = Screen.width;
		int div = screenW / divider;
		
		UISprite[] sprites = GetComponentsInChildren<UISprite>();
		
		for (int i = 0; i < copyCount; i++) {
			float posX = (-screenW / 2) + ( div * (i + 1) );
			sprites[i].transform.localPosition = new Vector3(posX, sprites[i].transform.localPosition.y, sprites[i].transform.localPosition.z);
		}
	}
	
	private void handleOrientationChangedEvent() {
		StartCoroutine(refreshSprites());
	}
}
