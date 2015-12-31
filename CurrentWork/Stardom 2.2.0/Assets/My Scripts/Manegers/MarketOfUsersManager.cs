using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MarketOfUsersManager : MonoBehaviour {

	public static MarketOfUsersManager Instance;

	public GameObject marketItemPrefab;
	public GameObject marketAllUsersGrid;
	//public GameObject marketSearchUsersGrid;

	public List<MarketUser> marketList;
	//private KiiQueryResult<KiiObject> marketObjKiiList;

	//public List<MarketUser> marketCurrentSearchUsersList;
	//private KiiQueryResult<KiiObject> marketCurrentSearchUsersObjKiiList;

	private bool marketDataAllUICreated;

	private Texture tempTexture;

	public UILabel kiitest;

	void Awake(){
		Instance = this;
		marketList = new List<MarketUser> ();
		marketDataAllUICreated = false;

		//marketCurrentSearchUsersList = new List<MarketUser> ();
	}

	void Start () {

	}

	public void InitMarketWithUsers(){


		
		///RetrieveUnSortedBucketData ("MarketUsers", QueryTextData.EQ_CLAUSE_ONLINE, 10);

	}



    //public void RetrieveUnSortedBucketData(string bucketName,  
    //                                       KiiClause targetClause, 
    //                                       int limitOfQuery ){


    //    ClearUIList();
    //    marketObjKiiList = null;

    //    KiiBucket bucket = Kii.Bucket (bucketName);
    //    //KiiQuery query = new KiiQuery (KiiClause.Equals("onlineNow", 1));

    //    KiiQuery query;
    //    if(targetClause != null){
    //        query = new KiiQuery (targetClause);

    //    }
    //    else{
    //        query = new KiiQuery();
    //        Util.Log("el clause be nullll");
    //    }

    //    query.Limit = limitOfQuery;

    //    bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
    //        if (e != null) {
    //            Util.LogError ("Failed to load bucket of" + bucketName+" " + e.ToString());
    //        } else {
    //            marketObjKiiList = list;

    //            if(marketObjKiiList.Count>0){
    //                FillMaketUsersList ();
    //                Util.Log("msa gablena ehhh");
    //            }
    //        }

    //        // Fetching the next 10 objects (pagination handling)
    //        if (list.HasNext)
    //        {
    //            list.GetNextQueryResult((KiiQueryResult<KiiObject> listNext, Exception e2) => {
    //                if (e2 != null)
    //                {
    //                    // handle error
    //                    return;
    //                }
    //                foreach (KiiObject obj in listNext)
    //                {
    //                    // Do something with the first 10 objects
    //                }
    //            });
    //        }
    //    });
		
    //}

    //void ClearUIList(){
    //    Util.Log("toool el array " + marketList.Count+"");
    //    for(int i=0 ; i<marketAllUsersGrid.transform.childCount;i++){
    //        Destroy(marketAllUsersGrid.transform.GetChild(i).gameObject);
    //    }
    //    marketAllUsersGrid.GetComponent<UIGrid> ().GetChildList ().Clear ();
    //    kiitest.text += " ..k " + marketAllUsersGrid.GetComponent<UIGrid> ().GetChildList ().Count;

    //}
    //void FillMaketUsersList( ){


    //    marketList = new List<MarketUser> ();

    //    MarketUser mu = new MarketUser();
    //    KiiUser ku;
    //    for(int i=0; i<marketObjKiiList.Count; i++){
    //        mu = new MarketUser();
    //        mu.kiiID = marketObjKiiList[i].GetString("_id");
    //        //ku = QueryHelper.GetUserByID(mu.kiiID);
    //        mu.name = marketObjKiiList[i].GetString("name");
    //        mu.price = marketObjKiiList[i].GetInt("price");
    //        mu.fbID = marketObjKiiList[i].GetString("fbID");
    //        mu.onlineNow = marketObjKiiList[i].GetInt("onlineNow", 0);
    //        LoadPictureAPI(Util.GetPictureURL(mu.fbID, 128, 128),MyPictureCallback,i);

    //        marketList.Add(mu);

    //        Util.Log("my dataaa" + mu.name + mu.price);

    //        //double timeCreated = Double.Parse( marketUsersObjKiiList[i].GetString("_created"));
    //        //double timeMod = Double.Parse( marketUsersObjKiiList[i].GetString("_modified"));
			
    //        //double diff = timeMod - timeCreated;
    //        //kiitest.text += (TimeSpan.FromMilliseconds(diff).TotalHours).ToString();

    //    }


    //    Invoke ("DisplayMarketWithData", .5f);
    //    //CreateMarketSearchUI ();

    //}

    //delegate void LoadPictureCallback (Texture texture, int index);

    //void LoadPictureAPI (string url, LoadPictureCallback callback, int index)
    //{
    //    FB.API(url,Facebook.HttpMethod.GET,result =>
    //           {
    //        if (result.Error != null)
    //        {
    //            Util.LogError(result.Error);
    //            return;
    //        }
			
    //        string imageUrl = Util.DeserializePictureURLString(result.Text);
			
    //        StartCoroutine(LoadPictureEnumerator(imageUrl,callback,index));
    //    });
    //}

    //IEnumerator LoadPictureEnumerator(string url, LoadPictureCallback callback, int index)    
    //{
    //    WWW www = new WWW(url);
    //    yield return www;
    //    callback(www.texture, index);
    //}

    //void MyPictureCallback(Texture texture, int index)
    //{
    //    Util.Log("MyPictureCallback");
		
    //    if (texture ==  null)
    //    {
    //        // Let's just try again
    //        LoadPictureAPI(Util.GetPictureURL("me", 128, 128),MyPictureCallback, index);
			
    //        return;
    //    }
		
    //    tempTexture = texture;
    //    marketList [index].profilePic = texture;
    //    //marketUsersTexturesList.Add (texture);
    //}

    //public void DisplayMarketWithData(){
    //    //if(!marketDataAllUICreated){
    //        CreateMarketUI();
    //    //}
    //}

    //private void CreateMarketUI(){

    //    GameObject item;
    //    if(marketItemPrefab && marketAllUsersGrid.GetComponent<UIGrid> ().GetChildList ().Count == 0){
    //        for(int i = 0; i<marketList.Count; i++){
    //            item= Instantiate(marketItemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    //            item.transform.parent = marketAllUsersGrid.transform;
    //            item.transform.localScale = new Vector3(1, 1, 1);
    //            item.name = "MarektAllUsers_"+ i.ToString("D2");

    //            item.GetComponentInChildren<UITexture>().mainTexture = marketList[i].profilePic;
    //            item.transform.FindChild("l_userMarketName").gameObject.GetComponent<UILabel>().text = marketList[i].name;
    //            item.transform.FindChild("l_userMarketPrice").gameObject.GetComponent<UILabel>().text = "$"+marketList[i].price.ToString();
    //            item.GetComponent<Button_OpenUserPage>().marketUser = marketList[i];

    //            item.transform.FindChild("s_online_offline").gameObject.GetComponent<UISprite>().spriteName = (marketList[i].onlineNow == 1)? "online" : "offline";

    //            item.GetComponent<Button_OpenUserPage>().isMe = (marketList[i].kiiID == KiiUser.CurrentUser.ID);


    //        }

    //        //marketAllUsersGrid.GetComponentInParent<UIScrollView>().ResetPosition();
    //        marketAllUsersGrid.GetComponent<UIGrid> ().Reposition ();
    //        kiitest.text += " ..k " + marketAllUsersGrid.GetComponent<UIGrid> ().GetChildList ().Count;
    //        //marketDataAllUICreated = true;
    //    }


    //}
	/*
	public void RetrieveSearchData(string cond1, string cond2){

		marketCurrentSearchUsersObjKiiList = null;


		Util.LogError ("da5al omm el retreiv");

		//KiiClause.And (new KiiClause[2]{KiiClause.GreaterThanOrEqual("price", int.Parse(cond1)),KiiClause.GreaterThanOrEqual("price", int.Parse(cond1))});

		KiiBucket bucket = Kii.Bucket ("MarketUsers");

		KiiQuery query = new KiiQuery ( KiiClause.And(
			KiiClause.GreaterThanOrEqual("price", int.Parse(cond1)),
			KiiClause.LessThanOrEqual("price", int.Parse(cond2))
			));




		//KiiQuery query = new KiiQuery (KiiClause.LessThanOrEqual("_created", ));
		bucket.Query(query, (KiiQueryResult<KiiObject> list, Exception e) =>{
			if (e != null) {
				Util.LogError ("Failed to load bucket of" + "MarketUsers"+" " + e.ToString());
			} else {
				//highscoresFetching = false;
				marketCurrentSearchUsersObjKiiList = list;
				FillMaketCurrUsersList ();
				Util.LogError ("byfillaho");
			}
		});
		
	}

	void FillMaketCurrUsersList(){

		marketCurrentSearchUsersList = new List<MarketUser> ();

		MarketUser mu = new MarketUser();
		KiiUser ku;
		for(int i=0; i<marketCurrentSearchUsersObjKiiList.Count; i++){
			mu = new MarketUser();
			mu.kiiID = marketCurrentSearchUsersObjKiiList[i].GetString("_id");
			//ku = QueryHelper.GetUserByID(mu.kiiID);
			mu.name = marketCurrentSearchUsersObjKiiList[i].GetString("name");
			mu.price = marketCurrentSearchUsersObjKiiList[i].GetInt("price");
			mu.fbID = marketCurrentSearchUsersObjKiiList[i].GetString("fbID");
			mu.onlineNow = marketUsersObjKiiList[i].GetInt("onlineNow", 0);
			LoadPictureAPI(Util.GetPictureURL(mu.fbID, 128, 128),MyPictureCallback2,i);
			marketCurrentSearchUsersList.Add(mu);
			//mu.profilePic = tempTexture;
			
			Util.Log("my dataaa" + mu.name + mu.price);
		}

		Util.Log("toool el array " + marketCurrentSearchUsersList.Count+"");
		for(int i=0 ; i<marketSearchUsersGrid.transform.childCount;i++){
			Destroy(marketSearchUsersGrid.transform.GetChild(i).gameObject);
		}
		Invoke ("CreateMarketSearchUI", .3f);
		//CreateMarketSearchUI ();
	}

	void MyPictureCallback2(Texture texture, int index)
	{
		Util.Log("MyPictureCallback2");
		
		if (texture ==  null)
		{
			// Let's just try again
			//LoadPictureAPI(Util.GetPictureURL("me", 128, 128),MyPictureCallback);
			
			return;
		}
		
		marketCurrentSearchUsersList [index].profilePic = texture;
		//marketUsersTexturesList.Add (texture);
	}


	private void CreateMarketSearchUI(){



		marketSearchUsersGrid.GetComponent<UIGrid> ().GetChildList ().Clear ();

		GameObject item;
		if(marketItemPrefab){
			for(int i = 0; i<marketCurrentSearchUsersList.Count; i++){
				item= Instantiate(marketItemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				item.transform.parent = marketSearchUsersGrid.transform;
				item.transform.localScale = new Vector3(1, 1, 1);
				item.name = "MarektSearchUsers_"+ i.ToString("D2");
				
				item.GetComponentInChildren<UITexture>().mainTexture = marketCurrentSearchUsersList[i].profilePic;
				item.transform.FindChild("l_userMarketName").gameObject.GetComponent<UILabel>().text = marketCurrentSearchUsersList[i].name;
				item.transform.FindChild("l_userMarketPrice").gameObject.GetComponent<UILabel>().text = marketCurrentSearchUsersList[i].price.ToString();
				item.GetComponent<Button_OpenUserPage>().marketUser = marketCurrentSearchUsersList[i];
				
				item.GetComponent<Button_OpenUserPage>().isMe = (marketCurrentSearchUsersList[i].kiiID == KiiUser.CurrentUser.ID);
				
				
			}
			//
			marketSearchUsersGrid.GetComponentInParent<UIScrollView>().ResetPosition();
			marketSearchUsersGrid.GetComponent<UIGrid> ().Reposition ();
		}



	}
	*/

	

}
