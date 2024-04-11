using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{

    [SerializeField] private GameObject SettingMenu;
    [SerializeField] private GameObject EscapeMenu;
    [SerializeField] private GameObject CurrentMenu;
    [SerializeField] private GameObject GameSetting;
    [SerializeField] private GameObject AudioSetting;
    [SerializeField] private GameObject VideoSetting;
    [SerializeField] private GameObject ControlSetting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            EscapeMenuBool();
            Debug.Log("Escape Pressed");
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next Scene");
    }
    public void QuitGame()
    {
        UnityEngine.Application.Quit();
        Debug.Log("Game Quit");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game Screen");
        // Add this to the game manager script
        //FindObjectOfType<GameManager>().RestartGame();
        Debug.Log("Reloading New Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Loading Menu");
    }

    // Settings Menu
    public void SettingsMenuBool()
    {
        if (SettingMenu.activeSelf)
        {
            SettingMenu.SetActive(false);
        }
        else
        {
            SettingMenu.SetActive(true);
        }
        Debug.Log("Settings Menu");
    }
    public void EscapeMenuBool()
    {
        if (Interaction.isInteracting)
        {
            return;
        }
        if (EscapeMenu.activeSelf)
        {
            //   GameManager.instance.Resume();
            EscapeMenu.SetActive(false);
        }
        else
        {
            //  GameManager.instance.Pause();
            EscapeMenu.SetActive(true);
        }
        Debug.Log("Escape Menu Open/Closed");
    }

    // Switching between settings
    void SwitchMenu(GameObject newMenu)
    {
        if (CurrentMenu != null)
        {
            CurrentMenu.SetActive(false);
        }

        newMenu.SetActive(true);
        CurrentMenu = newMenu;
    }
    public void ExitSettings()
    {
        CurrentMenu.SetActive(false);
        CurrentMenu = null;
        Debug.Log("Exiting Settings");
    }

    public void GameSettings()
    {
        SwitchMenu(GameSetting);
        Debug.Log("Switching to game settings");
    }
    public void AudioSettings()
    {
        SwitchMenu(AudioSetting);
        Debug.Log("Switching to audio settings");
    }
    public void VideoSettings()
    {
        SwitchMenu(VideoSetting);
        Debug.Log("Switching to video settings");
    }   
    public void ControlSettings()
    {
        SwitchMenu(ControlSetting);
        Debug.Log("Switching to control settings");
    }
}
