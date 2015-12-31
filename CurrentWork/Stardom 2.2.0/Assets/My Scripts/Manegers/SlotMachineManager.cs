using UnityEngine;
using System.Collections;

public class SlotMachineManager : MonoBehaviour {

	public static SlotMachineManager Instance;

	public TweenAlpha cong;
	public UISprite matchSprite;
	public UILabel earnLabel;
	
	public GameObject cam;

	void Awake(){
		Instance = this;
	}

	public void CheckMatch(int type0, int type1, int type2){

		if(type0==type1 && type0==type2 && type1==type2){
			cong.Toggle();
			
		//	matchSprite.spriteName = namee;
			matchSprite.GetComponent<TweenScale>().Play();
			
			if(type0 == 0){
				matchSprite.spriteName = "bar_gift";
				earnLabel.text = "You earnred a Gift!";
			}
			else if(type0 == 1){
				matchSprite.spriteName = "bar_gyms";
				earnLabel.text = "You earnred a Gym!";
			}
			else if(type0 == 2){
				matchSprite.spriteName = "bar_money";
				earnLabel.text = "You earnred Money!";
			}
			disableCam();

		}

	}
	
	public void enableCam(){
		cam.SetActive(true);
	}
	
	public void disableCam(){
		cam.SetActive(false);
	}

}
