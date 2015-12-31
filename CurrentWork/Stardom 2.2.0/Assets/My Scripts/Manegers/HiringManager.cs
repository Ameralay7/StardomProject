using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HiringManager : MonoBehaviour {

	public static HiringManager Instance;

	public GameObject biddingButton;

	public UILabel [] myHiringTimersLabels;
	public UILabel [] userHiringTimersLabels;

	public UITexture userOwnerPic;
	public UITexture myOwnerPic;

	public UILabel userOwnerNameLabel;
	public UILabel myOwnerNameLabel;

	public UILabel userStateLabel;
	public UILabel myStateLabel;

	public int timeTillGrab;
	public int timeTillLock;
	public int timeTillUnlock;

	private int myTimer;
	private int userTimer;

	//private KiiObject hiringDataObject;
	//private KiiObject userHiringDataObject;

	public bool userOnline;

	void Awake(){
		Instance = this;
	}

	void Start () {
		myTimer = -1;
		userTimer = -1;

		//temp for testas
		timeTillGrab = 12;
		timeTillLock = 60;
		timeTillUnlock = 160;

		//Debug.Log("hoooooy " + DateTime.UtcNow);
		//QueryHelper.GetKiiTime ();


	}
	
	public void ChangeHiringButton(bool state){
		biddingButton.GetComponent<UIButton> ().enabled = state;
		biddingButton.GetComponent<BoxCollider> ().enabled = state;
		biddingButton.GetComponentInChildren<UILabel>().color = state? Color.white : Color.gray;
	}

	public void UpdateHiringData(string userKiiID, bool isMe){
		Util.Log ("gonna retreive");
		ChangeHiringButton(userOnline);
		///RetrieveHiringData (userKiiID, isMe);

	}
	
	void StartHireTimer(int timerInit, string functionToBeCalledAtEnd, int endSeconds, bool isMe){

		//for reseting
		if(isMe){
			CancelInvoke("MyCountDown");
			CancelInvoke(functionToBeCalledAtEnd);

			UpdateSelfHiringTimer(endSeconds-timerInit);
			myTimer = endSeconds-timerInit;
			InvokeRepeating ("MyCountDown", 0, 1);
			Invoke (functionToBeCalledAtEnd, endSeconds-timerInit);
		}
		else{
			CancelInvoke("UserCountDown");
			CancelInvoke(functionToBeCalledAtEnd);
			
			UpdateSelfHiringTimer(endSeconds-timerInit);
			userTimer = endSeconds-timerInit;
			InvokeRepeating ("UserCountDown", 0, 1);
			Invoke (functionToBeCalledAtEnd, endSeconds-timerInit);
		}
	}

	void MyCountDown(){
		if(myTimer>0){
			myTimer --;
			UpdateSelfHiringTimer(myTimer);
		}
		else
			CancelInvoke("CountDown");
	}

	void UserCountDown(){
		if(userTimer>0){
			userTimer --;
			UpdateUserHiringTimer(userTimer);
		}
		else
			CancelInvoke("CountDown");
	}

	private DateTime TimeOf(long time){
		DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		DateTime date= start.AddMilliseconds(time);
		return date;
	}


	private void UpdateSelfHiringTimer(int timeInSeconds){

		//myHiringTimersLabels [2].text = timeInSeconds+"";

		TimeSpan ts = TimeSpan.FromSeconds( timeInSeconds );


		myHiringTimersLabels [0].text = ts.Hours.ToString("D2");
		myHiringTimersLabels [1].text = ts.Minutes.ToString("D2");
		myHiringTimersLabels [2].text = ts.Seconds.ToString("D2");
		//Util.Log(time.Second.ToString());
	}

	void MyGrab(){
		Util.Log ("graaaaaaaaaaaaaaaaab");
		myStateLabel.text = "Last Grabber";
		StartHireTimer(0, "MyLock", timeTillLock, true);
	}
	
	void MyLock(){
		Util.Log ("Lockkkkkkkkk");
		myStateLabel.text = "Owner";
		StartHireTimer(0, "MyUnlock", timeTillUnlock , true);
	}
	
	void MyUnlock(){
		Util.Log ("unlooooock");
		myStateLabel.text = "Last Owner";
		//StartHireTimer(0, "Lock", timeTillUnlock);
	}
	


	private void UpdateUserHiringTimer(int timeInSeconds){
		
		//myHiringTimersLabels [2].text = timeInSeconds+"";
		
		TimeSpan ts = TimeSpan.FromSeconds( timeInSeconds );
		
		
		userHiringTimersLabels [0].text = ts.Hours.ToString("D2");
		userHiringTimersLabels [1].text = ts.Minutes.ToString("D2");
		userHiringTimersLabels [2].text = ts.Seconds.ToString("D2");
		//Util.Log(time.Second.ToString());
	}



	void UserGrab(){
		userStateLabel.text = "Last Grabber";
		StartHireTimer(0, "UserLock", timeTillLock, false);
	}
	
	void UserLock(){
		userStateLabel.text = "Owner";
		StartHireTimer(0, "UserUnlock", timeTillUnlock, false);
	}
	
	void UserUnlock(){
		userStateLabel.text = "Last Owner";
		//StartHireTimer(0, "Lock", timeTillUnlock);
	}



    //public void BidMe(string actorID, string actorName, string actorFB_ID){
    //    Util.Log ("biiiiiiiiiiiiiiid");
    //    KiiBucket bucket = Kii.Bucket("Hiring");

    //    if(!Utils.ValidateObjectID(KiiUser.CurrentUser.ID+"Bidding")) {
    //        // ID not valid
    //        Util.Log("el zeft not valid");
    //    }
		
    //    KiiObject hiredUser = bucket.NewKiiObject(KiiUser.CurrentUser.ID+"Bidding");
    //    hiredUser ["hireStatus"] = 1;
    //    hiredUser ["lastActionDate"] = DateTime.UtcNow.ToString();
    //    hiredUser ["lastActorID"] = actorID;
    //    hiredUser ["lastActorName"] = actorName;
    //    hiredUser ["lastActorFBID"] = actorFB_ID;
		
    //    Util.Log ("Saving bidding data ya ahbal...");
		
    //    hiredUser.SaveAllFields(true, (KiiObject obj, Exception e) => {
    //        if (e != null) {
				
    //            Util.LogError(e.ToString());
    //        }
    //        else {
    //            UpdateHiringData(KiiUser.CurrentUser.ID, true);
    //        }
    //    });
    //}

    //public void RetrieveHiringData(string kiiID, bool isMe){

    //    if(isMe){
    //        hiringDataObject = null;
    //    }
    //    else{
    //        userHiringDataObject = null;
    //    }

    //    KiiBucket bucket = Kii.Bucket ("Hiring");
    //    KiiQuery query = new KiiQuery (KiiClause.Equals("_id", kiiID+"Bidding"));

    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            Util.LogError ("el hired msh mowgoooooodd " + e.ToString());
    //        } else {

    //            if(list.Count>1){
    //                Util.Log("My error!! Hiring list count can't be more than 1");
    //                return;
    //            }
    //            Util.Log("got the dataaa!!");

    //            if(isMe)
    //                hiringDataObject = list[0];
    //            else
    //                userHiringDataObject = list[0];

    //            UpdateAfterRetreive (isMe);
    //        }

    //    });

    //}

    //private void UpdateAfterRetreive (bool isMe){
		
    //    if(!isMe){
			


    //        userOwnerNameLabel.text = userHiringDataObject.GetString("lastActorName");
    //        LoadPictureAPI(Util.GetPictureURL(userHiringDataObject.GetString("lastActorFBID"), 128, 128),MyPictureCallback, isMe);
				
    //        string receivedDate = userHiringDataObject.GetString("lastActionDate");
    //        int seconds =(int) (DateTime.UtcNow - DateTime.Parse(receivedDate)).TotalSeconds;
				
    //        //int seconds = (int) TimeSpan.FromMilliseconds(timeDiff).TotalSeconds;
				
				
    //        Util.Log("el date ely geh: "  + " ,,,,, " + seconds);
				
    //        if(seconds <= timeTillGrab){
    //            userStateLabel.text = "Last Bidder";
    //            StartHireTimer(seconds, "UserGrab", timeTillGrab, isMe);

    //            if(userHiringDataObject.GetString("lastActorID") == KiiUser.CurrentUser.ID){
    //                ChangeHiringButton(false);
    //            }

    //        }
				
    //        else if(seconds <= timeTillLock + timeTillGrab){
    //            userStateLabel.text = "Last Grabber";
    //            StartHireTimer(seconds-timeTillGrab, "UserLock", timeTillLock, isMe);
    //            if(userHiringDataObject.GetString("lastActorID") == KiiUser.CurrentUser.ID){
    //                ChangeHiringButton(false);
    //            }

    //        }
    //        else if(seconds <= timeTillUnlock + timeTillLock + timeTillGrab){
    //            userStateLabel.text = "Owner";
    //            StartHireTimer(seconds - timeTillLock - timeTillGrab, "UserUnLock", timeTillUnlock, isMe);
    //            ChangeHiringButton(false);
    //        }
    //        else{
    //            userStateLabel.text = "Last Owner";
    //            if(userOnline)
    //                ChangeHiringButton(true);
    //        }


    //    }
    //    /////////we are hereee nowwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
    //    else{

    //        myOwnerNameLabel.text = hiringDataObject.GetString("lastActorName");
    //        LoadPictureAPI(Util.GetPictureURL(hiringDataObject.GetString("lastActorFBID"), 128, 128),MyPictureCallback, isMe);

    //        string receivedDate = hiringDataObject.GetString("lastActionDate");
    //        int seconds =(int) (DateTime.UtcNow - DateTime.Parse(receivedDate)).TotalSeconds;
			
    //        //int seconds = (int) TimeSpan.FromMilliseconds(timeDiff).TotalSeconds;


    //        Util.Log("el date ely geh: "  + " ,,,,, " + seconds);

    //        if(seconds <= timeTillGrab){
    //            myStateLabel.text = "Last Bidder";
    //            StartHireTimer(seconds, "MyGrab", timeTillGrab, isMe);
    //        }

    //        else if(seconds <= timeTillLock + timeTillGrab){
    //            myStateLabel.text = "Last Grabber";
    //            StartHireTimer(seconds-timeTillGrab, "MyLock", timeTillLock, isMe);
    //        }
    //        else if(seconds <= timeTillUnlock + timeTillLock + timeTillGrab){
    //            myStateLabel.text = "Owner";
    //            StartHireTimer(seconds - timeTillLock - timeTillGrab, "MyUnLock", timeTillUnlock, isMe);
    //        }
    //        else{
    //            myStateLabel.text = "Last Owner";
    //        }


    //        //= hiringDataObject.GetString("lastActorFBID");



    //        //uti
    //        //double diff = Double.Parse( hiringDataObject.GetString("lastActionDate")) - /*QueryHelper.GetKiiTime()*/ DateTime.UtcNow.ToOADate();
    //        //int seconds = (int)TimeSpan.FromMilliseconds(diff).TotalSeconds;




    //    }

		

    //}

    //void FillMaketUsersList( ){
		
		

    //    //	LoadPictureAPI(Util.GetPictureURL(mu.fbID, 128, 128),MyPictureCallback,i);
			

    //}
	
    //delegate void LoadPictureCallback (Texture texture, bool isMe);
	
    //void LoadPictureAPI (string url, LoadPictureCallback callback, bool isMe)
    //{
    //    FB.API(url,Facebook.HttpMethod.GET,result =>
    //           {
    //        if (result.Error != null)
    //        {
    //            Util.LogError(result.Error);
    //            return;
    //        }
			
    //        string imageUrl = Util.DeserializePictureURLString(result.Text);
			
    //        StartCoroutine(LoadPictureEnumerator(imageUrl,callback, isMe));
    //    });
    //}
	
    //IEnumerator LoadPictureEnumerator(string url, LoadPictureCallback callback, bool isMe)    
    //{
    //    WWW www = new WWW(url);
    //    yield return www;
    //    callback(www.texture, isMe);
    //}
	
    //void MyPictureCallback(Texture texture, bool isMe)
    //{
    //    Util.Log("MyPictureCallback");
		
    //    if (texture ==  null)
    //    {
    //        // Let's just try again
    //        //LoadPictureAPI(Util.GetPictureURL("me", 128, 128),MyPictureCallback);
			
    //        return;
    //    }
    //    if(isMe)
    //        myOwnerPic.mainTexture = texture;
    //    else
    //        userOwnerPic.mainTexture = texture;
    ////	tempTexture = texture;
    ////	marketList [index].profilePic = texture;
    //}


}
