using UnityEngine;
using System.Collections;

public class Button_GC_EditorDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		GiftWallManager.Instance.DeleteItem();
	}
}
