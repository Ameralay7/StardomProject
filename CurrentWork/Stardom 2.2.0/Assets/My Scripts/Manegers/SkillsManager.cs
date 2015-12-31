using UnityEngine;
using System.Collections;

public class SkillsManager : MonoBehaviour {


	public static SkillsManager Instance;

	public int [] skillsLevels = new int[]{1, 1, 1, 1, 1};
	public UISlider [] SlidersList;
	public UILabel [] levelsLabelsList;

	public UILabel SkillsTimerLabel;

	public int skillCounter;
	public int SkillsTimerConst = 10;

	void Awake(){
		Instance = this;
	}

	void Start () {
		skillCounter = 0;
	}
	
	public void UpgradeSkill (int index) {
		if(skillsLevels[index] < 50){
			skillsLevels[index]++;

			levelsLabelsList[index].text = skillsLevels[index].ToString();
			SlidersList[index].value = (float) ((float)(skillsLevels[index])/50);

			StartNextUpgradeCounter();
		}

	}

	public void StartNextUpgradeCounter(){
		skillCounter = SkillsTimerConst;
		InvokeRepeating ("CountNextUpgrade", 0, 1);
	}

	void CountNextUpgrade(){
	

		skillCounter --;

		SkillsTimerLabel.text = timerFormatOf(skillCounter);

		if(skillCounter == 0){
			CancelInvoke("CountNextUpgrade");
		}
	}
	
	private string timerFormatOf(int seconds){
		int mins = skillCounter/60;


		int secs = (int)(skillCounter % 60);


		
		return mins.ToString("D2") + ":" + secs.ToString("D2");
	}
}
