using UnityEngine;
using System.Collections;

public class Button_OpenUserPage : MonoBehaviour {

	public bool isMe;

	public MarketUser marketUser;


	void Start () {
	
	}
	
    //void OnClick () {
    //    if(isMe){
    //        ScreensManager.Instance.HomeScreen.SetActive(true);
    //        ScreensManager.Instance.lastOpenedScreen.SetActive(false);
    //        ScreensManager.Instance.lastOpenedScreen = ScreensManager.Instance.HomeScreen;
    //    }
    //    else{
    //        //
    //        UsersProfileManager.Instance.FillUserData(marketUser);


    //        ScreensManager.Instance.UserScreen.SetActive(true);
    //        ScreensManager.Instance.lastOpenedScreen.SetActive(false);
    //        ScreensManager.Instance.lastOpenedScreen = ScreensManager.Instance.UserScreen;
    //    }
    //}
}
