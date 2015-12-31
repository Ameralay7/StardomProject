using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class ChatManager : MonoBehaviour {

	public static ChatManager Instance;

	public static string chatAllBucket = "chat_all";
	public UILabel lastChatContentLabel;
	public GameObject chatInput;

	public UILabel kiiResultLabel;

	private string lastChatContent;

	private List<string> lastChatAllList;

	public List<string>  currentChatAllUsers;

	void Awake () {
		Instance = this;
		lastChatContent = null;
		lastChatAllList = new List<string> ();

		currentChatAllUsers = new List<string> ();
	}

	void Start(){
		InvokeRepeating ("UpdateChatAllContent", 5, 0.8f);
	}


    
    //void UpdateChatAllContent(){

    //    RetreiveChatAllContent ();
    //    kiiResultLabel.text = chatAllList.Count+"";
    //    if(chatAllList != null) {
    //        foreach (KiiObject obj in chatAllList) {
    //            //Debug.Log(lastChatAllList.Contains(obj.GetString("_id")));
    //            if(!lastChatAllList.Contains(obj.GetString("_id"))){
    //                string chatTime = obj.GetString ("time");
    //                string chatterName = obj.GetString ("username");
    //                string chatContentText = obj.GetString("chatText");
    //                //string userFBID = obj.GetString("fbID");
    //                kiiResultLabel.text = chatContentText;

    //                //currentChatAllUsers.Add(userFBID);

    //                if(obj.GetString("id") == KiiUser.CurrentUser.ID){
    //                    chatInput.GetComponent<ChatInput>().textList.Add("[99ff00]"+chatterName+": "+chatContentText+"[-]");
    //                    chatInput.GetComponent<ChatInput>().timeList.Add(chatTime);
    //                }
    //                else{
    //                    //chatInput.GetComponent<ChatInput>().textList.Add("[url=http://www.tasharen.com/][u]"+chatterName + ": " + chatContentText);
    //                    chatInput.GetComponent<ChatInput>().textList.Add(chatterName + ": " + chatContentText);
    //                    chatInput.GetComponent<ChatInput>().timeList.Add(chatTime);

    //                }
    //            }

    //            /*
    //            string chatTime = obj.GetString ("time");
    //            string chatterName = obj.GetString ("username");
    //            string chatContentText = obj.GetString("chatText");
    //            kiiResultLabel.text = chatContentText;
    //            //if(System.DateTime.Compare(System.DateTime.))

    //            TimeSpan timeDiff = System.DateTime.Now - System.DateTime.Parse(chatTime);
    //            if(timeDiff.Hours == 00 && timeDiff.Minutes == 00 ){
    //                kiiResultLabel.text = timeDiff.ToString();
    //                if(timeDiff.Seconds > .5f){
    //                    chatInput.GetComponent<ChatInput>().textList.Add(chatterName + ": " + chatContentText);
    //                    chatInput.GetComponent<ChatInput>().timeList.Add(chatTime);
    //                }
    //            }
    //            */
    //            //Debug.Log(int.Parse((System.DateTime.Now - DateTime.Parse(chatTime)).ToString()) );

    //            //chatInput.GetComponent<ChatInput>().textList.Add(chatterName + ": " + chatContentText);
    //            //chatInput.GetComponent<ChatInput>().timeList.Add(chatTime);
    //            //GUI.Label(new Rect(20, position, 110, 50), Truncate(username, 15));
    //            //GUI.Label(new Rect(150, position, 40, 50), highscore.ToString("n2"));

    //            //lastChatAllList = chatAllList;
    //        }
    //        lastChatAllList = new List<string>();
    //        for(int i=0; i<chatAllList.Count; i++){
    //            lastChatAllList.Add(chatAllList[i].GetString("_id"));
    //        }
    //    } 
    //}

    //void RetreiveChatAllContent(){
    //    //highscoresFetching = true;

    //    KiiBucket bucket = Kii.Bucket (chatAllBucket);
    //    KiiQuery query = new KiiQuery ();
    //    query.SortByAsc ("time");
    //    //query.Limit = 20;
    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            //highscoresFetching = false;
    //            //scores = null;
    //            Util.LogError ("Failed to load high scores " + e.ToString());
    //        } else {
    //            //highscoresFetching = false;
    //            chatAllList = list;

    //        }
    //    });
    //}
	
    //public void SendChatToAllContent(string text) {
    //    //scoreSending = true;
    //    //scoreSent = false;
    //    KiiBucket bucket = Kii.Bucket(chatAllBucket);
		
    //    //KiiObject scoreOld = bucket.
		
    //    //Uri objUri = new Uri(appScopeScoreBucket);
		
    //    //KiiObject score = KiiObject.CreateByUri(objUri);
    //    //kiiResultLabel.text = score.ToString();
		
    //    KiiObject chat = bucket.NewKiiObject();
    //    //score["time"] = gameTime;
    //    chat["id"] = KiiUser.CurrentUser.ID;
    //    //chat ["fbID"] = Authentication.Instance.fbID;
    //    chat["username"] = KiiUser.CurrentUser.Displayname;
    //    chat ["chatText"] = text;
    //     //***************************************** tempppp
    //    chat["time"] = System.DateTime.Now;

    //    //score["useragerange"] = Authentication.pro
    //    // score is game completion time, the lower the better
    //    Util.Log ("Saving chat to Kii Cloud...");
		
    //    kiiResultLabel.text = "Saving chat to Kii Cloud...";
		
    //    chat.Save((KiiObject obj, Exception e) => {
    //        if (e != null) {
    //            //scoreSent = true;
    //            //scoreSending = false;
    //            Util.LogError(e.ToString());
    //            kiiResultLabel.text = e.ToString();
    //        }
    //        else {
    //            //lastChatAllList.Add(obj.GetString("_id"));
    //            //scoreSending = false;
    //            //scoreSent = false;
    //            //Util.Log("Score sent to Kii Cloud: " + gameTime.ToString("n2"));
    //        }
    //    });
    //}
}
