using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class QueryHelper {

	/*
	public static KiiQueryResult<KiiObject> RetrieveUnSortedBucketData(string bucketName){

		KiiQueryResult<KiiObject> resultList = null;

		KiiBucket bucket = Kii.Bucket (bucketName);
		KiiQuery query = new KiiQuery ();
		bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
			if (e != null) {
				Util.LogError ("Failed to load bucket of" + bucketName+" " + e.ToString());
			} else {
				//highscoresFetching = false;
				resultList = list;
				
			}
		});

		return resultList;
	}


	public static KiiUser GetUserByID(string userKiiID){
		KiiUser user = KiiUser.UserWithID(userKiiID);
		user.Refresh((KiiUser usr, Exception e) => {
			if (e != null) {
				Debug.Log ("retrieve failed, resson : " +  e.ToString());
				return;
			}

		});

		return user;
	}

*/
    //public static void SaveMyCurrentStatus(int status){
    //    KiiBucket bucket = Kii.Bucket("MarketUsers");
		
    //    KiiObject marketUser = bucket.NewKiiObject(KiiUser.CurrentUser.ID);
    //    //score["time"] = gameTime;
		
    //    marketUser ["onlineNow"] = status;
		
    //    Util.Log ("Saving Status...");
		
    //    marketUser.Save(true, (KiiObject obj, Exception e) => {
    //        if (e != null) {
				
    //            Util.LogError(e.ToString());
    //        }
    //        else {
				
    //        }
    //    });
    //}

    //public static long  GetKiiTime(){

    //    KiiBucket bucket = Kii.Bucket("TimeBucket");

    //    KiiObject ob = bucket.NewKiiObject("68b7d0b0-b040-11e4-97e1-22000ae30829");
    //    //score["time"] = gameTime;
    //    ob ["anything"] = "anything";

    //    Util.Log ("getting time from kii...");

    //    ob.Save(true, (KiiObject obj, Exception e) => {
    //        if (e != null) {

    //            Util.LogError(e.ToString());
    //        }
    //        else {
    //            Util.Log(ob.ModifedTime+"");
    //        }
    //    });

    //    long result = 0;

    //    KiiQuery query = new KiiQuery ();
		
    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            Util.LogError ("Failed to load bucket of Time " + e.ToString());
    //        } else {
    //            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    //            DateTime date= start.AddMilliseconds(list[0].ModifedTime);

    //            result = list[0].ModifedTime;
    //            Util.Log(date.ToString());
				
    //        }
			
    //    });

    //    return result;


    //}


	
}
