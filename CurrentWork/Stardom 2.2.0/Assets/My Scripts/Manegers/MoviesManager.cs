using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoviesManager : MonoBehaviour {

	public static MoviesManager Instance;

	public UIPanel LastMoviePanel;
	public UIPanel CreateMoviePanel;

	public GameObject ChoosePosterPanel;


	public UIInput movieNameText;
	public UIPopupList categoriesPopupList;
	public UISprite posterSprite;
	public UIInput movieDescriptionText;
	public UIToggle romanticSceneCheckBox;

	public UITexture [] peoplePicsList;
	public UILabel [] peopleNamesList;



	public GameObject timeLineItem;
	public UIGrid timelineGrid;
	public UIScrollView timeLineScrollView;

	public GameObject newMovieButtonsGO;
	public GameObject createdButtonsGO;
	public GameObject startedButtonsGO;
	public GameObject finishedButtonsGO;

	public UILabel movieCounterLabel;
	public UILabel noMoviesYet;

	public UIPanel finishedMoviePanel;
	public UILabel profitsLabel;

	public Texture2D nonePic;

	//temp
	private List<Movie> MoviesList;
	private int movieCounter;

	private Transform currentSelectedMovie;
	private int currenMovieIndex;

	private List<int> moviesIndexesStarted;



	public TweenAlpha cong;
	public UISprite matchSprite;
	public UILabel earnLabel;

	public GameObject cam;

	public UITexture currentlySelectedPersonPhoto;
	public UILabel currentlySelectedPersonName;

	void Awake(){
		Instance = this;
	}

	void Start () {
		//LoadLastMovieData();

		MoviesList = new List<Movie>();
		moviesIndexesStarted = new List<int>();
	}
	
	private void LoadLastMovieData () {

	}

	public void CreateMovie(){


		//
		Movie movie = new Movie();

		movie.name = movieNameText.value;
		movie.category = categoriesPopupList.value;
		movie.posterName = posterSprite.spriteName;
		movie.description = movieDescriptionText.value;
		movie.romanticScene = romanticSceneCheckBox.value;

		movie.directorPic = peoplePicsList[0].mainTexture;
		movie.mainActorPic = peoplePicsList[1].mainTexture;
		movie.mainActressPic = peoplePicsList[2].mainTexture;
		movie.writerPic = peoplePicsList[3].mainTexture;
		movie.producerPic= peoplePicsList[4].mainTexture;

		movie.director = peopleNamesList[0].text;
		movie.mainActor = peopleNamesList[1].text;
		movie.mainActress = peopleNamesList[2].text;
		movie.writer = peopleNamesList[3].text;
		movie.producer = peopleNamesList[4].text;

		movie.status = 0;

		MoviesList.Add(movie);

		GameObject item = Instantiate(timeLineItem, Vector3.zero, Quaternion.identity) as GameObject;

		timelineGrid.AddChild(item.transform);
		item.transform.localScale = new Vector3(1,1,1);

		item.GetComponent<MovieTimeLineItem>().FillItemData(movie);

		currentSelectedMovie = item.transform;
		currenMovieIndex = MoviesList.Count-1;

		timeLineScrollView.ResetPosition();
	}

	public void EnableCreatedButtons(){
		newMovieButtonsGO.SetActive(false);
		createdButtonsGO.SetActive(true);

	}

	public void SetMoviePoster(string posterPhotoName){
		posterSprite.spriteName = posterPhotoName;
	}

	public void OpenMovie(Movie m, Transform timeLineItem){
		SaveEditedMovie();
		CreateMoviePanel.transform.GetComponent<TweenAlpha>().Toggle();

		movieNameText.value = m.name;
		categoriesPopupList.value = m.category;
		posterSprite.spriteName = m.posterName;
		movieDescriptionText.value = m.description;
		romanticSceneCheckBox.value = m.romanticScene;

		peoplePicsList[0].mainTexture = m.directorPic;
		peoplePicsList[1].mainTexture = m.mainActorPic;
		peoplePicsList[2].mainTexture = m.mainActressPic;
		peoplePicsList[3].mainTexture = m.writerPic;
		peoplePicsList[4].mainTexture = m.producerPic;

		peopleNamesList[0].text = m.director;
		peopleNamesList[1].text = m.mainActor;
		peopleNamesList[2].text = m.mainActress;
		peopleNamesList[3].text = m.writer;
		peopleNamesList[4].text = m.producer;

		if(m.status == 0){ //movie created
			newMovieButtonsGO.SetActive(false);
			createdButtonsGO.SetActive(true);
			startedButtonsGO.SetActive(false);
			//finishedButtonsGO.SetActive(false);
		}
		else if(m.status == 1){ //movie started
			newMovieButtonsGO.SetActive(false);
			createdButtonsGO.SetActive(false);
			startedButtonsGO.SetActive(true);
			//finishedButtonsGO.SetActive(false);
		}
		else if(m.status == 2){ // movie finished
			newMovieButtonsGO.SetActive(false);
			createdButtonsGO.SetActive(false);
			startedButtonsGO.SetActive(false);
			//finishedButtonsGO.SetActive(true);
		}

		currentSelectedMovie = timeLineItem;
		currenMovieIndex = MoviesList.IndexOf(m);

	}

	public void ClearNewMovieScreen(){
		SaveEditedMovie();
		noMoviesYet.enabled = false;
		CreateMoviePanel.transform.GetComponent<TweenAlpha>().Toggle();
		
		movieNameText.value = "movie name";
		categoriesPopupList.value = "category";
		posterSprite.spriteName = "none";
		movieDescriptionText.value = "none";
		romanticSceneCheckBox.value = false;

		peoplePicsList[0].mainTexture = nonePic;
		peoplePicsList[1].mainTexture = nonePic;
		peoplePicsList[2].mainTexture = nonePic;
		peoplePicsList[3].mainTexture = nonePic;
		peoplePicsList[4].mainTexture =nonePic;
		
		peopleNamesList[0].text = "....";
		peopleNamesList[1].text = "....";
		peopleNamesList[2].text = "....";
		peopleNamesList[3].text = "....";
		peopleNamesList[4].text = "....";

		newMovieButtonsGO.SetActive(true);
		createdButtonsGO.SetActive(false);
		startedButtonsGO.SetActive(false);
		//finishedButtonsGO.SetActive(false);
	}

	public void StartMovie(){
		//movieCounter = 3720;

		MoviesList[currenMovieIndex].status = 1;
		currentSelectedMovie.GetComponent<MovieTimeLineItem>().movie.status = 1;


		movieCounter = 43200;
		movieCounterLabel.text = timerFormatOf(movieCounter);

		InvokeRepeating("CountMovieCounter", 0, 1);

		moviesIndexesStarted.Add(currenMovieIndex);

	}

	public void EnableStartedButtons(){
		newMovieButtonsGO.SetActive(false);
		createdButtonsGO.SetActive(false);
		startedButtonsGO.SetActive(true);
		//finishedButtonsGO.SetActive(false);
	}

	void CountMovieCounter(){
		movieCounter --;

		//int mins = movieCounter/60;
		//int hours = mins/60;



		movieCounterLabel.text = timerFormatOf(movieCounter);
	}

	private string timerFormatOf(int seconds){
		int hours = movieCounter/3600;
		
		int mins = (int)((movieCounter % 3600) /60);
		
		return hours.ToString("D2") + ":" + mins.ToString("D2");
	}

	public void DeleteMovie(){

		MoviesList.RemoveAt(currenMovieIndex);
		timelineGrid.RemoveChild(currentSelectedMovie);
		timelineGrid.Reposition();

	}

	public void SaveEditedMovie(){
		if(MoviesList.Count>0){
			Movie movie = MoviesList[currenMovieIndex];


			movie.name = movieNameText.value;
			movie.category = categoriesPopupList.value;
			movie.posterName = posterSprite.spriteName;
			movie.description = movieDescriptionText.value;
			movie.romanticScene = romanticSceneCheckBox.value;

			movie.directorPic = peoplePicsList[0].mainTexture;
			movie.mainActorPic = peoplePicsList[1].mainTexture;
			movie.mainActressPic = peoplePicsList[2].mainTexture;
			movie.writerPic = peoplePicsList[3].mainTexture;
			movie.producerPic= peoplePicsList[4].mainTexture;
			
			movie.director = peopleNamesList[0].text;
			movie.mainActor = peopleNamesList[1].text;
			movie.mainActress = peopleNamesList[2].text;
			movie.writer = peopleNamesList[3].text;
			movie.producer = peopleNamesList[4].text;

			MoviesList[currenMovieIndex] = movie;

			currentSelectedMovie.GetComponent<MovieTimeLineItem>().FillItemData(movie);
		}
	}

	public void FinishMovie(){
		if(moviesIndexesStarted.Count>0){
			movieCounter = 0;
			movieCounterLabel.text = "00:00";
			CancelInvoke("CountMovieCounter");

			finishedMoviePanel.gameObject.GetComponent<TweenAlpha>().Toggle();

			Movie finished = MoviesList[moviesIndexesStarted[moviesIndexesStarted.Count-1]];

			finished.status = 2;

			finishedMoviePanel.transform.GetChild(0).GetComponent<UILabel>().text = finished.name;
			finishedMoviePanel.transform.GetChild(1).GetChild(0).GetComponent<UISprite>().spriteName = finished.posterName;

			finishedMoviePanel.transform.GetChild(2).GetComponent<UILabel>().text = "$150,000";

			//CreateMoviePanel.alpha = 0;
			//MoviesList.RemoveAt(moviesIndexesStarted[moviesIndexesStarted.Count-1]);
			profitsLabel.text = "$"+ (Random.Range(30000, 1000000));
		}
	}

	public void closeFinish(){
		CreateMoviePanel.alpha = 1;
		finishedMoviePanel.alpha = 0;
	}

	public void ChoosePeople(UITexture pic, UILabel name){
		currentlySelectedPersonPhoto = pic;
		currentlySelectedPersonName = name;

	}


	///sloooooooooottt MAcchiineeee

	/*
	public void Match(string namee){
		cong.Toggle();

		matchSprite.spriteName = namee;
		matchSprite.GetComponent<TweenScale>().Toggle();

		if(namee == "bar_gift"){
			earnLabel.text = "You earnred a Gift!";
		}
		else if(namee == "bar_gyms"){
			earnLabel.text = "You earnred a Gym!";
		}
		else if(namee == "bar_money"){
			earnLabel.text = "You earnred Money!";
		}

	}

	public void enableCam(){
		cam.SetActive(true);
	}

	public void disableCam(){
		cam.SetActive(false);
	}
	*/


}
