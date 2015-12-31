using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiftWallManager : MonoBehaviour {

	public static GiftWallManager Instance;

	public List<GameObject> cardItems;

	public UISprite CardBG;
	public Transform itemsSpawn;

	public GameObject giftCardItemPrefab;

	public List<GameObject> selectedItems;

	public int itemsCount;
	public Transform GiftCardPanel;



	void Awake () {
		Instance = this;

	}

	void Start(){
		selectedItems = new List<GameObject>();
	}
	
	public void SetBackGround (string bgName) {
		CardBG.spriteName = bgName;
	}

	public void CreateItemImage(string imageName, GameObject clone){

		GameObject item;
		if(!clone){
			item = Instantiate(giftCardItemPrefab, itemsSpawn.position, itemsSpawn.rotation) as GameObject;

			item.GetComponent<UISprite>().spriteName = imageName;
			item.GetComponent<UISprite>().MakePixelPerfect();
			item.GetComponent<UISprite>().depth = itemsCount+2;
			item.transform.GetChild(0).GetComponent<UISprite>().depth = itemsCount+3;
			item.transform.GetChild(1).GetComponent<UISprite>().depth = itemsCount+2;
		}
		else{
			item = Instantiate(clone, itemsSpawn.position, itemsSpawn.rotation) as GameObject;
			item.GetComponent<Button_GC_SelectItem>().ResetSelection();
		}


		item.transform.parent = itemsSpawn.parent;
		item.transform.position = itemsSpawn.position;
		item.transform.rotation = itemsSpawn.rotation;
		item.transform.localScale = new Vector3(1, 1, 1);

		cardItems.Add(item);

		itemsCount++;

	}

	public void SelectItem(GameObject item){
		if(selectedItems.Count>0){
			GameObject selection;
			if(selectedItems[0].transform.childCount == 2){
				selection = GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity) as GameObject;
				selection.transform.parent = selectedItems[0].transform;
				selection.transform.position = Vector3.zero;

			}
			else{
				selection = selectedItems[0].transform.GetChild(2).gameObject;

			}

			item.transform.parent = selection.transform;
			item.GetComponent<UIDragObject>().target = selectedItems[0].transform;
		}

		selectedItems.Add(item);


	}

	public void DeselectItem(GameObject item){
		if(selectedItems.Count>1 && selectedItems[0] == item){
			selectedItems[1].transform.parent = GiftCardPanel;
			item.transform.GetChild(2).parent = selectedItems[1].transform;

			for(int i = 1; i< selectedItems.Count ;i++){
				selectedItems[i].GetComponent<UIDragObject>().target = selectedItems[1].transform;
			}

		}

		item.transform.parent = GiftCardPanel;
		item.GetComponent<UIDragObject>().target = item.transform;
		selectedItems.Remove(item);
		//item.transform.GetChild(1).gameObject.SetActive(false);
	}

	public void DeselectALL(){
		for(int i = 0; i<selectedItems.Count ; i++){
			selectedItems[i].GetComponent<Button_GC_SelectItem>().Deselect();
			i--;
			//selectedItems.RemoveAt(i);
		}

	}

	public void SendToBack(){
		for(int i = 0; i<selectedItems.Count ; i++){
			int depth = selectedItems[i].GetComponent<UISprite>().depth;
			depth -= 1;
			if(depth < 2){
				depth =2;
			}

			selectedItems[i].GetComponent<UISprite>().depth = depth;
			selectedItems[i].transform.GetChild(0).GetComponent<UISprite>().depth = depth+1;
			selectedItems[i].transform.GetChild(1).GetComponent<UISprite>().depth = depth;
		}
	}

	public void SendToFront(){
		for(int i = 0; i<selectedItems.Count ; i++){
			int depth = selectedItems[i].GetComponent<UISprite>().depth;
			depth += 1;

			selectedItems[i].GetComponent<UISprite>().depth = depth;
			selectedItems[i].transform.GetChild(0).GetComponent<UISprite>().depth = depth+1;
			selectedItems[i].transform.GetChild(1).GetComponent<UISprite>().depth = depth;
		}
	}

	public void DeleteItem(){
		for(int i = 0; i<selectedItems.Count ; i++){
			cardItems.Remove(selectedItems[i]);
			Destroy( selectedItems[i]);

			selectedItems.RemoveAt(i);
			itemsCount --;
			i--;
		}
	}

	public void CloneItem(){
		for(int i = 0; i<selectedItems.Count ; i++){
			string itemName = selectedItems[i].GetComponent<UISprite>().name;
			CreateItemImage(itemName, selectedItems[i]);

		}
	}

	public void ResetItem(){
		for(int i = 0; i<selectedItems.Count ; i++){
			selectedItems[i].GetComponent<UISprite>().MakePixelPerfect();

		}
	}

	public void SameSize(){
		for(int i = 0; i<selectedItems.Count ; i++){
			selectedItems[i].GetComponent<UISprite>().width = selectedItems[0].GetComponent<UISprite>().width;
			selectedItems[i].GetComponent<UISprite>().height = selectedItems[0].GetComponent<UISprite>().height;
			
		}
	}

	public void CenterItem(){
		for(int i = 0; i<selectedItems.Count ; i++){
			selectedItems[i].transform.position = itemsSpawn.position;
			
		}
	}

	public void SelectAll(){
		for(int i=0; i<cardItems.Count ; i++){
			cardItems[i].GetComponent<Button_GC_SelectItem>().Select();
			//SelectItem(cardItems[i]);
		}
	}

	public void Clear(){
		for(int i=0; i<cardItems.Count ; i++){
			Destroy( cardItems[i]);
		
		}
		selectedItems.Clear();
	}

	public void Effect(){
		for(int i = 0; i<selectedItems.Count ; i++){
			selectedItems[i].GetComponent<TweenScale>().Toggle();
			
		}
	}
}
