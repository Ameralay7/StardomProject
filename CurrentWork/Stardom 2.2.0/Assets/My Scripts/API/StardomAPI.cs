using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InternalStardomAPI;
public class StardomAPI : MonoBehaviour
{
    #region Singleton

    static StardomAPI instance;
    public static StardomAPI Instance
    {
        get
        {
            if (!instance)
                instance = new GameObject("StardomAPI").AddComponent<StardomAPI>();

            return instance;
        }
    }

    void OnLevelWasLoaded(int level)
    {
        //prevent multiple instances of singleton and force it presist through all levels
        if (instance == null)
            instance = this;
        if (this != instance)
            Destroy(this);
        else
            DontDestroyOnLoad(this);
    }
    #endregion

    SocialHandler socialHandler;
    CloudHandler cloudHandler;

    public bool IsInitialized { get { return socialHandler.IsInitialized; } }

    void Awake()
    {
        socialHandler = new SocialHandler();
        cloudHandler = new CloudHandler();
    }
    //void OnDestroy()
    //{
    //    cloudHandler.Disconnect();
    //}

    public void Login(StardomAPICallback callback = null)
    {
        if (!IsInitialized)
        {
            Debug.LogError("Trying to call StardomAPI functions before it's fully initialized");
            return;
        }

        socialHandler.FacebookLogin(delegate(StardomAPIReply reply)
        {
            if (!reply.Success)
            {
                //if authentication fails return the same object with the same message
                if (callback != null)
                    callback(reply);
            }
            else
            {
                // if facebook login succeeds, continue with cloud authentication
                cloudHandler.AuthenticateFacebookUser(socialHandler.Token, (AuthReply rep) =>
                {
                    //try to update user info from fb if needed from server
                    if (rep.Success && rep.updateFromFb || true)
                        UpdateFacebookInfo((StardomAPIReply updateReply) =>
                        {
                            if (callback != null)
                                callback(updateReply);
                        });
                    else if (callback != null)
                        callback(rep);
                });
            }
        });
    }

    public void GetGameFriends(GameFriendsCallback callback)
    {
        cloudHandler.GetGameFriends(callback);
    }

    public void GetUserProfile(UserProfileCallback callback)
    {
        cloudHandler.GetUserProfile((UserProfileReply reply) =>
        {
            StartCoroutine(socialHandler.GetPictureFromIdCoroutine((Texture2D tex) =>
            {
                reply.picture = tex;
                callback(reply);
            }));
            
        });
    }

    public void GetUserProfile(string uid, UserProfileCallback callback)
    {
        cloudHandler.GetUserProfile(uid, callback);
    }

    public void GetMarketUsers(MarketUsersCallback callback, bool? online = null, bool? recentlyJoined = null, string gender = null, int? minPrice = null, int? maxPrice = null, int? page = null, int? pageSize = null)
    {
        cloudHandler.GetMarketUsers(callback, pageSize, page, online, recentlyJoined, gender, minPrice, maxPrice);
    }

    public void GetServerTime(ServerTimeCallback callback)
    {
        cloudHandler.GetServerTime(callback);
    }

    public void GetPictureFromFBID(string fbid, TextureCallback callback)
    {
        StartCoroutine(socialHandler.GetPictureFromIdCoroutine(callback, fbid));
    }

    public void BidOnUser(string uid, StardomAPICallback callback)
    {
        cloudHandler.BidOnUser(uid, callback);
    }

    public void RegisterBidNotificationHandler(VoidCallback callback)
    {
        cloudHandler.BidNotificationHandler += callback;
    }

    public void RegisterEnergyFullNotificationHandler(VoidCallback callback)
    {
        cloudHandler.EnergyFullNotificationHandler += callback;
    }

    public void RegisterDisconnectHandler(VoidCallback callback)
    {
        cloudHandler.DisconnectHandlers += callback;
    }

    void UpdateFacebookInfo(StardomAPICallback callback = null)
    {
        socialHandler.GetFacebookInfo((FacebookInfoReply reply) =>
        {
            if (reply.Success)
            {
                Debug.Log(string.Format("Fb info, gender: {0}, country: {1}, birthdate: {2}", reply.gender, reply.country, reply.gender));
                cloudHandler.UpdateFacebookInfo(reply, (StardomAPIReply updateReply) =>
                {
                    if (callback != null)
                        callback(updateReply);
                });
            }
            else
            {
                Debug.Log("Failed to fetch fb info, " + reply.ErrorMessage);
                if (callback != null)
                    callback(new StardomAPIReply(false, "Failed to fetch fb info, " + reply.ErrorMessage));
            }
        });
    }
}
