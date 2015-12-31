using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class APITester : MonoBehaviour {

    public Image img;

    bool apiInitDone = false;
    StardomAPI api;

    void Awake()
    {
        api = StardomAPI.Instance;
        api.RegisterDisconnectHandler(delegate
        {
            Debug.Log("Disconnected");
            if (apiInitDone)
                api.GetUserProfile(UserProfileCallback);
        });
    }

	void Update () 
    {
        if (!apiInitDone && api.IsInitialized)
        {
            apiInitDone = true;
            TestLogin();
        }
  	}

    void TestLogin()
    {
        Debug.Log("ApiTester: Testing Login");
        Debug.Log("ApiTester: ==================>");
        api.Login(LoginCallback);
    }

    void LoginCallback(StardomAPIReply reply)
    {
        if (reply.Success)
        {
            Debug.Log("Successful login");
            TestGameFriends();
        }
        else
            Debug.Log("Failed login");
    }


    void TestGameFriends()
    {
        Debug.Log("ApiTester: Testing Facebook Friends");
        Debug.Log("ApiTester: ==================>");
        api.GetGameFriends(GameFriendsCallback);
    }

    void GameFriendsCallback(GameFriendsReply reply)
    {
        if (reply.Success)
        {
            Debug.Log("Game Friends");
            foreach (GameFriendsReply.Friend friend in reply.Friends)
                Debug.Log(friend.Id + ": " + friend.Name);

            TestUserProfile();
        }
        else
            Debug.Log("Fetching game friends failed");
    }


    void TestUserProfile()
    {
        Debug.Log("ApiTester: Testing user profile");
        Debug.Log("ApiTester: ==================>");
        api.GetUserProfile(UserProfileCallback);
    }

    void UserProfileCallback(UserProfileReply reply)
    {
        if (reply.Success)
        {
            Debug.Log("User Profile: " + reply.name + "-" + reply.fbid + "-" + reply.id + "-" + reply.countryCode + "-" + reply.mood + "-" + reply.bidderId + "-" + reply.bidderCountry + "-" + reply.bidderName + "-" + reply.energy + "-" + reply.exp + "-" + reply.money + "-" + reply.tokens);
            img.sprite = Sprite.Create(reply.picture, new Rect(0, 0, reply.picture.width, reply.picture.height), 0.5f * Vector2.one);
            TestMarketUsers();
        }
        else
            Debug.Log("Fetching user profile failed");
    }

    void TestMarketUsers()
    {
        Debug.Log("ApiTester: Testing market users");
        Debug.Log("ApiTester: ==================>");
        api.GetMarketUsers(MarketUsersCallback, true, false, "male", 10, 200);
    }

    void MarketUsersCallback(MarketUsersReply reply)
    {
        if (reply.Success)
        {
            foreach (MarketUsersReply.User user in reply.Users)
                Debug.Log("Market User Profile: " + user.name + "-" + user.gender + "-" + user.online + "-" + user.recentlyJoined + "-" + user.id + "-" + user.price);

            TestServerTime();
        }
        else
            Debug.Log("Fetching user market users failed");
    }
    void TestServerTime()
    {
        Debug.Log("ApiTester: Testing server time");
        Debug.Log("ApiTester: ==================>");
        api.GetServerTime(ServerTimeCallback);
    }

    void ServerTimeCallback(ServerTimeReply reply)
    {
        if (reply.Success)
        {
            Debug.Log("Server time: " + reply.time.Value.ToString());
        }
        else
            Debug.Log("Fetching user market users failed");
    }
}
