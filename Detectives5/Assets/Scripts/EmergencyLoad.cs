using UnityEngine;
using System.Collections;

public class EmergencyLoad : MonoBehaviour
{
    public Loading loadingCanvas;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void LoadWorldSelectScene(string name)
    {
        loadingCanvas.DoLoadLevel(name);
    }


}
