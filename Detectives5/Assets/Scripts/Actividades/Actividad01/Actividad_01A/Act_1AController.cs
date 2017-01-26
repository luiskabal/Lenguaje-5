using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_1AController : BigMama
{
    public string[] messages;
    BigBoss bb;
    List<int> numeroCartas = new List<int>();
    public GameObject[] TodasCartas;
    public GameObject botonCarta;
    NumeroRandom nr = new NumeroRandom();
    static int numeroInicial;
    public GameObject acierto;
    // Use this for initialization
    void Start() {
        moverCarta();
        numeroInicial = 0;
        generarCartaRandom();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        //iniciar();
        bb.Comenzar();
        StartTheGame();
    }

    // Update is called once per frame
    void Update() {

    }

    void iniciar() {       
        Invoke("deshabilitarCartas", 0f);    
    }
    private void StartTheGame()
    {
        if (!bb.IsMusicPlaying())
            bb.PlayDefaultMusic();
        bb.SetMainMessage(messages[0]);
    }
    void deshabilitarCartas() {
        for (int i = 0; i < TodasCartas.Length; i++)
        {
            TodasCartas[i].SetActive(false);
        }
        Debug.Log("SE DESHABILITAN LAS CARTAS");
    }
    public void abrirCarta() {
        botonCarta.SetActive(false);
        TodasCartas[numeroCartas[numeroInicial]].gameObject.SetActive(true);
        TodasCartas[numeroCartas[numeroInicial]].GetComponent<Animator>().SetTrigger("Carta_On");
        Invoke("habilitarInteractable", 1f);
      
    }
    void deshabilitarInteractable()
    {

        TodasCartas[numeroCartas[numeroInicial]].GetComponent<Animator>().enabled = true;
        for (int i = 0; i < TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(0).transform.childCount; i++)
        {
            TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;

        }
        for (int i = 0; i < TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(1).transform.childCount; i++)
        {
            TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(1).transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(2).transform.childCount; i++)
        {
            TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(2).transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
        }
        Invoke("cerrarCarta", 1f);

    }
    void habilitarInteractable()
    {
        TodasCartas[numeroCartas[numeroInicial]].GetComponent<Animator>().enabled = false;
        for (int i = 0; i < TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(0).transform.childCount; i++)
        {
            TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(1).transform.childCount; i++)
        {
            TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(1).transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(2).transform.childCount; i++)
        {
            TodasCartas[numeroCartas[numeroInicial]].transform.GetChild(2).transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }

    }
    public void cerrarCarta()
    {
        TodasCartas[numeroCartas[numeroInicial]].GetComponent<Animator>().SetTrigger("Carta_Off");
     
        Invoke("iniciar", 3f);
        Invoke("moverCarta", 3f);
        numeroInicial++;
  
    }

    public void verificarEleccion(Button b) {
        acierto.transform.position = b.transform.position;
        if (b.tag == "Verdadero")
        {
            b.GetComponent<Button>().interactable = false;

            ganar();
        }
        else {
            perder();
        }
    }
    public void moverCarta() {
     
        botonCarta.GetComponent<Animator>().enabled = false;
        int x=Random.Range(-216,312);
         x = Random.Range(-216, 312);
        int y = Random.Range(-240, -168);
         y = Random.Range(-240, -168);
        botonCarta.GetComponent<RectTransform>().localPosition = new Vector3(x,y,0);
        botonCarta.GetComponent<Animator>().enabled = true;
        botonCarta.SetActive(true);

    }
    void ganar()
    {
        if (!bb.Good())
        {
            if (bb.StarWon())
            {
                deshabilitarInteractable();          
              

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
