using UnityEngine;
using System.Collections;

public class Button_HireUser : MonoBehaviour {

	void Start () {
	
	}
	
	void OnClick () {
		EnergyManager.Instance.ConsumeEnergy(ConstantsHelper.BIDDING_ENERGY);
		ExperienceManager.Instance.AddExp(ConstantsHelper.BIDDING_EXP);
		///PhotonManager.Instance.BidUser (UsersProfileManager.Instance.user.kiiID);
		Invoke ("Resume", 2);

		Util.Log ("das 3la zorar");
	}

	void Resume(){
		HiringManager.Instance.UpdateHiringData (UsersProfileManager.Instance.user.kiiID, false);
	}
}
