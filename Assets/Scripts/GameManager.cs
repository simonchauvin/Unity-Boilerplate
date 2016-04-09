using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

    public bool showCursorMode;
    public CursorLockMode lockCursorMode;

    private static PauseMenu pauseMenu;
    public static bool paused { get; private set; }


	public static GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.Find("GameManager").GetComponent<GameManager>();
			}
			return _instance;
		}
	}


	void Start ()
	{
        // The pause menu
        pauseMenu = GetComponent<PauseMenu>();

        // Init the cursor behaviour
        Cursor.lockState = lockCursorMode;
        Cursor.visible = showCursorMode;

        paused = false;
	}
	
	void Update ()
	{
        // Pause and unpause the game
        if (Input.GetButtonDown("Pause"))
        {
            if (paused)
            {
                hidePauseMenu();
            }
            else
            {
                showPauseMenu();
            }

            // Activate and deactivate game objects
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject gameObject in objects)
            {
                if (paused)
                {
                    gameObject.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    gameObject.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

#if UNITY_WEBPLAYER || UNITY_WEBGL
		// Go fullscreen
		if (Input.GetKeyDown(KeyCode.F))
		{
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
		}
#endif
	}

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackButton()
    {
        hidePauseMenu();
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    private void showPauseMenu ()
    {
        pauseMenu.showMenu();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        paused = true;
    }

    private void hidePauseMenu()
    {
        pauseMenu.hideMenu();
        Cursor.lockState = lockCursorMode;
        Cursor.visible = showCursorMode;
        paused = false;
    }
}
