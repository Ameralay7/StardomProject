using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiftWallCard : MonoBehaviour {

	public UISprite GC_BG;

	void Start () {
	
	}

	/*
	public void CreateCard (string bgName, List<GameObject> CardItems, GameObject cardPrefab) {
		GC_BG.spriteName = bgName;

		GameObject item;
		for(int i =0; i < CardItems.Count; i++){
			item = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity) as GameObject;

			item.transform.parent = transform;
			item.transform.localPosition = CardItems[i].transform.localPosition;
			item.transform.rotation = CardItems[i].transform.rotation;
			item.transform.localScale = CardItems[i].transform.localScale;

			item.GetComponent<UISprite>().spriteName = CardItems[i].GetComponent<UISprite>().spriteName;
			item.GetComponent<UISprite>().depth = CardItems[i].GetComponent<UISprite>().depth;

			if(GiftWallReaderWriter.GetStringEffectAnimation())

		}
	}
	*/
}
