using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public UiHanadler UiHanadler1;
    public GameObject Splashscreen;
    [Header("Componenet")]
    public Image FillingBar;


    [Header("Floating Manager")]
    internal float ValueBar;


    [Header("Boolean Manager")]
    internal bool GameLoaded = false;

    //private void Awake()
    //{
    //    PokiUnitySDK.Instance.sdkInitializedCallback = pokiSDKReady;
    //    PokiUnitySDK.Instance.init();
    //}
    void Start()
    {
        StartCoroutine(FillingController());
    }

    public void pokiSDKReady()
    {
        Debug.Log("Poki SDK is ready");
    }
    void Update()
    {
        if (GameLoaded == false)
        {
            FillingBar.fillAmount = ValueBar / 100;

            if (FillingBar.fillAmount == 1)
            {
                Debug.Log("Game Loaded");
                GameLoaded = true;
               Splashscreen.SetActive(false);
               UiHanadler1.BackToMianmaenu();
                //PlayFabManager.Instance.LoginwithCustromID();
                //BackgroundMusic.instance.PlayMusic();

            }
        }
    }


    IEnumerator FillingController()
    {
        if (GameLoaded == false)
        {
            yield return new WaitForSeconds(0.04f);
            ValueBar += 1;
            yield return new WaitForEndOfFrame();
            StartCoroutine(FillingController());
        }
    }
}
