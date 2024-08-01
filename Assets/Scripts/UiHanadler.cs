using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHanadler : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject LevelCompScreen;
    public GameObject GameOverScreen;
    public GameObject menuScreen;
    public GameObject soundOff;
    public GameObject soundOn;
    public SoundManager soundManager1;
    public GameObject BottleSckincreen;

    public void MainMainScreen()
    {
        MainMenu.SetActive(false);
    }
    public void LevelComScreen()
    {
        LevelCompScreen.SetActive(true);   
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true); 
    }

    public void MenuScreen()
    {
        menuScreen.SetActive(true);
        MainMenu.SetActive(false);
    }
    public  void BackToMianmaenu()
    {
        menuScreen.SetActive(false);
        MainMenu.SetActive(true);
        BottleSckincreen.SetActive(false);
    }
    public void SounOff()
    {
        soundManager1.EnableSounds();
        soundOff.SetActive(false);
        soundOn.SetActive(true);
    }
    public void SounOn()
    {
        soundManager1.DisableSounds();
        soundOff.SetActive(true);
        soundOn.SetActive(false);
    }

    public  void SckinScreen()
    {
        BottleSckincreen.SetActive(true);
        MainMenu.SetActive(false);
    }

}
