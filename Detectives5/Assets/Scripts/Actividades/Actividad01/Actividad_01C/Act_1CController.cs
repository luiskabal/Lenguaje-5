using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_1CController : BigMama {
    public string[] messages;
    BigBoss bb;
    posicionarObjetos po;
    ColisionarObjetos co;
    public GameObject[] TodasCartas;
    public GameObject[] TodasSecuencias;
    static int numeroSecuencia;
    static int numeroGanadas;

    // Use this for initialization
    void Start () {
        po = GameObject.FindWithTag("Scripts").GetComponent<posicionarObjetos>();
        co = GameObject.FindWithTag("Scripts").GetComponent<ColisionarObjetos>();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        po.guardarLocacionesTodosLosObjetos();
        numeroSecuencia = 0;
        numeroGanadas = 0;
        desaparecerTodasCartas();
        mostrarCarta();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        bb.Comenzar();
    }
    private void StartTheGame()
    {
        if (!bb.IsMusicPlaying())
            bb.PlayDefaultMusic();
        bb.SetMainMessage(messages[0]);
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
        enumerarVeces();
    }
    void deshabilitarTodasSecuencias() {
        for (int i=0;i<TodasSecuencias.Length;i++) {
            TodasSecuencias[i].SetActive(false);
        }
    }
    public void cerrarCarta() {
        TodasSecuencias[numeroSecuencia].gameObject.GetComponent<Animator>().SetTrigger("Carta_Off");
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

        co.detectarColision(o);
        if (co.Tocado) {
            if (co.Acertado)
            {
                numeroGanadas--;
                Debug.Log(numeroGanadas);
                if (numeroGanadas==0) {
                    ganar();
                }
            }
            else
            {
                perder();
            }
        }
       
        co.reiniciarCollision();
    }

    void enumerarVeces() {
        for (int i=0;i< TodasSecuencias[numeroSecuencia].gameObject.transform.GetChild(1).childCount;i++) {
        
            if (TodasSecuencias[numeroSecuencia].gameObject.transform.GetChild(1).GetChild(i).GetComponent<BoxCollider2D>()!=null) {
                numeroGanadas++;
            }
        }
    }
    void ganar()
    {
        if (!bb.Good())
        {
            if (bb.StarWon())
            {
                cerrarCarta();
                numeroSecuencia++;
                mostrarCarta();
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
