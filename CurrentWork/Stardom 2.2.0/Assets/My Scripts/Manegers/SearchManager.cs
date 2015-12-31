using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


public class SearchManager : MonoBehaviour {
	
	public static SearchManager Instance;
	
	public UIPopupList [] FilterPopUpLists;
	
	public string [] FilterPopUpsSelections;
	
	
	
	void Awake(){
		Instance = this;
	}
	
	void Start () {
		
		FilterPopUpsSelections = new string[] {"Any", "Any", "Any", "Online"};
	}
	
	
	public void InitCurrentPopupsSelections(){
		for(int i = 0; i<FilterPopUpLists.Length;i++){
			if(FilterPopUpLists[i].value.Contains("Any")){
				FilterPopUpsSelections[i] = "Any";
			}
			else{
				FilterPopUpsSelections[i] = FilterPopUpLists[i].value;
				Util.Log(i + " "+ FilterPopUpLists[i].value);
			}
			
		}
		
	}
	
    //public void FilterSearch(){
    //    InitCurrentPopupsSelections ();
		
    //    List<KiiClause> myClauseList = new List<KiiClause> ();
		
    //    for(int i=0;i<FilterPopUpsSelections.Length;i++){
    //        if(FilterPopUpsSelections[i]!= "Any"){
    //            myClauseList.Add(QueryTextData.CLAUSES_LIST[System.Array.IndexOf(QueryTextData.SEARCH_TEXT_LIST, FilterPopUpsSelections[i])]);
    //            Util.Log("rarar "+ QueryTextData.CLAUSES_LIST[System.Array.IndexOf(QueryTextData.SEARCH_TEXT_LIST, FilterPopUpsSelections[i])]);
    //        }
    //    }
    //    Util.Log("myClauseList.Count: " + myClauseList.Count+"");
    //    if(myClauseList.Count == 0){
    //        MarketOfUsersManager.Instance.RetrieveUnSortedBucketData ("MarketUsers", null, 10);
    //    }
    //    else if(myClauseList.Count == 1){
    //        MarketOfUsersManager.Instance.RetrieveUnSortedBucketData ("MarketUsers", myClauseList[0], 10);
    //    }
    //    else{
			
    //        Util.Log("ameraa "+myClauseList.ToArray().Length);
    //        KiiClause myClause = KiiClause.And(myClauseList.ToArray());
    //        MarketOfUsersManager.Instance.RetrieveUnSortedBucketData ("MarketUsers", myClause, 10);
    //    }
    //}
	
	
	
	
}
