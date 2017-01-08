using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_1AController : MonoBehaviour {
    BigBoss bb;
    List<int> numeroCartas = new List<int>();
    public GameObject[] TodasCartas;
    public GameObject Cartas;
    NumeroRandom nr = new NumeroRandom();
    public VerificarBoton vb;
    static int numeroInicial;
    // Use this for initialization
    void Start () {
        numeroInicial = 0;
        generarCartaRandom();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
    void iniciar() {

        TodasCartas[numeroCartas[numeroInicial]].gameObject.SetActive(true);
    }


    public void verificarEleccion(Button b) {
        if (b.tag == "Verdadero")
        {
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
        nr.GNR_Numeros(numeroCartas, Cartas.Length);
    }
}
