using UnityEngine;
using System.Collections;

public class Button_SkillUpgrade : MonoBehaviour {

	public int skillIndex;

	void Start () {
	
	}
	
	void OnClick () {
		if(SkillsManager.Instance.skillCounter == 0){

			SkillsManager.Instance.UpgradeSkill(skillIndex);

		}
	}

}
