using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupList_GC_itemsChooser : MonoBehaviour {

	private UIPopupList popupList;
	
	public string searchBy_code;

	public List <GameObject> itemsMenuChoices;

	private int lastMenuIndex;
	
	void Start () {
		popupList = GetComponent<UIPopupList> ();
		
		EventDelegate.Add(popupList.onChange, ChangeItemsMenu);
		lastMenuIndex = 0;
	}
	

	void ChangeItemsMenu(){

		itemsMenuChoices[lastMenuIndex].GetComponent<TweenPosition>().Toggle();
		int popupIndex = popupList.items.IndexOf(popupList.value);
		itemsMenuChoices[popupIndex].GetComponent<TweenPosition>().Toggle();
		lastMenuIndex = popupIndex;
	}

}
