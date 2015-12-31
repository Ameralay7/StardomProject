using UnityEngine;
using System.Collections;
using System;

public delegate void VoidCallback();
public delegate void ObjectCallback(object obj);
public delegate void TextureCallback(Texture2D reply);

public delegate void StardomAPICallback(StardomAPIReply reply);
public delegate void GameFriendsCallback(GameFriendsReply reply);
public delegate void UserProfileCallback(UserProfileReply reply);
public delegate void MarketUsersCallback(MarketUsersReply reply);
public delegate void ServerTimeCallback(ServerTimeReply reply);

namespace InternalStardomAPI
{
    public delegate void FacebookInfoCallback(FacebookInfoReply reply);
    public delegate void AuthCallback(AuthReply reply);

    public static class APIConsts
    {
        public static readonly string facebookScope = "public_profile,email,user_friends,user_birthday";

        public static readonly string app42ApiKey = "_c1dd3ef61e5001999b77075415e08b08577ec6d366ce26fb8ceef3b80b869912";
        public static readonly string app42SceretKey = "c46722cb4fc045e3b109864dcea2901a9b6f0477961516fc0e708ed11f8ce9dd";
        public static readonly string app42DBName = "stardomdb";
        public static readonly string app42ProfileCollection = "userprofiles";
    }
}