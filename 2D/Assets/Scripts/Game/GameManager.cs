using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	/// <summary>
	/// The instance of the GameManager.
	/// </summary>
	private static GameManager _instance;

    /// <summary>
    /// The pause menu script.
    /// </summary>
    private PauseMenu pauseMenu;

	/// <summary>
	/// Whether to show or hide the cursor during gameplay.
	/// </summary>
	public bool showCursorMode;
	/// <summary>
	/// Whether to lock the cursor during gameplay.
	/// </summary>
	public CursorLockMode lockCursorMode;

    /// <summary>
    /// Whether the game was paused.
    /// </summary>
    public bool paused { get; private set; }


	/// <summary>
	/// Retrieve the instance of the game manager.
	/// </summary>
	/// <value>The game manager.</value>
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


	// Use this for initialization
	void Start ()
	{
        // The pause menu
        pauseMenu = GetComponent<PauseMenu>();

        // Init the cursor behaviour
        Cursor.lockState = lockCursorMode;
        Cursor.visible = showCursorMode;

        paused = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        // Pause and unpause the game
        if (Input.GetButtonDown("Pause Menu"))
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

    /// <summary>
    /// Fired When the player selects the restart button.
    /// </summary>
    public void OnRestartButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    /// <summary>
    /// Fired when the player selects the back button.
    /// </summary>
    public void OnBackButton()
    {
        hidePauseMenu();
    }

    /// <summary>
    /// Fired when the player selects the quit button.
    /// </summary>
    public void OnQuitButton()
    {
        Application.Quit();
    }

    /// <summary>
    /// Show the pause menu and unlock/show cursor.
    /// </summary>
    private void showPauseMenu ()
    {
        pauseMenu.showMenu();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        paused = true;
    }

    /// <summary>
    /// Hide the pause menu and reset cursor to wanted mode.
    /// </summary>
    private void hidePauseMenu()
    {
        pauseMenu.hideMenu();
        Cursor.lockState = lockCursorMode;
        Cursor.visible = showCursorMode;
        paused = false;
    }
}
