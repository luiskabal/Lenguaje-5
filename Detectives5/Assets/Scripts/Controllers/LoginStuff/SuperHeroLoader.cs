using UnityEngine;
using System.Collections;

public class SuperHeroLoader : MonoBehaviour
{

    public GameObject gm;
    public GameManager.GameState gs;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gm);
            GameManager.instance.SetGameState(gs);
        }
        else
        {
            GameManager.instance.SetGameState(gs);
        }
    }

}
