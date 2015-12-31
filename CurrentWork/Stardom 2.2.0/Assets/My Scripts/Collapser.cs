using UnityEngine;
using System.Collections;

public class Collapser : MonoBehaviour {

	public Vector3 originalPos;
	public Vector3 collapsePos;

	public int eqIconNum;

	private TweenScale scaleTweener;
	private TweenPosition posTweener;

	public GameObject eqButtonGO;


	void Start () {
		originalPos = gameObject.transform.position;
		eqButtonGO = GameObject.FindGameObjectWithTag ("ic_" + eqIconNum) as GameObject;
		///collapsePos = eqButtonGO.transform.localPosition;



		scaleTweener = gameObject.GetComponent<TweenScale> ();
		posTweener = gameObject.GetComponent<TweenPosition> ();

		posTweener.from = originalPos;
		posTweener.to = collapsePos;
	}
	
	public void CollapseMe () {
		scaleTweener.Toggle ();
		posTweener.Toggle ();

		eqButtonGO.GetComponentInChildren<TweenScale> ().Toggle ();

		//MiddleWindowCollapser.Instance.currentContentSprite.spriteName = "ic_" + eqIconNum;

		Debug.Log ("collapse mee");
	}
}
