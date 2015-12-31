using UnityEngine;
using System.Collections;

public class ScreensManager : MonoBehaviour {

	public static ScreensManager Instance;

	
	public Transform HomeScreen;
    public Transform ProfileScreen;
    public Transform MarketScreen;
    public Transform StoreScreen;
    public Transform MoviesScreen;
    
	public Transform StatsScreen;
    public Transform SettingsScreen;

    //public GameObject UserScreen;

	public Transform lastActivatedTopBarButton;
	private Transform lastOpenedTopBarScreen;

    public TweenAlpha AboutWindowTweener;
    public TweenAlpha GiftsWindowTweener;
    public TweenAlpha GiftsWallsWindowTweener;
    public TweenAlpha AchievWindowTweener;
    public TweenAlpha FortuneWindowTweener;

    public Transform lastActivatedBotButton;
    private TweenAlpha lastOpenedBotScreenTweener;

	void Awake () {
		Instance = this;


        HomeScreen.gameObject.SetActive(true);
        lastOpenedTopBarScreen = HomeScreen;

        ProfileScreen.gameObject.SetActive(false);
        MarketScreen.gameObject.SetActive(false);
        StoreScreen.gameObject.SetActive(false);
        MoviesScreen.gameObject.SetActive(false);
       
        StatsScreen.gameObject.SetActive(false);
        SettingsScreen.gameObject.SetActive(false);

        lastOpenedBotScreenTweener = AboutWindowTweener;
	}

	void Start(){

	}

    public void SwtichTopBarTabs(Transform tNextScreen, Transform tSelf)
    {
        if (tSelf != lastActivatedTopBarButton)
        {
            tNextScreen.gameObject.SetActive(true);
            lastOpenedTopBarScreen.gameObject.SetActive(false);
            lastOpenedTopBarScreen = tNextScreen;



            lastActivatedTopBarButton.GetComponentInChildren<TweenAlpha>().Toggle();
            lastActivatedTopBarButton.GetComponentInChildren<TweenColor>().Toggle();
            lastActivatedTopBarButton = tSelf;
            //tSelf.GetComponentInChildren<TweenAlpha>().Toggle();
        }
        else
        {
            tSelf.GetComponentInChildren<TweenAlpha>().Toggle();
            tSelf.GetComponentInChildren<TweenColor>().Toggle();
        }
    }


    public void SwitchBottomBarTabs(TweenAlpha tNextScreenTweener, Transform tSelf)
    {

        if (tSelf != lastActivatedBotButton)
        {
            tNextScreenTweener.Toggle();
            lastOpenedBotScreenTweener.Toggle();
            lastOpenedBotScreenTweener = tNextScreenTweener;



            lastActivatedBotButton.GetComponentInChildren<TweenScale>().Toggle();
            lastActivatedBotButton = tSelf;
        }
        else
        {
            tSelf.GetComponentInChildren<TweenScale>().Toggle();
        }
    }



}
