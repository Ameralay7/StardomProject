using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using GameSparks.Api.Responses;
using GameSparks.Core;
using System;

namespace InternalStardomAPI
{

    /// <summary>
    /// This class converts cloud data types to replies
    /// </summary>
    public static class CloudConverter
    {
        public static GameFriendsReply GameFriendsToGameFriendsReply(GSEnumerable<ListGameFriendsResponse._Player> socialFriends)
        {
            GameFriendsReply reply = new GameFriendsReply(true);
            foreach (ListGameFriendsResponse._Player friend in socialFriends)
                reply.Friends.Add(new GameFriendsReply.Friend(friend.ExternalIds.GetString("FB"), friend.DisplayName));

            return reply;
        }

        public static UserProfileReply AccountDetailsToUserProfileReply(AccountDetailsResponse accountResponse)
        {
            UserProfileReply reply = new UserProfileReply(true);
            reply.id = accountResponse.UserId;
            reply.fbid = accountResponse.ExternalIds.GetString("FB").ToString();
            reply.name = accountResponse.DisplayName;

            GSData profile = accountResponse.ScriptData.GetObject("profile");
            GSData stats = accountResponse.ScriptData.GetObject("stats");
            GSData bidding = accountResponse.ScriptData.GetObject("bidding");

            reply.countryCode = profile.GetString("country");
            reply.mood = profile.GetInt("mood").Value;
            reply.price = stats.GetInt("price").Value;

            reply.status = profile.GetString("status");
            reply.pics = profile.GetStringList("pics");
            reply.videos = profile.GetStringList("videos");

            reply.exp = stats.GetInt("exp").Value;
            reply.energy = stats.GetInt("energy").Value;
            reply.money = stats.GetInt("money").Value;
            reply.tokens = stats.GetInt("tokens").Value;

            reply.newMessages = reply.newGifts = 0;

            reply.bidderId = bidding.GetString("bidderId");
            reply.bidderFbid = bidding.GetString("bidderFbid");
            reply.bidderName = bidding.GetString("bidderName");
            reply.bidderCountry = bidding.GetString("bidderCountry");
            reply.lastAction = bidding.GetDate("lastAction");
            reply.lockEnd = bidding.GetDate("lockEnd");
            return reply;
        }

        public static UserProfileReply UserProfileResponseToUserProfileReply(LogEventResponse profileResponse)
        {
            UserProfileReply reply = new UserProfileReply(true);
            reply.id = profileResponse.ScriptData.GetString("id");
            reply.fbid = profileResponse.ScriptData.GetString("fbid");
            reply.name = profileResponse.ScriptData.GetString("name");

            GSData profile = profileResponse.ScriptData.GetObject("profile");
            GSData stats = profileResponse.ScriptData.GetObject("stats");

            reply.countryCode = profile.GetString("country");
            reply.mood = profile.GetInt("mood").Value;
            reply.price = stats.GetInt("price").Value;

            reply.status = profile.GetString("status");
            reply.pics = profile.GetStringList("pics");
            reply.videos = profile.GetStringList("videos");

            return reply;
        }

        public static MarketUsersReply LogEventToMarketUsersReply(LogEventResponse eventResponse)
        {
            MarketUsersReply reply = new MarketUsersReply(true);

            List<object> users = eventResponse.ScriptData.GetObjectList("marketUsers");

            foreach (Dictionary<string, object> user in users)
            {
                MarketUsersReply.User marketUser = new MarketUsersReply.User();

                marketUser.id = user["_id"].ToString();

                marketUser.name = user["name"].ToString();
                marketUser.gender = ((Dictionary<string, object>)user["profile"])["gender"].ToString();

                long birthdate = long.Parse(((Dictionary<string, object>)user["profile"])["birthdate"].ToString());
                marketUser.birthdate = new DateTime(1970, 1, 1) + new TimeSpan(birthdate * 10000);

                marketUser.price = long.Parse(((Dictionary<string, object>)user["stats"])["price"].ToString());

                marketUser.online = user["online"].ToString() != "0";
                marketUser.recentlyJoined = user["recentlyJoined"].ToString() != "0";

                reply.Users.Add(marketUser);
            }

            return reply;
        }

        public static StardomAPIReply LogEventErrorToAPIReply(LogEventResponse eventResponse)
        {
            bool success = eventResponse.ScriptData.GetBoolean("success").Value;
            string errorMsg = eventResponse.ScriptData.GetString("errorMsg");
            return new StardomAPIReply(success, errorMsg);
        }
    }
}