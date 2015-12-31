using UnityEngine;
using System.Collections;

public class TF_DisableInput : MonoBehaviour {

    private UIInput inputTextField;

	// Use this for initialization
	void Start () {
        inputTextField = GetComponent<UIInput>();
	}
	
	// Update is called once per frame
	public void ToggleEnablingInput () {

        if (!inputTextField)
        {
            Debug.LogWarning("Amera: No input Text Field");
            return;

        }

        inputTextField.enabled = !inputTextField.enabled;
	}
}
