using UnityEngine;
using System.Collections;

public class Button_ChoosePoster : MonoBehaviour {

	void Start () {
	
	}
	
	void OnClick () {
		MoviesManager.Instance.ChoosePosterPanel.SetActive(true);
	}
}
