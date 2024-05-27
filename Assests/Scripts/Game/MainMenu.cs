// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/


using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button quitButton;
    public Button singleplayerButton;
    public Button multiplayerButton;

    public AudioClip buttonClickSound;

    public GameObject singleplayerObjectsToEnable;
    public GameObject singleplayerObjectsToDisable;

    public GameObject multiplayerObjectsToEnable;
    public GameObject multiplayerObjectsToDisable;

    void Start()
    {
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogError("QuitButton reference is not assigned. Please assign it in the Unity Editor.");
        }

        if (singleplayerButton != null)
        {
            singleplayerButton.onClick.AddListener(OnSingleplayerButtonClick);
        }
        else
        {
            Debug.LogError("SingleplayerButton reference is not assigned. Please assign it in the Unity Editor.");
        }

        if (multiplayerButton != null)
        {
            multiplayerButton.onClick.AddListener(OnMultiplayerButtonClick);
        }
        else
        {
            Debug.LogError("MultiplayerButton reference is not assigned. Please assign it in the Unity Editor.");
        }
    }

    void OnSingleplayerButtonClick()
    {
        PlayButtonClickSound();
        SetActiveSection(singleplayerObjectsToEnable, true);
        SetActiveSection(singleplayerObjectsToDisable, false);
    }

    void OnMultiplayerButtonClick()
    {
        PlayButtonClickSound();
        SetActiveSection(multiplayerObjectsToEnable, true);
        SetActiveSection(multiplayerObjectsToDisable, false);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            AudioSource.PlayClipAtPoint(buttonClickSound, Camera.main.transform.position);
        }
    }

    void SetActiveSection(GameObject targetObjects, bool isActive)
    {
        if (targetObjects != null)
        {
            targetObjects.SetActive(isActive);
        }
    }
}

