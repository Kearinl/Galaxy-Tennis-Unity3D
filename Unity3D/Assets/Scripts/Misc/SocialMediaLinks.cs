// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;
using UnityEngine.UI;

public class SocialMediaLinks : MonoBehaviour
{
    public Button facebookButton;
    public Button twitterButton;
    public Button discordButton;
    public Button youtubeButton;
    public Button websiteButton;

    void Start()
    {
        // Add click listeners to the buttons
        facebookButton.onClick.AddListener(OpenFacebook);
        twitterButton.onClick.AddListener(OpenTwitter);
        discordButton.onClick.AddListener(OpenDiscord);
        youtubeButton.onClick.AddListener(OpenYouTube);
        websiteButton.onClick.AddListener(OpenWebsite);
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/groups/1070471900857213");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/OHappyDayzGames");
    }

    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.com/invite/nkjGSxYzr2");
    }

    public void OpenYouTube()
    {
        Application.OpenURL("https://www.youtube.com/@happy-dayz-games");
    }

    public void OpenWebsite()
    {
        Application.OpenURL("https://happydayzgames.com/");
    }
}

