using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class EnergyManager : MonoBehaviour {

	public static EnergyManager Instance;

	public int MaxEnergy = 100;
	public int CurrentEnegry;
	public UISlider energySlider;

	//public float enegryUpRate = 20;
	//public int energyUpConstValue = 1;

	void Awake () {
		Instance = this;
	}

	void Start(){
		CurrentEnegry = ConstantsHelper.STARTING_ENERGY;
		//UpdateEnergyUI();
	}
	
	public bool ConsumeEnergy (int amount) {
		if(CurrentEnegry<amount){
			return false;
		}
		CurrentEnegry -= amount;

		//SaveKiiEnergyData();

		return true;
	}

	public void IncreaseEnergy(int amount){
		if(CurrentEnegry+amount <= MaxEnergy)
			CurrentEnegry += amount;
		else
			CurrentEnegry = MaxEnergy;

		//SaveKiiEnergyData();

	}



    //void SaveKiiEnergyData(){
    //    KiiBucket bucket = Kii.Bucket("Stats");
		
    //    if(!Utils.ValidateObjectID(KiiUser.CurrentUser.ID+"Stats")) {
    //        // ID not valid
    //        Util.Log("el zeft not valid");
    //    }
		
    //    KiiObject hiredUser = bucket.NewKiiObject(KiiUser.CurrentUser.ID+"Stats");
    //    hiredUser ["energy"] = CurrentEnegry;

    //    Util.Log ("Saving energy data...");
		
    //    hiredUser.SaveAllFields(true, (KiiObject obj, Exception e) => {
    //        if (e != null) {
				
    //            Util.LogError(e.ToString());
    //        }
    //        else {
    //            UpdateEnergyUI();
    //        }
    //    });
    //}

    //private void UpdateEnergyUI(){
    //    energySlider.value = (float)CurrentEnegry/MaxEnergy;
    //}


    //public void StartEnergyCounterUp(){
    //    InvokeRepeating("CallIncreaeEnergy", 0, ConstantsHelper.ENERGY_UP_SECONDS);
    //}

    //void CallIncreaeEnergy(){
    //    IncreaseEnergy(ConstantsHelper.ENERGY_UP_VALUE);
    //}

    //public void LoadKiiEnergyData(string kiiID){
		

    //    KiiBucket bucket = Kii.Bucket ("Stats");
    //    KiiQuery query = new KiiQuery (KiiClause.Equals("_id", kiiID+"Stats"));
		
    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            Util.LogError ("el stats msh mowgoooooodd " + e.ToString());
    //            SaveKiiEnergyData();
    //            StartEnergyCounterUp();

    //        } else {
				
    //            if(list.Count>1){
    //                Util.Log("My error!! Stats list count can't be more than 1");
    //                return;
    //            }
    //            Util.Log("got the energgggyyyy dataaa!!");
    //            //CurrentEnegry = list[0].GetInt("energy");

    //            //Util.Log(list[0].ModifedTime + "  dah el modif");
    //            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(TimeSpan.FromMilliseconds(list[0].ModifedTime));

    //            double seconds = (DateTime.UtcNow - time).TotalSeconds;

    //            int times =(int) (seconds/ConstantsHelper.ENERGY_UP_SECONDS);
    //            CurrentEnegry = list[0].GetInt("energy") + times*ConstantsHelper.ENERGY_UP_VALUE ;

    //            Util.Log(seconds.ToString() +" we deh el total secs");

    //            UpdateEnergyUI();
    //            StartEnergyCounterUp();
    //        }
			
    //    });
		
    //}
}
