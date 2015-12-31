using UnityEngine;
using System.Collections;

public class UpdateChatAllData : MonoBehaviour {



	// Use this for initialization
	void Start () {
		EventDelegate.Add(gameObject.GetComponent<UIInput>().onSubmit, UpdateData);
	}
	
	// Update is called once per frame
	void UpdateData () {
		//Debug.Log (gameObject.GetComponent<UIInput>().);
	}
}
