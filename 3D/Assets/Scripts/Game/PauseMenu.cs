using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// The pause label.
    /// </summary>
    private Text pauseLabel;
    /// <summary>
    /// The pause panel.
    /// </summary>
    private Image pausePanel;
    /// <summary>
    /// The restart button.
    /// </summary>
    private Button restartButton;
    /// <summary>
    /// The back to the game button.
    /// </summary>
    private Button backButton;
    /// <summary>
    /// The quit the game button.
    /// </summary>
    private Button quitButton;


	// Use this for initialization
	void Start ()
    {
        // The UI elements of the menu
        pauseLabel = GameObject.Find("PauseLabel").GetComponent<Text>();
        pausePanel = GameObject.Find("PausePanel").GetComponent<Image>();
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        pauseLabel.enabled = false;
        pausePanel.enabled = false;
        SwitchButtonState(restartButton, false);
        SwitchButtonState(backButton, false);
        SwitchButtonState(quitButton, false);
	}

    public void showMenu ()
    {
        pauseLabel.enabled = true;
        pausePanel.enabled = true;
        SwitchButtonState(restartButton, true);
        SwitchButtonState(backButton, true);
        SwitchButtonState(quitButton, true);
    }

    public void hideMenu()
    {
        pauseLabel.enabled = false;
        pausePanel.enabled = false;
        SwitchButtonState(restartButton, false);
        SwitchButtonState(backButton, false);
        SwitchButtonState(quitButton, false);
    }

    /// <summary>
    /// Switch the state of a button.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="state"></param>
    private void SwitchButtonState (Button button, bool state)
    {
        button.enabled = state;
        button.image.enabled = state;
        button.GetComponentInChildren<Text>().enabled = state;
    }
}
