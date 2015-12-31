using UnityEngine;
using System.Collections;

public class Button_GC_CreatItem : MonoBehaviour {

	public string imageName;

	void Start () {
	
	}
	
	void OnClick () {
		GiftWallManager.Instance.CreateItemImage(imageName, null);

	}
}
