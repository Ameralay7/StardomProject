using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Authentication : MonoBehaviour
{


    public static Authentication Instance;

    private static bool initialized = false;

    public UILabel userName;
    public UILabel userPrice;

    public UILabel smallUserName;
    public UITexture smallProfilePic;

    public UITexture profilePic;
    public UILabel levelNumLabel;


    //tempppp
    public UILabel userNameAbout;


    private int recentlyJoinedValue = -1;


    StardomAPI api;

    void Awake()
    {
        api = StardomAPI.Instance;
        api.RegisterDisconnectHandler(delegate
        {
            Debug.Log("Disconnected, user disconnected");
        });
    }

    void Update()
    {
        if (!initialized && api.IsInitialized)
        {
            initialized = true;
            APIInitialized();
        }
    }

    void APIInitialized()
    {
        api.Login(LoginCallback);
    }

    void LoginCallback(StardomAPIReply reply)
    {
        if (reply.Success)
            api.GetUserProfile(UserProfileCallback);
        else
            Debug.Log("Failed login");
    }

    void UserProfileCallback(UserProfileReply reply)
    {
        userName.text = reply.name;
        userPrice.text = "$"+reply.price;
        profilePic.mainTexture = reply.picture;

        smallUserName.text = reply.name;
        smallProfilePic.mainTexture = reply.picture;

        userNameAbout.text = reply.name;
        
    }




}
