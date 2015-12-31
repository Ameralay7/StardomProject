using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
//using com.shephertz.app42.paas.sdk.csharp;
//using com.shephertz.app42.paas.sdk.csharp.user;
//using com.shephertz.app42.paas.sdk.csharp.storage;
using System;

public class TestingFB : MonoBehaviour
{
    //public class SavedFriendsCallback : App42CallBack
    //{
    //    public void OnSuccess(object response)
    //    {
    //        Debug.Log("Saved friends successfully");
    //    }
    //    public void OnException(Exception e)
    //    {
    //        Debug.LogError("App42 Exception : " + e);
    //    }
    //}
    //public class CreatedUserCallback : App42CallBack
    //{
    //    public void OnSuccess(object response)
    //    {
    //        //User user = (User)response;
    //        /* This will create user in App42 cloud and will return User object */
    //        Debug.Log("UserCreatedSuccessfully");
    //        Debug.Log("userName is " + user.GetUserName());
    //        Debug.Log("emailId is " + user.GetEmail());
    //        SaveFriends();
    //    }
    //    public void OnException(Exception e)
    //    {
    //        Debug.LogError("App42 Exception : " + e);
    //    }
    //}
    //public class GetUserCallBack : App42CallBack
    //{
    //    string fbid;
    //    string fbemail;
    //    string fbname;

    //    public GetUserCallBack(string fbid, string fbname, string fbemail)
    //        : base()
    //    {
    //        this.fbemail = fbemail;
    //        this.fbid = fbid;
    //        this.fbname = fbname;
    //    }

    //    public void OnSuccess(object response)
    //    {
    //        User user = (User)response;
    //        Debug.Log("User Found");
    //        Debug.Log("userName is " + user.GetUserName());
    //        SaveFriends();
    //    }

    //    public void OnException(Exception e)
    //    {
    //        /* Above statement throws App42Exception if authentication fails with error code 2002 */
    //        Debug.LogError("App42 Exception : " + e);

    //        App42Exception exception = (App42Exception)e;
    //        int appErrorCode = exception.GetAppErrorCode();
    //        int httpErrorCode = exception.GetHttpErrorCode();

    //        if (appErrorCode == 2006)
    //        {
    //            Debug.Log("User Not Found, Creating one ...");
    //            userService.CreateUser(fbid, "SecretPassword", fbemail, new CreatedUserCallback());
    //        }
    //    }
    //}

    public Text username;

    //static ServiceAPI serviceAPI;
    //static UserService userService;
    //static StorageService storageService;

    static string userId;
    static List<string> friendIds;

    void Start()
    {
        FB.Init(FBInitCallback);
        //serviceAPI = new ServiceAPI("5925bd3effd668d3c593ee5334d5fae17a2f085cff4846c83f9f0fd81b698db8", "c46722cb4fc045e3b109864dcea2901a9b6f0477961516fc0e708ed11f8ce9dd");
        //userService = serviceAPI.BuildUserService();
        //storageService = serviceAPI.BuildStorageService();
    }
    void Login()
    {
        FB.LogInWithReadPermissions("public_profile,email,user_friends", FBLoginCallback);
    }
    void GetOrCreateUser()
    {
        FB.API("/me?fields=id,name,email,friends.limit(20).fields(id)", HttpMethod.GET, GetOrCreateUserCallback);
    }

    void FBInitCallback()
    {
        Debug.Log("App Initialized, Logging in ..");
        Login();
    }

    static void SaveFriends()
    {
        Dictionary<String, object> dataToSave = new Dictionary<String, object>();
        dataToSave.Add("name", userId);
        dataToSave.Add("friends", friendIds);
        string saveJson = Facebook.MiniJSON.Json.Serialize(dataToSave);
        Debug.Log(saveJson);
        //storageService.InsertJSONDocument("stardomdb", "user_friends", saveJson, new SavedFriendsCallback());
    }



    void FBLoginCallback(IResult result)
    {
        //TODO: Handle Error reporting
        if (result == null)
        {
            //Null Error
            return;
        }

        // Some platforms return the empty string instead of null.
        if (!string.IsNullOrEmpty(result.Error))
        {
            //Error in result.Error
            return;
        }

        if (string.IsNullOrEmpty(result.RawResult))
        {
            //Error empty error response
            return;

        }

        //success
        Debug.Log("Login callback");
        Debug.Log(result.RawResult);
        GetOrCreateUser();
    }

    void GetOrCreateUserCallback(IResult result)
    {
        IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.RawResult) as IDictionary;
        string fbid = userId = dict["id"].ToString();
        string fbname = dict["name"].ToString();
        string fbemail = dict["email"].ToString();
        Debug.Log(result.RawResult);

        friendIds = new List<string>();
        List<object> friendsDataDict = ((List<object>)((Dictionary<String, object>)dict["friends"])["data"]);
        foreach (Dictionary<String, object> friend in friendsDataDict)
        {
            Debug.Log(friend["id"].ToString());
            friendIds.Add(friend["id"].ToString());
        }

        username.text = fbname;
        //userService.GetUser(fbid, new GetUserCallBack(fbid, fbname, fbemail));
    }

}
