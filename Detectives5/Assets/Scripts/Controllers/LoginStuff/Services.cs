using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class Services : MonoBehaviour
{
    public delegate void onComplete(JSONObject result);

    private onComplete CallBackFunction;

    public void GET(string url, onComplete onComplete)
    {        
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www, onComplete));
    }

    public void POST(string url, JSONObject json, onComplete onComplete)
    {
        Dictionary<string,string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        headers.Add("Cookie", "Our session cookie");             

        Debug.Log(json);

        byte[] pData = Encoding.UTF8.GetBytes(json.Print().ToCharArray());

        WWW www = new WWW(url, pData, headers);
        StartCoroutine(WaitForRequest(www, onComplete));
    }

    private IEnumerator WaitForRequest(WWW www, onComplete onComplete)
    {

        yield return www;
        // check for errors
        if (www.error == null)
        {
            if(onComplete != null)
            {
                /*JSONNode json = JSON.Parse(www.text);
                if (json == null)
                    json = new JSONData(www.text);*/
                JSONObject json = new JSONObject(www.text);
                //Debug.Log(results);
                onComplete(json);
            }            
        }
        else {
            Debug.Log(www.error);
        }
    }
}
