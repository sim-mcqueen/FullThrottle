//////////////////////////////
//// Name: Andrew Dahlman-Oeth
//// Date: 1/19/22
//// Desc: Handles menu functions
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public string PlayScene;
    public string MenuScene = "MainMenu";
    public void Play()
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void Options()
    {
        if(mainMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else if(optionsMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }



    public void Quit()
    {
        Application.Quit();
    }
}
