using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VerificarBoton : MonoBehaviour {
    static string nombreBoton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     void verificarBoton() {
        nombreBoton=this.gameObject.tag;
        
        Debug.Log(this.gameObject.name);
    }
}
