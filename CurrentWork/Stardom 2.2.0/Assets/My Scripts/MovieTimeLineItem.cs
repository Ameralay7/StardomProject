using UnityEngine;
using System.Collections;

public class MovieTimeLineItem : MonoBehaviour {

	public Movie movie;

	private UISprite posterSprite;
	private UILabel nameLabel;
	private UILabel stateLabel;


	void Awake () {
		posterSprite = transform.GetChild(0).GetComponent<UISprite>();
		nameLabel = transform.GetChild(1).GetComponent<UILabel>();
		stateLabel = transform.GetChild(2).GetComponent<UILabel>();
	}

	public void FillItemData(Movie mov){
		movie = mov;


		posterSprite.spriteName = mov.posterName;
		nameLabel.text = mov.name;

		if(mov.status == 0)
			stateLabel.text = "Pending";
		else if(mov.status == 1)
			stateLabel.text = "In Progress";
		else if(mov.status == 2)
			stateLabel.text = "Finished";
	}
	
	void OnClick () {
		Invoke("openMovie", .25f);

	}

	void openMovie(){
		MoviesManager.Instance.OpenMovie(movie, transform);
	}
}
