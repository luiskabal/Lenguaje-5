using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Template_Control : BigMama
{

    public string[] messages;
    public Level LevelSelector;

    private BigBoss Master;

    void Start()
    {
        Master = GetComponent<BigBoss>();
    }

    public override void RemoteStart()
    {
        Master.Comenzar();
        StartTheGame();
    }

    void Update()
    {
        //si hay limite de tiempo, revisar aca
        if (Master.CheckOverClock())
        {
            Master.ResetClock();
            Master.SuddenDeath();
        }
    }

    private void StartTheGame()
    {
        if (!Master.IsMusicPlaying())
            Master.PlayDefaultMusic();
        Master.SetMainMessage(messages[0]);

        Armador();
    }

    private void Randomize()
    {

    }
    
    private void Armador()
    {
        Randomize();
        
    }
    
    public void Analize()
    {
        if (true)
        {
            if (!Master.Good())
            {
                if (!Master.StarWon())
                {
                    //New round
                }
                else
                {
                    //New problem
                    Invoke("ArmadorA", 2);
                }
            }
        }
        else
        {
            //Bad, Life taken
            Master.Bad();
        }
    }
}
