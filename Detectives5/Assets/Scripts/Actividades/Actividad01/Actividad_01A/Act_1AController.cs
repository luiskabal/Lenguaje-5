using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_1AController : MonoBehaviour {
    BigBoss bb;
    List<int> numeroCartas = new List<int>();
    public GameObject[] TodasCartas;
    NumeroRandom nr = new NumeroRandom();
    static int numeroInicial;
    // Use this for initialization
    void Start () {
        numeroInicial = 0;
        generarCartaRandom();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        //iniciar();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
    void iniciar() {
        desaparecerFrases();
       
        Invoke("deshavilitarCartas", 1f);
        Invoke("abrirCarta",2f);
     
    }

    void desaparecerFrases() {

        //METODO QUE DESAPARECE FRASES
    }

    void deshabilitarCartas() {
        for (int i = 0; i < TodasCartas.Length; i++)
        {
            TodasCartas[i].SetActive(false);
        }
    }
    public void abrirCarta() {
        TodasCartas[numeroCartas[numeroInicial]].gameObject.SetActive(true);
        TodasCartas[numeroCartas[numeroInicial]].GetComponent<Animator>().SetTrigger("Carta_On");
    }
    public void cerrarCarta()
    {
        TodasCartas[numeroCartas[numeroInicial]].GetComponent<Animator>().SetTrigger("Carta_Off");
    }

    public void verificarEleccion(Button b) {
        if (b.tag == "Verdadero")
        {
            b.GetComponent<Button>().interactable = false;
            
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
                cerrarCarta();
                numeroInicial++;
                iniciar();
            }
        }
    }
    void perder()
    {
        bb.Bad();
    }
    void generarCartaRandom()
    {
        nr.GNR_Numeros(numeroCartas, TodasCartas.Length);
    }
}
