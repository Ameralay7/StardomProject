using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class OnlineOfflineManager : MonoBehaviour {

	public static OnlineOfflineManager Instance;
	public bool ImOnline;

	public UISprite on_offSprite;

	void Awake(){
		Instance = this;

		string eval = "";
		eval += "function OnApplicationQuit()";
		eval += "{";
		eval += "   GetUnity().SendMessage('" + name + "', 'OnApplicationQuit', '');";
		eval += "   return true;";
		eval += "}";
		eval += "window.onbeforeunload = OnApplicationQuit;";
		Application.ExternalEval(eval);
	}

	// Use this for initialization
	void Start () {
		ImOnline = true;
		Invoke("ChangeStatusAfter", 90);
	}


	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(IsInvoking("ChangeStatusAfter")){
				CancelInvoke("ChangeStatusAfter");
			}
			ImOnline = true;
			on_offSprite.spriteName = "online";
			Invoke("ChangeStatusAfter", 90);
			///QueryHelper.SaveMyCurrentStatus (1);
		}
	}

	void ChangeStatusAfter(){
		ImOnline = false;
		on_offSprite.spriteName = "offline";
		///QueryHelper.SaveMyCurrentStatus (0);

	}

	void OnApplicationQuit(){
		ChangeStatusAfter();
	}

}
