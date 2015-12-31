using UnityEngine;
using System.Collections;

public class Button_MovieChoosePoster : MonoBehaviour {

	private UISprite sprite;

	void Start () {
		sprite = GetComponent<UISprite>();
	}
	
	void OnClick () {
		MoviesManager.Instance.SetMoviePoster(sprite.spriteName);

		MoviesManager.Instance.ChoosePosterPanel.SetActive(false);
	}
}
