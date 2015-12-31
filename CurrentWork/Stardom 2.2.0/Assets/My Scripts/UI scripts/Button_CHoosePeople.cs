using UnityEngine;
using System.Collections;

public class Button_CHoosePeople : MonoBehaviour {

	public UILabel nameLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnClick () {
		MoviesManager.Instance.currentlySelectedPersonPhoto.mainTexture = GetComponent<UITexture>().mainTexture;
		MoviesManager.Instance.currentlySelectedPersonName.text = nameLabel.text;

	}
}
