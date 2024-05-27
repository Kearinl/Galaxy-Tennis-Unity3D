// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public Button backOrQuitButton;
    public Button loadSceneButton1;
    public Button loadSceneButton2;

    public GameObject playMenuObjects;
    public GameObject optionsMenuObjects;

    public GameObject objectToDisable;
    public GameObject objectToEnable;

    public AudioClip buttonClickSound;

    void Start()
    {
        if (backOrQuitButton != null)
        {
            backOrQuitButton.onClick.AddListener(OnBackOrQuitButtonClick);
        }
        else
        {
            Debug.LogError("BackOrQuitButton reference is not assigned. Please assign it in the Unity Editor.");
        }

        if (loadSceneButton1 != null)
        {
            loadSceneButton1.onClick.AddListener(() => LoadScene("PlayerLevel1"));
        }
        else
        {
            Debug.LogError("LoadSceneButton1 reference is not assigned. Please assign it in the Unity Editor.");
        }

        if (loadSceneButton2 != null)
        {
            loadSceneButton2.onClick.AddListener(() => LoadScene("AILevel1"));
        }
        else
        {
            Debug.LogError("LoadSceneButton2 reference is not assigned. Please assign it in the Unity Editor.");
        }

        // Initially, enable the playMenuObjects and disable the optionsMenuObjects
        SetActiveSection(playMenuObjects, true);
        SetActiveSection(optionsMenuObjects, false);
    }

    void OnBackOrQuitButtonClick()
    {
        PlayButtonClickSound();

        // Disable one object and enable another
        SetActiveSection(objectToDisable, false);
        SetActiveSection(objectToEnable, true);
    }

    void LoadScene(string sceneName)
    {
        PlayButtonClickSound();

        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("SceneName is not provided.");
        }
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

