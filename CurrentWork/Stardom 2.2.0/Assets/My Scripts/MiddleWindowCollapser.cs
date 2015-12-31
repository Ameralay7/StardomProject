using UnityEngine;
using System.Collections;

public class MiddleWindowCollapser : MonoBehaviour {

	public static MiddleWindowCollapser Instance;

	public GameObject [] midWinContentsList;
	public UISprite currentContentSprite;
	public int currentContentIndex;

	public GameObject [] userMidWinContentsList;
	public UISprite userCurrentContentSprite;
	public int userCurrentContentIndex;

	void Awake(){
		Instance = this;
		Util.Log("gatkom neelaaaa");
	}

	void Start () {
		currentContentIndex = 0;
		userCurrentContentIndex = 0;
	}
	
	public void ChangeCurrentContentTo(int targetIndex){
		midWinContentsList [currentContentIndex].GetComponent<Collapser> ().CollapseMe ();
		midWinContentsList [targetIndex].GetComponent<Collapser> ().CollapseMe ();
		currentContentIndex = targetIndex;
	}

	public void UserChangeCurrentContentTo(int targetIndex){
		userMidWinContentsList [userCurrentContentIndex].GetComponent<Collapser> ().CollapseMe ();
		userMidWinContentsList [targetIndex].GetComponent<Collapser> ().CollapseMe ();
		userCurrentContentIndex = targetIndex;
	}
}
