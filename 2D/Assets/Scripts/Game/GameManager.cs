using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	/// <summary>
	/// The instance of the GameManager.
	/// </summary>
	private static GameManager _instance;

	/// <summary>
	/// Whether to show or hide the cursor during gameplay.
	/// </summary>
	public bool showCursor;
	/// <summary>
	/// Whether to lock the cursor during gameplay.
	/// </summary>
	public bool lockCursor;

	/// <summary>
	/// The position of the menu.
	/// </summary>
	private Vector2 menuPosition;
	/// <summary>
	/// The size of the menu.
	/// </summary>
	private Vector2 menuSize;
	/// <summary>
	/// The size of a button.
	/// </summary>
	private Vector2 buttonSize;

	/// <summary>
	/// Whether the game was paused.
	/// </summary>
	public bool paused { get; private set; }
	/// <summary>
	/// Whether the cursor was locked.
	/// </summary>
	private bool wasLocked = false;


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
		// Init
		menuSize = new Vector2(150, 150);
		buttonSize = new Vector2(100, 30);
		menuPosition = new Vector2(Screen.width / 2 - menuSize.x / 2, Screen.height / 2 - menuSize.y / 2);
		paused = false;
		wasLocked = false;
		Screen.lockCursor = lockCursor;
		Screen.showCursor = showCursor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Pause and unpause the game
		if (Input.GetButtonDown("Pause Menu"))
		{
			if (paused)
			{
				Screen.lockCursor = lockCursor;
				Screen.showCursor = showCursor;
			}
			else
			{
				Screen.lockCursor = false;
				Screen.showCursor = true;
			}
			paused = !paused;

			Object[] objects = FindObjectsOfType (typeof(GameObject));
			foreach (GameObject gameObject in objects) {
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

		if (Input.GetMouseButton(0) && !paused)
		{
			Screen.lockCursor = lockCursor;
			Screen.showCursor = showCursor;
		}
		if (!Screen.lockCursor && wasLocked)
		{
			wasLocked = false;
		}
		else if (Screen.lockCursor && !wasLocked)
		{
			wasLocked = true;
		}
	}

	void OnGUI ()
	{
		if (paused)
		{
			// Draw the screen
			GUI.Box(new Rect(menuPosition.x, menuPosition.y, menuSize.x, menuSize.y), "Pause");
			
			// Restart button
			if (GUI.Button(new Rect(menuPosition.x + 25, menuPosition.y + 40, buttonSize.x, buttonSize.y), "Restart"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			
			// Return to the game button
			if (GUI.Button(new Rect(menuPosition.x + 25, menuPosition.y + 75, buttonSize.x, buttonSize.y), "Back"))
			{
				paused = false;
				Screen.lockCursor = lockCursor;
				Screen.showCursor = showCursor;
			}

			// Quit to the game button
			if (GUI.Button(new Rect(menuPosition.x + 25, menuPosition.y + 110, buttonSize.x, buttonSize.y), "Quit"))
			{
				Application.Quit();
			}
		}
	}
}
