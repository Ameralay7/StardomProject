using UnityEngine;
using System.Collections;

public class PhotonManager /*: Photon.MonoBehaviour */{

	public static PhotonManager Instance;

	private string userID;
	private string userName;
	private string userFBID;

	void Awake(){
		Instance = this;
	}

	void Start () {
		//Connect();
	}
	
	// Update is called once per frame
    //public void Connect (string theUserID, string theUserName, string theUserFBID) {
		
    //    userID = theUserID;
    //    userName = theUserName;
    //    userFBID = theUserFBID;
    //    PhotonNetwork.ConnectUsingSettings ("Stardom v001");


    //}

    //void OnGUI(){
    //    GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
    //}


    //void OnJoinedLobby(){
    //    Util.Log ("OnJoinedLobby");
    //    PhotonNetwork.JoinRandomRoom ();
    //    PhotonNetwork.playerName = userID;
    //    //PhotonPlayer pp = new PhotonPlayer(true, userID, userID);
    //    //PhotonNetwork.CreateRoom (userID);
    //    //if(userID!="bb149fa00022-268a-4e11-011a-08c49bff")
    //        //PhotonNetwork.JoinRoom ("bb149fa00022-268a-4e11-011a-08c49bff");
    //}


    //void OnPhotonRandomJoinFailed(){
    //    Util.Log ("creating new room 3shan mal2etsh");
    //    PhotonNetwork.CreateRoom ("Online");
    //}

    //void OnJoinedRoom(){
    //    Debug.Log ("OnJoinedRoom");
    //    Util.Log ("i joined the room my name: "+userID + "name : "+ userName);

    //}

    //public void BidUser(string userToBeBidID){
    //    for(int i=0; i<PhotonNetwork.otherPlayers.Length; i++){
    //        if(PhotonNetwork.otherPlayers[i].name == userToBeBidID){
    //            this.photonView.RPC("CallBidMe", PhotonNetwork.otherPlayers[i], userID, userName, userFBID);
    //            Util.Log("i am "+userID);
    //        }
    //        Util.Log("user_"+i + ": "+PhotonNetwork.otherPlayers[i].name);

    //    }
    //    Util.Log ("bid user called from photon manager");
    //}

    //[PunRPC]
    //void CallBidMe(string bidderID, string bidderName, string bidderFBID){
    //    HiringManager.Instance.BidMe (bidderID, bidderName, bidderFBID);
    //}

    //[PunRPC]
    //void test(string caller){
    //    Util.Log ("hi "+caller+" has called me here!");
    //}

    //public void SendGiftWall(string userGiftWallSentID){
    //    for(int i=0; i<PhotonNetwork.otherPlayers.Length; i++){
    //        if(PhotonNetwork.otherPlayers[i].name == userGiftWallSentID){
    //            this.photonView.RPC("CallBidMe", PhotonNetwork.otherPlayers[i], userID, userName, userFBID, GiftWallReaderWriter.Instance.GiftCardToString());
    //            Util.Log("i am "+userID);
    //        }
    //        Util.Log("user_"+i + ": "+PhotonNetwork.otherPlayers[i].name);
			
    //    }
    //    Util.Log ("send gift wall user called from photon manager");
    //}
	
    //[PunRPC]
    //void CallSendMeGiftWall(string senderID, string senderName, string senderFBID, string giftWallContent){
    //    GiftWallSenderReceiver.Instance.SendMeGiftWall (senderID, senderName, senderFBID, giftWallContent);
    //}

}
