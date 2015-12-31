using UnityEngine;
using System.Collections;

public class Button_ContentCollapse : MonoBehaviour {

	public int contentIndexNum;

	public bool isUser = false;
	//public GameObject activeSpriteGO;

	//private TweenScale activeSpriteTweener;

	void Start () {
		//activeSpriteTweener = GetComponentInChildren<TweenScale> ();
	}
	
	void OnClick () {
		if(!isUser){
			if(MiddleWindowCollapser.Instance.currentContentIndex!=contentIndexNum){

				MiddleWindowCollapser.Instance.ChangeCurrentContentTo (contentIndexNum);
			//	activeSpriteTweener.Toggle();
			}
		}
		else{
			if(MiddleWindowCollapser.Instance.userCurrentContentIndex!=contentIndexNum){
				
				MiddleWindowCollapser.Instance.UserChangeCurrentContentTo (contentIndexNum);
				//	activeSpriteTweener.Toggle();
			}
		}
	}
}
