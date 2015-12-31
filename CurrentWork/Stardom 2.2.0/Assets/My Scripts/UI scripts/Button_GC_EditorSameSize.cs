using UnityEngine;
using System.Collections;

public class Button_GC_EditorSameSize : MonoBehaviour {

	void Start () {
	
	}
	
	void OnClick () {
		GiftWallManager.Instance.SameSize();
	}
}
