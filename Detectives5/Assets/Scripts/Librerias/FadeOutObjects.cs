using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FadeOutObjects : MonoBehaviour {
    bool Desvanecer;
    Color Transparencia = new Color(0,0,0,0);
    
    void Start()
    {
        Desvanecer = false;
        

    }
    public void FadeOut(GameObject Objeto) {

        Objeto.gameObject.GetComponent<Image>().color = Transparencia;
    }
}
