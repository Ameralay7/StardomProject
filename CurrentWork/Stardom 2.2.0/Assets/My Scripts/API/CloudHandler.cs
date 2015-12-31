using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using GameSparks.Api.Messages;
using GameSparks.Core;

namespace InternalStardomAPI
{
    public class CloudHandler
    {
        public event VoidCallback DisconnectHandlers;               //0
        public event VoidCallback BidNotificationHandler;           //1
        public event VoidCallback EnergyFullNotificationHandler;    //2

        public CloudHandler()
        {
            GameSparks.Api.Messages.SessionTerminatedMessage.Listener += delegate(SessionTerminatedMessage msg) {
                DisconnectHandlers();
            };

            GameSparks.Api.Messages.ScriptMessage.Listener += delegate(ScriptMessage msg){
                switch (msg.ExtCode)
                {
                    case "BidNotification":
                        BidNotificationHandler();
                        break;
                    case "EnergyFullNotification":
                        EnergyFullNotificationHandler();
                        break;
                    default:
                        break;
                }
            };
        }

        public void AuthenticateFacebookUser(string fbAccessToken, AuthCallback callback = null)
        {
            new FacebookConnectRequest().SetAccessToken(fbAccessToken).Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new AuthReply(false, false, "GS failed to fetch FB user profile, " + response.Errors.ToString()));
                    else
                        callback(new AuthReply(true, response.ScriptData.GetBoolean("updateFromFb").Value));
                }
            });
        }

        public void UpdateFacebookInfo(FacebookInfoReply reply, StardomAPICallback callback = null)
        {
            LogEventRequest_UpdateFacebookInfo req = new LogEventRequest_UpdateFacebookInfo();
            req.Set_gender(reply.gender);
            req.Set_birthdate(reply.birthdate);

            req.Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new StardomAPIReply(false, "GS failed to update fb info, " + response.Errors.ToString()));
                    else
                        callback(new StardomAPIReply(true));
                }
            });
        }

        public void GetGameFriends(GameFriendsCallback callback)
        {
            new ListGameFriendsRequest().Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new GameFriendsReply(false, "GS failed to fetch game friends, " + response.Errors.ToString()));
                    else
                        callback(CloudConverter.GameFriendsToGameFriendsReply(response.Friends));
                }
            });
        }

        public void GetUserProfile(UserProfileCallback callback = null)
        {
            new AccountDetailsRequest().Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new UserProfileReply(false, "GS failed to fetch user profile, " + response.Errors.ToString()));
                    else
                        callback(CloudConverter.AccountDetailsToUserProfileReply(response));
                }
            });
        }

        public void GetUserProfile(string uid, UserProfileCallback callback = null)
        {
            LogEventRequest_GetUserProfile req = new LogEventRequest_GetUserProfile();
            req.Set_id(uid);
            req.Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new UserProfileReply(false, "GS failed to fetch user profile, " + response.Errors.ToString()));
                    else
                        callback(CloudConverter.UserProfileResponseToUserProfileReply(response));
                }
            });
        }

        public void GetMarketUsers(MarketUsersCallback callback, int? pageSize = null, int? page = null, bool? online = null, bool? recentlyJoined = null, string gender = null, int? minPrice = null, int? maxPrice = null, int? minRemainingLockTime = null, int? maxRemainingLockTime = null)
        {
            LogEventRequest_GetMarketUsers req = new LogEventRequest_GetMarketUsers();
            if (pageSize.HasValue)
                req.Set_pageSize(pageSize.Value);
            if(page.HasValue)
                req.Set_page(page.Value);
            if(online.HasValue)
                req.Set_online(online.Value ? 1 : 0);
            if(recentlyJoined.HasValue)
                req.Set_recentlyJoined(recentlyJoined.Value ? 1 : 0);

            req.Set_gender(string.IsNullOrEmpty(gender) ? "" : gender);
            
            if(minPrice.HasValue)
                req.Set_minPrice(minPrice.Value);
            if(maxPrice.HasValue)
                req.Set_maxPrice(maxPrice.Value);

            if (minRemainingLockTime.HasValue)
                req.Set_minRemainingLockTime(minRemainingLockTime.Value);
            if (maxRemainingLockTime.HasValue)
                req.Set_maxRemainingLockTime(maxRemainingLockTime.Value);

            req.Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new MarketUsersReply(false, "GS failed to fetch market users, " + response.Errors.ToString()));
                    else
                        callback(CloudConverter.LogEventToMarketUsersReply(response));
                }
            });
        }

        public void GetServerTime(ServerTimeCallback callback)
        {
            new LogEventRequest_GetServerTime().Send(response =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new ServerTimeReply(false, "GS failed to update fb info, " + response.Errors.ToString()));
                    else
                        callback(new ServerTimeReply(true, "", new DateTime(1970, 1,1) + new TimeSpan(response.ScriptData.GetNumber("time").Value * 10000)));
                }
            });
        }

        public void BidOnUser(string uid, StardomAPICallback callback)
        {
            LogEventRequest_BidOnUser req = new LogEventRequest_BidOnUser();
            req.Set_id(uid);
            req.Send((response) =>
            {
                if (callback != null)
                {
                    if (response.HasErrors)
                        callback(new StardomAPIReply(false, "Unexpected error occured"));
                    else
                        callback(CloudConverter.LogEventErrorToAPIReply(response));
                }
            });
        }

        //public void Disconnect()
        //{
        //    Debug.Log("Ending GS session ...");
        //    new EndSessionRequest().Send((response) => {
        //        if (response.HasErrors)
        //            Debug.Log("failed to end GS session, " + response.Errors);
        //        else
        //            Debug.Log("Ended GS session");
        //    });
        //}
    }
}