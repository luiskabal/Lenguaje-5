using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public Fx scriptFx;
    public Music scriptMusic;
    public Badges scriptBadges;
    public GameObject childObjectGroup;
    public Animator musicaAnimator;
    public Animator sonidoAnimator;

    public CanvasGroup[] usedCanvas;


    private bool isPaused;

	// Use this for initialization
	void Start ()
    {
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ToggleSound()
    {
        scriptFx.ToggleMute();
        Debug.Log(scriptFx.GetMuteState());
        if ( scriptFx.GetMuteState() )
        {
            scriptFx.FullVolumeDown(0);
            sonidoAnimator.SetTrigger("SONIDO_OFF");
        }
        else
        {
            scriptFx.FullVolumeUp(0.6f);
            sonidoAnimator.SetTrigger("SONIDO_ON");
        }    
    }

    public void ToggleMusic()
    {
        //scriptFx.GetMuteState();
        if(scriptMusic.ToggleMute())
        {
            musicaAnimator.SetTrigger("MUSICA_OFF");
        }
        else
        {
            musicaAnimator.SetTrigger("MUSICA_ON");
        }
    }

    public void ReloadCurrent()
    {
        scriptBadges.ReloadCurrentScene();
    }

    public void LoadLevelSelect()
    {
        scriptBadges.LoadWorldSelectScene();
    }

    public void StopTime()
    {
        Debug.Log("ZA WARUDO !");
        Time.timeScale = 0;
        LockCanvas();
        isPaused = true;
        childObjectGroup.SetActive(true);
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
        UnlockCanvas();
        isPaused = false;
        childObjectGroup.SetActive(false);
    }

    private void LockCanvas()
    {
        for (int i = 0; i < usedCanvas.Length; i++)
        {
            usedCanvas[i].interactable = false;
        }
    }

    private void UnlockCanvas()
    {
        for (int i = 0; i < usedCanvas.Length; i++)
        {
            usedCanvas[i].interactable = true;
        }
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
