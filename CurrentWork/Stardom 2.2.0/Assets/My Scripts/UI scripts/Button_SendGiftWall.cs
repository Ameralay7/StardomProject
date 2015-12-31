using UnityEngine;
using System.Collections;

public class Button_SendGiftWall : MonoBehaviour {

	void Start () {
	
	}
	
	void OnClick () {
		//EnergyManager.Instance.ConsumeEnergy(ConstantsHelper.BIDDING_ENERGY);
		//ExperienceManager.Instance.AddExp(ConstantsHelper.BIDDING_EXP);


		///PhotonManager.Instance.SendGiftWall(UsersProfileManager.Instance.user.kiiID);
		Invoke ("Resume", 2);
		
		Util.Log ("das 3la zorar gift wallllllllllll");
	}
	
	void Resume(){
		///GiftWallSenderReceiver.Instance.UpdateGiftWallData (UsersProfileManager.Instance.user.kiiID, false);
	}
}
