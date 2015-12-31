using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class UsersProfileManager : MonoBehaviour {

	public static UsersProfileManager Instance;
	
	public static Dictionary<string, string> profile = null;

	private bool onKiiCallback = false;
	
	public UILabel userName;
	public UITexture userProfilePic;
	public UILabel userPrice;
	public UISprite userOn_offSprite;
	
	public UILabel kiiResultLabel;
	
	public string fbID;
	
	//string meQueryString = "/v2.0/me?fields=id,first_name,gender,friends.limit(100).fields(first_name,id,picture.width(128).height(128)),invitable_friends.limit(100).fields(first_name,id,picture.width(128).height(128))";

	public MarketUser user;

	void Awake () {
		Instance = this;

		//GetComponent<UIGrid>()
	}
	
	public void FillUserData(MarketUser mu){
		userName.text = mu.name;
		userPrice.text = mu.price.ToString();
		userProfilePic.mainTexture = mu.profilePic;
		if(mu.onlineNow == 0){
			userOn_offSprite.spriteName = "offline";
			HiringManager.Instance.ChangeHiringButton(false);
		}
		else{
			userOn_offSprite.spriteName = "online";
			HiringManager.Instance.ChangeHiringButton(true);
		}

		fbID = mu.fbID;
		user = mu;
		HiringManager.Instance.userOnline = mu.onlineNow == 1 ? true : false;
		HiringManager.Instance.UpdateHiringData(mu.kiiID, false);
		//userKiiID = mu.kiiID;
		//HiringManager.Instance.UpdateHiringData (mu.kiiID, true);

	}
}
