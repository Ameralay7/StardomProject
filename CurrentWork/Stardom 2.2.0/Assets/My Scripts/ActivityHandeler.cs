using UnityEngine;
using System.Collections;

public class ActivityHandeler : MonoBehaviour {

	public void DisableGameObject () {
        gameObject.SetActive(false);
	}

    public void EnableGameObject()
    {
        gameObject.SetActive(true);

    }
}
