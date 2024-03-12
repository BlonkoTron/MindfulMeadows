using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject CurrentMenu;
    public GameObject GameSetting;
    public GameObject AudioSetting;

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
    public void SettingsMenu()
    {
        if (SettingMenu.activeSelf)
        {
         //   GameManager.instance.Resume();
            SettingMenu.SetActive(false);
        }
        else
        {
          //  GameManager.instance.Pause();
            SettingMenu.SetActive(true);
        }
    }
    void SwitchMenu(GameObject newMenu)
    {
        if (CurrentMenu != null)
        {
            CurrentMenu.SetActive(false);
        }

        newMenu.SetActive(true);
        CurrentMenu = newMenu;
    }
    public void GameSettings()
    {
       // GameManager.instance.Pause();
        SwitchMenu(GameSetting);
    }
    public void AudioSettings()
    {
        // GameManager.instance.Pause();
        SwitchMenu(AudioSetting);
    }

    public void ExitSettings()
    {
       // GameManager.instance.Resume();
        CurrentMenu.SetActive(false);
        CurrentMenu = null;
    }
}
