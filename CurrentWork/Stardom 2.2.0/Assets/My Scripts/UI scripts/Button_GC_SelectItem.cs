using UnityEngine;
using System.Collections;

public class Button_GC_SelectItem : MonoBehaviour {

	public bool selected;
	

	void Start () {
	
	}
	
	void OnClick () {

		ToggleSelection();
	}

	public void ResetSelection(){
		selected = false;
		
		transform.GetChild(1).gameObject.SetActive(selected);
	}

	public void ToggleSelection(){
		if(!selected){
			GiftWallManager.Instance.SelectItem(gameObject);
			selected = true;
		}
		else{
			GiftWallManager.Instance.DeselectItem(gameObject);
			selected = false;
		}

		transform.GetChild(1).gameObject.SetActive(selected);

	}

	public void Select(){
		selected = true;
		
		GiftWallManager.Instance.SelectItem(gameObject);
		transform.GetChild(1).gameObject.SetActive(selected);
	}

	public void Deselect(){
		selected = false;

		GiftWallManager.Instance.DeselectItem(gameObject);
		transform.GetChild(1).gameObject.SetActive(selected);
	}


}
