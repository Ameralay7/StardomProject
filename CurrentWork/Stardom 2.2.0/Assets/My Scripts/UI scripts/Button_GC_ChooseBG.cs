using UnityEngine;
using System.Collections;

public class Button_GC_ChooseBG : MonoBehaviour {

	public string bgName;

	void Start () {
	
	}
	
	void OnClick () {
		GiftWallManager.Instance.SetBackGround(bgName);
	}
}
