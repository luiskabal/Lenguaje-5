using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanicas_3C : MonoBehaviour {
    posicionarObjetos po;
	// Use this for initialization
	void Start () {
        po=GameObject.FindWithTag("Scripts").GetComponent<posicionarObjetos>();
        po.guardarLocacionesTodosLosObjetos();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
