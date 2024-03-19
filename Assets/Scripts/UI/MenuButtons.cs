using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeMenuBool();
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
    public void EscapeMenuBool()
    {
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
       // GameManager.instance.Resume();
        CurrentMenu.SetActive(false);
        CurrentMenu = null;
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
}
