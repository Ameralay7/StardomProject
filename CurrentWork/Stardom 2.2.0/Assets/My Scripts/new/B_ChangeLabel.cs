using UnityEngine;
using System.Collections;

public class B_ChangeLabel : MonoBehaviour {

    public string textChange;

    private UILabel textLabel;
    private string originalText;

	// Use this for initialization
	void Start () {

       

        textLabel = GetComponent<UILabel>();
        if (!textLabel)
        {
            textLabel = GetComponentInChildren<UILabel>();
        }

        if(textLabel)
            originalText = textLabel.text;
	}
	
	// Update is called once per frame
	public void ChangeLabelValue () {
        if (!textLabel)
        {
            Debug.LogWarning("Amera: No input Text Field");
            return;
        }

        if (textLabel.text != textChange)
            textLabel.text = textChange;
        else
            textLabel.text = originalText;
	}
}
