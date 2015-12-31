using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class ExperienceManager : MonoBehaviour {

	public static ExperienceManager Instance;

	public UISlider expBar;
	public int currentExp;

	void Awake () {
		Instance = this;
	}
	

	public void AddExp(int amount){
		currentExp += amount;

		
		///SaveKiiExperienceData();
		
	}
	

    //void SaveKiiExperienceData(){
    //    KiiBucket bucket = Kii.Bucket("Exp");
		
    //    if(!Utils.ValidateObjectID(KiiUser.CurrentUser.ID+"Exp")) {
    //        // ID not valid
    //        Util.Log("el zeft not valid");
    //    }
		
    //    KiiObject hiredUser = bucket.NewKiiObject(KiiUser.CurrentUser.ID+"Exp");
    //    hiredUser ["exp"] = currentExp;
		
    //    Util.Log ("Saving energy data...");
		
    //    hiredUser.SaveAllFields(true, (KiiObject obj, Exception e) => {
    //        if (e != null) {
				
    //            Util.LogError(e.ToString());
    //        }
    //        else {
    //            UpdateExpUI();
    //        }
    //    });
    //}
	
    //private void UpdateExpUI(){
    //    expBar.value = (float)currentExp/100;
    //}
	
	

    //public void LoadKiiExpData(string kiiID){
		
		
    //    KiiBucket bucket = Kii.Bucket ("Stats");
    //    KiiQuery query = new KiiQuery (KiiClause.Equals("_id", kiiID+"Exp"));
		
    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            Util.LogError ("el stats msh mowgoooooodd " + e.ToString());
    //            SaveKiiExperienceData();

    //        } else {
				
    //            if(list.Count>1){
    //                Util.Log("My error!! Stats list count can't be more than 1");
    //                return;
    //            }
    //            Util.Log("got the exxxxpppp dataaa!!");
    //            currentExp = list[0].GetInt("exp");
				

    //            UpdateExpUI();
    //        }
			
    //    });
		
    //}
}
