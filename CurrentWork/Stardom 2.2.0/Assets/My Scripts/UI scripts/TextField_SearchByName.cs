using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class TextField_SearchByName : MonoBehaviour {

	public UIInput textField;
	private bool canSearch;
	// Use this for initialization
	void Start () {
		canSearch = true;
		textField = GetComponent<UIInput> ();
		//EventDelegate.Add(textField.onSubmit, SearchNameOf);
		//EventDelegate.Add(textField.onChange, SearchNameOf);
	}
	
    //void SearchNameOf () {

    //    Util.Log (textField.value);
    //    KiiClause nameClause = KiiClause.Or (KiiClause.StartsWith ("firstName", textField.value.ToLower()), KiiClause.StartsWith ("lastName", textField.value.ToLower()));

    //    MarketOfUsersManager.Instance.RetrieveUnSortedBucketData ("MarketUsers", nameClause, 10);
    //}


    //void onCahngeSearchNameOf(){

    //    if(canSearch){

    //        Util.Log (textField.value);
    //        KiiClause nameClause = KiiClause.Or (KiiClause.StartsWith ("firstName", textField.value.ToLower()), KiiClause.StartsWith ("lastName", textField.value.ToLower()));
    //        MarketOfUsersManager.Instance.RetrieveUnSortedBucketData ("MarketUsers", nameClause, 10);
    //        canSearch = false;
    //        Invoke("ChangeCanSearch", 1f);
    //    }
    //}

    //void ChangeCanSearch(){
    //    Util.Log ("setting cansearch with true");
    //    canSearch = true;
    //}
}
