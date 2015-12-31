using UnityEngine;
using System.Collections;

public class Button_GC_EditorClear: MonoBehaviour {

	void Start () {
	
	}
	
	void OnClick () {
		GiftWallManager.Instance.Clear();
	}
}
