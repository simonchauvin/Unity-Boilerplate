using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    private Text pauseLabel;
    private Image pausePanel;
    private Button restartButton;
    private Button backButton;
    private Button exitButton;


	void Start ()
    {
        // The UI elements of the menu
        pauseLabel = GameObject.Find("PauseLabel").GetComponent<Text>();
        pausePanel = GameObject.Find("PausePanel").GetComponent<Image>();
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        pauseLabel.enabled = false;
        pausePanel.enabled = false;
        SwitchButtonState(restartButton, false);
        SwitchButtonState(backButton, false);
        SwitchButtonState(exitButton, false);
	}

    public void showMenu ()
    {
        pauseLabel.enabled = true;
        pausePanel.enabled = true;
        SwitchButtonState(restartButton, true);
        SwitchButtonState(backButton, true);
        SwitchButtonState(exitButton, true);

        EventSystem.current.SetSelectedGameObject(backButton.gameObject);
    }

    public void hideMenu()
    {
        pauseLabel.enabled = false;
        pausePanel.enabled = false;
        SwitchButtonState(restartButton, false);
        SwitchButtonState(backButton, false);
        SwitchButtonState(exitButton, false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    private void SwitchButtonState (Button button, bool state)
    {
        button.enabled = state;
        button.image.enabled = state;
        button.GetComponentInChildren<Text>().enabled = state;
    }
}
