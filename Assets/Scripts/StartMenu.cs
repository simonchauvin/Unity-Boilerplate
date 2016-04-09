using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public string sceneName;


	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (Input.GetButton("Submit"))
		{
            SceneManager.LoadScene(sceneName);
		}
	}
}
