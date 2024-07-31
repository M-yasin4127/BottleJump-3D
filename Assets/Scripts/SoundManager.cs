using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameObject bottleSound;
    public GameObject levelCompSound;
    public GameObject coinsSounds;
    public bool isMusicOn;
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
    }

}
