using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
