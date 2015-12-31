using UnityEngine;
using System.Collections;

public class Button_OnOffScreen : MonoBehaviour {

	
	public GameObject NextScreen;
	public GameObject CurrentScreen;
	
	void Start () {
		
	}
	
	void OnClick () {
		NextScreen.SetActive (true);
		CurrentScreen.SetActive (false);

		//MarketOfUsersManager.Instance.marketAllUsersGrid.GetComponentInParent<UIScrollView>().ResetPosition();
		//MarketOfUsersManager.Instance.marketAllUsersGrid.GetComponent<UIGrid> ().Reposition ();

	}
}
