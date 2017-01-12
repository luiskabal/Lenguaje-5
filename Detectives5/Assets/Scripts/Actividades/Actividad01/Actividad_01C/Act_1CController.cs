using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_1CController : MonoBehaviour {
    BigBoss bb;
    public GameObject[] TodasCartas;
    public GameObject[] TodasSecuencias;
    static int numeroSecuencia;

    // Use this for initialization
    void Start () {
        numeroSecuencia = 0;
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        desaparecerTodasCartas();
        mostrarCarta();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void abrirCarta()
    {
        //FALTA CERRAR LA ANTERIOR Y CAMBIARL

        TodasSecuencias[numeroSecuencia].gameObject.SetActive(true);
        TodasSecuencias[numeroSecuencia].gameObject.GetComponent<Animator>().SetTrigger("Carta_On");
        Invoke("desaparecerTodasCartas", 1f);
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
        if (o.tag == "Verdadero")
        {
            numeroSecuencia++;
            mostrarCarta();
            ganar();
        }
        else {

            perder();
        }

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
