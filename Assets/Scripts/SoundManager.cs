using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public GameObject bottleSound;
    public GameObject levelCompSound;
    public GameObject coinsSounds;
    public bool isMusicOn;
    public GameObject Bottlebreak;
    public GameObject Carsound;
    public GameObject Bikesound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BottleJumpSound()
    {
        if (!isMusicOn)
        {
            GameObject bt = Instantiate(bottleSound);
            Destroy(bt, 1);
        }

    }
    public void LevelCompSound()
    {
        if (!isMusicOn)
        {
            GameObject ls = Instantiate(levelCompSound);
            Destroy(ls, 3);
        }
    }
    public void CoinsSound()
    {
        if (!isMusicOn)
        {
            GameObject gs = Instantiate(coinsSounds);
            Destroy(gs, 2);
        }
    }public void BottleBreakSound()
    {
        if (!isMusicOn)
        {
            GameObject bs = Instantiate(Bottlebreak);
            Destroy(bs, 1);
        }
    }
    public void CarSound()
    {
        if (!isMusicOn)
        {
            GameObject bs = Instantiate(Carsound);
            Destroy(bs, 2.5f);
        }
    }
    public void BikeSound()
    {
        if (!isMusicOn)
        {
            GameObject bs = Instantiate(Bikesound);
            Destroy(bs, 2.5f);
        }
    }
}
