using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
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

	public bool paused { get; private set; }

	// Use this for initialization
	void Start () {
		// Init
		menuSize = new Vector2(150, 150);
		buttonSize = new Vector2(100, 30);
		menuPosition = new Vector2(Screen.width / 2 - menuSize.x / 2, Screen.height / 2 - menuSize.y / 2);
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Pause and unpause the game
		if (Input.GetButtonDown("Pause Menu"))
		{
			paused = !paused;
			Object[] objects = FindObjectsOfType (typeof(GameObject));
			foreach (GameObject gameObject in objects) {
				if (paused)
				{
					gameObject.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					gameObject.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	void OnGUI () {
		if (paused)
		{
			// Show and unlock cursor to use the menu
			Screen.showCursor = true;
			Screen.lockCursor = false;

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
			}

			// Quit to the game button
			if (GUI.Button(new Rect(menuPosition.x + 25, menuPosition.y + 110, buttonSize.x, buttonSize.y), "Quit"))
			{
				Application.Quit();
			}
		}
	}
}
