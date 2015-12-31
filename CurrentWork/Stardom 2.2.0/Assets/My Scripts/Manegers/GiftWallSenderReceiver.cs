using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GiftWallSenderReceiver : MonoBehaviour {
	
	public static GiftWallSenderReceiver Instance;
	
	public GameObject sendGiftWallButton;

	public GameObject myLastGiftWallsPanel;
	public GameObject userLastGiftWallsPanel;

	public UITexture userGiftWallSenderPic;
	public UITexture myGiftWallSenderPic;

	//private KiiObject myGiftWallDataObject;
	//private KiiObject userGiftWallDataObject;
	
	public bool userOnline;
	
	void Awake(){
		Instance = this;
	}
	
	void Start () {

	}



    //public void SendMeGiftWall(string senderID, string senderName, string senderFB_ID, string giftWallContent){
    //    Util.Log ("send gift wallllllll.....");
    //    KiiBucket bucket = Kii.Bucket("GiftWalls");
		
    //    if(!Utils.ValidateObjectID(KiiUser.CurrentUser.ID+"GiftWalls")) {
    //        // ID not valid
    //        Util.Log("el zeft not valid");
    //    }
		
    //    KiiObject giftedUser = bucket.NewKiiObject(KiiUser.CurrentUser.ID+"GiftWalls");

    //    giftedUser ["GiftWall_1_Sender"] = senderID + "," + senderName +","+ senderFB_ID + "," + DateTime.UtcNow.ToString();
    //    giftedUser ["GiftWall_1_Content"] = giftWallContent;


    //    Util.Log ("Saving gift wall data ...");
		
    //    giftedUser.SaveAllFields(true, (KiiObject obj, Exception e) => {
    //        if (e != null) {
				
    //            Util.LogError(e.ToString());
    //        }
    //        else {
    //            UpdateGiftWallData(KiiUser.CurrentUser.ID, true);
    //        }
    //    });
    //}

    //public void UpdateGiftWallData(string userKiiID, bool isMe){
    //    Util.Log ("gonna retreive");
    //    RetrieveGiftWallData (userKiiID, isMe);
		
    //}

    //public void RetrieveGiftWallData(string kiiID, bool isMe){
		
    //    if(isMe){
    //        myGiftWallDataObject = null;
    //    }
    //    else{
    //        userGiftWallDataObject = null;
    //    }
		
    //    KiiBucket bucket = Kii.Bucket ("GiftWalls");
    //    KiiQuery query = new KiiQuery (KiiClause.Equals("_id", kiiID+"GiftWalls"));
		
    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            Util.LogError ("el gift wall msh mowgooooooddaaaaa " + e.ToString());
    //        } else {
				
    //            if(list.Count>1){
    //                Util.Log("My error!! GiftWalls list count can't be more than 1");
    //                return;
    //            }
    //            Util.Log("got the dataaa!!");
				
    //            if(isMe)
    //                myGiftWallDataObject = list[0];
    //            else
    //                userGiftWallDataObject = list[0];
				
    //            UpdateAfterRetreive (isMe);
    //        }
			
    //    });
		
    //}

    //public void UpdateAfterRetreive(bool isMe){
    //    if(!isMe){

    //        GiftWallReaderWriter.Instance.GiftStringToCard(userGiftWallDataObject.GetString("GiftWall_1_Content"));
    //    }
    //    else{
    //        GiftWallReaderWriter.Instance.GiftStringToCard(myGiftWallDataObject.GetString("GiftWall_1_Content"));
    //    }
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
    //        myGiftWallSenderPic.mainTexture = texture;
    //    else
    //        userGiftWallSenderPic.mainTexture = texture;

    //}

}
