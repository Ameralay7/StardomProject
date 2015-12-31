using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiftWallReaderWriter : MonoBehaviour {

	public static GiftWallReaderWriter Instance;

	public GameObject GC_itemPrefab;



	//temp for test;

	public string test = "flag_brazil%bar_gift$92$72$-92$68$2$1%red_notify$52$54$41$-62$3$1";
	public GameObject giftWallPanel;
	public UISprite GC_BG;

	void Awake () {
		Instance = this;
	}

	void Start(){
		GiftStringToCard(test);
		//Invoke("GiftCardToString" , 14);
	}

	//Readinggg__________________________________________________________
	public string GiftCardToString () {
		List<GameObject> CardItems = GiftWallManager.Instance.cardItems;
		string GC_bgName = GiftWallManager.Instance.CardBG.spriteName;


		//bgName,itemName_sizeX_sizeY_posX_posY_depth_animation,...
		string GiftWallString = GC_bgName +"%";

		for(int i=0;i< CardItems.Count; i++){

			UISprite itemSprite = CardItems[i].GetComponent<UISprite>();
			Transform itemTransform = CardItems[i].transform;

			GiftWallString += 	itemSprite.spriteName +"$"+
					itemSprite.width + "$" +
					itemSprite.height + "$" +
					itemTransform.localPosition.x + "$" + 
					itemTransform.localPosition.y + "$" +
					itemSprite.depth+ "$"+
					GetAnimationEffectString(CardItems[i]);
				
			if(i < CardItems.Count-1){
				GiftWallString += "%";
			}

		}

		Debug.Log(GiftWallString);

		return GiftWallString;
	}

	//will be modified (for remaining effects)
	public string GetAnimationEffectString (GameObject onTarget){
		if(onTarget.GetComponent<TweenScale>()){
			return "1";
		}
		else if(onTarget.GetComponent<TweenPosition>()){
			return "2";
		}
		return "0";
	}

	//Writtingggg __________________________________________

	public void GiftStringToCard(string giftWallString){
		List<GameObject> CardItems;

		string [] giftWallStringList = giftWallString.Split('%');

		GC_BG.spriteName = giftWallStringList[0];

		for(int i=1; i< giftWallStringList.Length; i++){
			string [] itemsDetailsList = giftWallStringList[i].Split('$');

			CreatNewItem(itemsDetailsList[0],
			             itemsDetailsList[1],
			             itemsDetailsList[2],
			             itemsDetailsList[3],
			             itemsDetailsList[4],
			             itemsDetailsList[5],
			             itemsDetailsList[6]);

		}
		
		
		//bgName,itemName_sizeX_sizeY_posX_posY_depth_animation,..

	}

	public GameObject CreatNewItem(string spriteName, string sizeX, string sizeY, string posX, string posY, string depth, string anim){
		GameObject item = Instantiate(GC_itemPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		item.transform.parent = giftWallPanel.transform;

		item.GetComponent<UISprite>().spriteName = spriteName;
		item.GetComponent<UISprite>().width = int.Parse(sizeX);
		item.GetComponent<UISprite>().height = int.Parse(sizeY);
		Vector3 position = new Vector3(float.Parse(posX), float.Parse(posY), 0);
		item.transform.localPosition = position;

		item.GetComponent<UISprite>().depth = int.Parse(depth);

		string effect = GetStringEffectAnimation(anim);
		if(effect == "TweenScale"){
			item.GetComponent<TweenScale>().enabled = true;
		}

		return item;
	}

	public string GetStringEffectAnimation (string effectName){
		if(effectName == "1"){
			return "TweenScale";
		}
		else if(effectName == "2"){
			return "TweenPosition";
		}
		return "none";
	}


}
