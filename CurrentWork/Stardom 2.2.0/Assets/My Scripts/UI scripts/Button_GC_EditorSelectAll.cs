using UnityEngine;
using System.Collections;

public class Button_GC_EditorSelectAll: MonoBehaviour {

	void Start () {
	
	}
	
	void OnClick () {
		GiftWallManager.Instance.SelectAll();
	}
}
