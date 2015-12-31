using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using System;

namespace InternalStardomAPI
{
    public class SocialHandler
    {
        public bool IsInitialized { get { return FB.IsInitialized; } }
        public string Token { get { return AccessToken.CurrentAccessToken.TokenString; } }
        public string ID { get { return AccessToken.CurrentAccessToken.UserId; } }

        public SocialHandler()
        {
            if (!FB.IsInitialized)
                FB.Init(delegate
                {
                    Debug.Log("Facebook Initialized");
                });
        }

        public void FacebookLogin(StardomAPICallback callback = null, bool publishPermission = false)
        {
            if (publishPermission)
                FB.LogInWithPublishPermissions(APIConsts.facebookScope, delegate(ILoginResult result) { FBLoginCallback(result, callback); });
            else
                FB.LogInWithReadPermissions(APIConsts.facebookScope, delegate(ILoginResult result) { FBLoginCallback(result, callback); });
        }
        void FBLoginCallback(ILoginResult result, StardomAPICallback callback)
        {
            string error = "";

            if (result == null)
                error = "Facebook returned null reply";
            else if (!string.IsNullOrEmpty(result.Error))
                error = result.Error;
            else if (string.IsNullOrEmpty(result.RawResult))
                error = "Facebook returned empty result";
            else if (!FB.IsLoggedIn)
                error = "Facebook not logged in";

            if (callback != null)
                callback(new StardomAPIReply(string.IsNullOrEmpty(error), error));
            else if (!string.IsNullOrEmpty(error))
                Debug.LogWarning("SocialHandler: FB login failed with no callback. Error: " + error);
        }

        public void GetFacebookInfo(FacebookInfoCallback callback)
        {
            FB.API("/me?fields=gender,birthday", HttpMethod.GET, (IGraphResult result) =>
            {
                Debug.Log(result.RawResult);
                IDictionary<string, object> dict = result.ResultDictionary;

                FacebookInfoReply reply;
                if (!string.IsNullOrEmpty(result.Error))
                    reply = new FacebookInfoReply(false, result.Error);
                else
                {
                    reply = new FacebookInfoReply(true);
                    reply.gender = dict["gender"].ToString();
                    if(!dict.ContainsKey("birthday"))
                        reply.birthdate = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
                    else
                    {
                        string[] birthDate = dict["birthday"].ToString().Split('/');
                        Debug.Log(dict["birthday"].ToString());
                        reply.birthdate = (long)new DateTime(int.Parse(birthDate[2]), int.Parse(birthDate[0]), int.Parse(birthDate[1])).Subtract(new DateTime(1970, 1,1)).TotalMilliseconds;
                    }
                }

                callback(reply);
            });

        }

        public IEnumerator GetPictureFromIdCoroutine(TextureCallback callback, string fbid = "")
        {
            //To get our facebook picture we use this address which we pass our facebookId into
            var www = new WWW("http://graph.facebook.com/" + (string.IsNullOrEmpty(fbid) ? AccessToken.CurrentAccessToken.UserId : fbid) + "/picture?width=210&height=210");

            yield return www;

            Texture2D tempPic = new Texture2D(25, 25);

            if (!string.IsNullOrEmpty(www.error))
                Debug.LogError("Error fetching image");
            else
                www.LoadImageIntoTexture(tempPic);
            
            callback(tempPic);
        }
    }
}