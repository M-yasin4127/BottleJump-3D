using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameObject bottleSound;
    public GameObject levelCompSound;
    public GameObject coinsSounds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BottleJumpSound()
    {
       GameObject bt = Instantiate(bottleSound);
        Destroy(bt, 1);
    }
    public void LevelCompSound()
    {
       GameObject ls = Instantiate(levelCompSound);
        Destroy(ls, 3);
    }
    public void CoinsSound()
    {
        GameObject gs = Instantiate(coinsSounds);
        Destroy(gs, 2);
    }

}
