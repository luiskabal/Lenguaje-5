using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class LoginController : MonoBehaviour
{
    public GameObject btnLogin;
    public GameObject inputUser;
    public GameObject inputPassword;
    public Loading loadScript;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnLogin()
    {
        string url = "localhost:8080/login/" + inputUser.GetComponent<InputField>().text + "/" + inputPassword.GetComponent<InputField>().text;
        GetComponent<Services>().GET(url, onComplete);
    }

    void onComplete(JSONObject results)
    {
        if (results.b)
        {

            string pathFile = "/Saves/playerInfo_" + inputUser.GetComponent<InputField>().text + ".dat";

            if (File.Exists(Application.persistentDataPath + pathFile))
            {
                SaveLoadPlayer.load(inputUser.GetComponent<InputField>().text, GameManager.instance.playerState);
            }
            else
            {
                SaveLoadPlayer.save(inputUser.GetComponent<InputField>().text, GameManager.instance.playerState);
            }

            Debug.Log("Puntos: " + GameManager.instance.playerState.points);
            Debug.Log("Etapa Actual: " + GameManager.instance.playerState.etapaActual);

            string url = "localhost:8080/api/player";

            JSONObject json = new JSONObject(JSONObject.Type.OBJECT);
            json.AddField("points", GameManager.instance.playerState.points);
            json.AddField("lastDateTime", GameManager.instance.playerState.lastDateTime.ToString("yyyy-MM-dd H:mm:ss"));

            GetComponent<Services>().POST(url, json, null);

            /*cameraMover.MoveCamera();
            for (int i = 0; i < 4; i++)
            {
                panelMover.MoveElement(i);
            }
            btnVolver.GetComponent<Animator>().SetTrigger("BotonActivar");*/

            //IR A LEVEL SELECT
            loadScript.DoLoadLevel("MundoEtapa");

        }
        else
        {
            Debug.Log("Fallo Login");
        }


    }
}
