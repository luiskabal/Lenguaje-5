using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GotoLogin : MonoBehaviour
{
    public float delayInSeconds;

	// Use this for initialization
	void Start ()
    {
        Invoke("ToLogin", delayInSeconds);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void ToLogin()
    {
        SceneManager.LoadScene("Login");
    }
}
