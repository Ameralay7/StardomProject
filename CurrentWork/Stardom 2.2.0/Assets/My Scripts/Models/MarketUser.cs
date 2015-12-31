using UnityEngine;
using System.Collections;

public class MarketUser {

	public string fbID;
	public string kiiID;
	public string name;
	public int price;
	public Texture profilePic;
	public int onlineNow;

	public MarketUser(){
		fbID = "";
		kiiID = "";
		name = "";
		price = 0;
		onlineNow = 0;
	}

	public MarketUser (string anFbID, string aKiiID, string aName, int aPrice, int isOnlineNow){

		fbID = anFbID;
		kiiID = aKiiID;
		name = aName;
		price = aPrice;
		onlineNow = isOnlineNow;
	}
}
