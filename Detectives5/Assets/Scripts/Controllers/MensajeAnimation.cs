using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeAnimation : MonoBehaviour
{
    public float espera;

    private float timer;
    private bool animLock;
    private bool isShown;
    private bool GameStarted;

    private Animator myAnimator;

	// Use this for initialization
	void Start ()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        animLock = false;
        isShown = true;
        GameStarted = false;

        timer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameStarted)
        {
            timer += Time.deltaTime;

            if (espera < timer && isShown)
            {
                HideText();

                //Para que no vuelva a repetir la acción
                GameStarted = false;
            }
        }
	}

    public void ChangeState()
    {
        if (isShown)
            HideText();
        else
            ShowText();
    }

    private void ShowText()
    {
        if (animLock)
            return;

        myAnimator.SetTrigger("UI_TEXT_ON");
        animLock = true;

        Invoke("ReleaseLock", 0.99f);
        isShown = true;
    }

    private void HideText()
    {
        if (animLock)
            return;

        myAnimator.SetTrigger("UI_TEXT_OFF");
        animLock = true;

        Invoke("ReleaseLock", 0.99f);
        isShown = false;
    }

    private void ReleaseLock()
    {
        animLock = false;
    }

    public void GameStart()
    {
        GameStarted = true;
    }

}
