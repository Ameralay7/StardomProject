using UnityEngine;
using System.Collections;

public class PopupList_Chooser : MonoBehaviour {

	private UIPopupList popupList;

	public string searchBy_code;

	void Start () {
		popupList = GetComponent<UIPopupList> ();

		//EventDelegate.Add(popupList.onChange, SearchBy);
	}



	/*

	void SearchBy(){

		if(popupList.value == "Any Price"){
			MarketOfUsersManager.Instance.marketAllUsersGrid.SetActive(true);
			MarketOfUsersManager.Instance.marketSearchUsersGrid.SetActive(false);
			Util.Log("alllll");
		}
		else{

			MarketOfUsersManager.Instance.marketAllUsersGrid.SetActive(false);
			MarketOfUsersManager.Instance.marketSearchUsersGrid.SetActive(true);

			string [] temp = popupList.value.Split('-');
			MarketOfUsersManager.Instance.RetrieveSearchData (temp[0], temp[1]);

			Util.Log("tempat .. "+ temp[0]+temp[1]);


		}
	}
	*/


	

}
