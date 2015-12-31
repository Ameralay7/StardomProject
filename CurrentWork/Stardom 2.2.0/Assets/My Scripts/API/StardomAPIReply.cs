using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StardomAPIReply
{
    protected bool success;
    public bool Success { get { return success; } }

    protected string errorMessage;
    public string ErrorMessage { get { return errorMessage; } }

    public StardomAPIReply(bool success, string errorMessage = "")
    {
        this.success = success;
        this.errorMessage = errorMessage;
    }
}

public class GameFriendsReply : StardomAPIReply
{
    public class Friend
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Friend(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public List<Friend> Friends { get; private set; }
    public GameFriendsReply(bool success, string errorMessage = "")
        : base(success, errorMessage)
    {
        Friends = new List<Friend>();
    }

}

public class UserProfileReply : StardomAPIReply
{
    public string id;
    public string fbid;
    
    public string name;
    public string countryCode;
    
    public Texture2D picture;

    public int mood;
    
    public int price;
    public int exp;
    public int energy;
    public int money;
    public int tokens;

    public int newMessages;
    public int newGifts;

    public DateTime? lastAction;
    public DateTime? lockEnd;

    public string bidderId;
    public string bidderFbid;
    public string bidderName;
    public string bidderCountry;

    public string status;
    public List<string> videos;
    public List<string> pics;

    public UserProfileReply(bool success, string errorMessage = "")
        : base(success, errorMessage)
    {}

}

public class MarketUsersReply : StardomAPIReply
{
    public class User{
        public string id;
        public string name;
        public string gender;
        public long price;
        public bool online;
        public bool recentlyJoined;
        public DateTime birthdate;
    }

    
    public List<User> Users { get; private set; }
    public MarketUsersReply(bool success, string errorMessage = "")
        : base(success, errorMessage)
    {
        Users = new List<User>();
    }
}

public class ServerTimeReply : StardomAPIReply
{
    public DateTime? time;
    public ServerTimeReply(bool success, string errorMessage = "", DateTime? time = null)
        : base(success, errorMessage)
    {
        this.time = time;
    }
}

//Hide replies used internally, no need to expose it to the frontend
namespace InternalStardomAPI
{
    public class FacebookInfoReply : StardomAPIReply
    {
        public string gender;
        public string country;
        public long birthdate;

        public FacebookInfoReply(bool success, string errorMessage = "")
            : base(success, errorMessage)
        { }
    }

    public class AuthReply : StardomAPIReply
    {
        public bool updateFromFb;

        public AuthReply(bool success, bool updateFromFb = false, string errorMessage = "")
            : base(success, errorMessage)
        {
            this.updateFromFb = updateFromFb;
        }
    }
}