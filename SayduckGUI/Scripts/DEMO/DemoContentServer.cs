using UnityEngine;
using System.Collections;

public class DemoContentServer : MonoBehaviour {
	
	public Texture2D[] homePagePictures;
	public Texture2D[] homePageLogos;
	public string[] homePageProductNames;
	
	public Texture2D sponsoredPicture;
	public Texture2D sponsoredLogo;
	public string sponsoredHeader;
	public string sponsoredDescription;
	
	public Texture2D partnerLogo;
	public string partnerHeader;
	public string partnerDescription;
	
	// Singleton instance of assetserver - only one per app
	private static DemoContentServer instance = null; 
	
	private DemoContentServer() {
		// nothing
	}
	
	public static DemoContentServer Instance {
		get {
			return instance;
		}
	}
	
	void Awake() {
		instance = this;
	}
	
	public Texture2D getPartnerLogo() {
		return partnerLogo;
	}
	
	public string getPartnerHeader() {
		return partnerHeader;
	}
	
	public string getPartnerDescription() {
		return partnerDescription;
	}
	
}
