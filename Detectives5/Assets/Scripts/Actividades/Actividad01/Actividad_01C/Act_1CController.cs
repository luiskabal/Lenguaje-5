using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_1CController : MonoBehaviour {
    BigBoss bb;
    posicionarObjetos po;
    ColisionarObjetos co;
    public GameObject[] TodasCartas;
    public GameObject[] TodasSecuencias;
    static int numeroSecuencia;

    // Use this for initialization
    void Start () {
        po = GameObject.FindWithTag("Scripts").GetComponent<posicionarObjetos>();
        co = GameObject.FindWithTag("Scripts").GetComponent<ColisionarObjetos>();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        po.guardarLocacionesTodosLosObjetos();
        numeroSecuencia = 0;      
        desaparecerTodasCartas();
        mostrarCarta();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void guardarPosiciones() {
        po.guardarLocacionesTodosLosObjetos();
    }
    public void abrirCarta()
    {
        //FALTA CERRAR LA ANTERIOR Y CAMBIARL
        deshabilitarMovimiento();
        TodasSecuencias[numeroSecuencia].gameObject.SetActive(true);
        TodasSecuencias[numeroSecuencia].gameObject.GetComponent<Animator>().SetTrigger("Carta_On");
        Invoke("desaparecerTodasCartas", 1f);

        Invoke("guardarPosiciones",1f);
        Invoke("habilitarMovimiento", 1.1f);
    }
    void deshabilitarMovimiento()
    {
        for (int i = 0; i < po.objetos.Length; i++)
        {
            po.objetos[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void habilitarMovimiento() {
        for (int i=0;i<po.objetos.Length;i++) {
            po.objetos[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
       
    void mostrarCarta()
    {
        if (numeroSecuencia <= 3)
        {
            TodasCartas[0].gameObject.SetActive(true);
        }
        else
        {
            if (numeroSecuencia >= 4 && numeroSecuencia <= 6)
            {
                TodasCartas[1].gameObject.SetActive(true);
            }
            else
            {
                TodasCartas[2].gameObject.SetActive(true);

            }
        }

    }
    public void verificarEleccion(GameObject o) {
        Debug.Log(o.name);
        co.detectarColision(o);
        if (co.Tocado) {
            if (co.Acertado)
            {
                Debug.Log("LO LOGRASTE");

            }
            else
            {
                Debug.Log("BUUUU");
            }
        }
       
        co.reiniciarCollision();
    }
    void ganar()
    {
        if (!bb.Good())
        {
            if (bb.StarWon())
            {
            }
        }
    }
    void perder()
    {
        bb.Bad();
    }
    void desaparecerTodasCartas()
    {
        for (int i = 0; i < TodasCartas.Length; i++)
        {
            TodasCartas[i].SetActive(false);
        }

    }


}
