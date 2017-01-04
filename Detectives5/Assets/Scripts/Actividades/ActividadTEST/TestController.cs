using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : BigMama
{
    public BigBoss bigBossScript;
    public string[] messages;

    private bool clickLocker;

    // Use this for initialization
    void Start ()
    {
        clickLocker = true;
    }

    public override void RemoteStart()
    {
        bigBossScript.Comenzar();
        clickLocker = true;
        StartTheGame();
    }

    // Update is called once per frame
    void Update ()
    {
        //no hay countdown, men !

        //si hay limite de tiempo, revisar aca
        if (bigBossScript.CheckOverClock())
        {
            bigBossScript.ResetClock();
            Debug.Log("MUERTE POR TIEMPOOOOOOOO");
            bigBossScript.SuddenDeath();
        }       
    }

    private void StartTheGame()
    {
        if (!bigBossScript.IsMusicPlaying())
            bigBossScript.PlayDefaultMusic();
        bigBossScript.SetMainMessage(messages[0]);

        clickLocker = false;
    }

    public void FinalCheckButton( bool isWin )
    {
        if (clickLocker)
            return;

        clickLocker = true;

        if (isWin)
        {
            if ( !bigBossScript.Good() )
            {
                //DELAY!!
                Invoke("StartTheGame", 0.9f);
            }
            else
            {
                Debug.Log("COMPLETE VICTORY");
            }
        }
        else
        {
            if ( bigBossScript.Bad() )
            {
                //true es game over, false solo error
            }
            else
            {
                Invoke("DelayedWrong", 0.9f);
            }
        }
    }

    private void DelayedWrong()
    {
        clickLocker = false;
    }

}
