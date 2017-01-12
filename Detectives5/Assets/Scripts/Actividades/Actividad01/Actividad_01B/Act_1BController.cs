using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_1BController : MonoBehaviour {
    BigBoss bb;
    public GameObject[] TodasCartas;
    public GameObject[] TodasSecuencias;
    public GameObject Botones_Cartas;
  

    public GameObject[] texto0;
 
    public GameObject[] texto1;
    public GameObject[] texto2;
    public GameObject[] texto3;
    public GameObject[] texto4;
    public GameObject[] texto5;
    public GameObject[] texto6;
    public GameObject[] texto7;
    public GameObject[] texto8;
    public GameObject[] texto9;
    public GameObject[] palabraFrase0;
    public GameObject[] palabraFrase1;
    public GameObject[] palabraFrase2;
    public GameObject[] palabraFrase3;
    public GameObject[] palabraFrase4;
    public GameObject[] palabraFrase5;
    public GameObject[] palabraFrase6;
    public GameObject[] palabraFrase7;
    public GameObject[] palabraFrase8;
    public GameObject[] palabraFrase9;

    NumeroRandom nr = new NumeroRandom();

    static int numeroSecuencia;
    static int numeroDeJuegosTotales;
    static int numeroDeJuegosActuales;
    // Use this for initialization





    void Start () {
        numeroSecuencia = 0;
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        desaparecerTodasCartas();
        nombresTextos();
        mostrarCarta();
        Invoke("desaparecerSecuencias", 0f);
    }
   
 
    void mostrarCarta() {
     
        if (numeroSecuencia <= 3)
        {
            TodasCartas[0].gameObject.SetActive(true);
           
        }
        else {
            if (numeroSecuencia >= 4 && numeroSecuencia <= 6)
            {
                TodasCartas[1].gameObject.SetActive(true);
             
            }
            else {
                TodasCartas[2].gameObject.SetActive(true);
              
            }
        }      
        numerarTextos();

    }
    void desaparecerSecuencias() {
 
        for (int i=0;i< TodasSecuencias.Length;i++) {
            TodasSecuencias[i].SetActive(false);
        }

    }
    void nombresTextos() {
        for (int i=0;i<texto0.Length;i++) {
            texto0[i].SetActive(false);
            texto0[i].name = i.ToString();
            palabraFrase0[i].name = i.ToString();
        }
        for (int i = 0; i < texto1.Length; i++)
        {
            texto1[i].SetActive(false);
            texto1[i].name = i.ToString();
            palabraFrase1[i].name = i.ToString();
        }
        for (int i = 0; i < texto2.Length; i++)
        {
            texto2[i].SetActive(false);
            texto2[i].name = i.ToString();
            palabraFrase2[i].name = i.ToString();
        }

        for (int i = 0; i < texto3.Length; i++)
        {
            texto3[i].SetActive(false);
            texto3[i].name = i.ToString();
            palabraFrase3[i].name = i.ToString();
        }
        for (int i = 0; i < texto4.Length; i++)
        {
            texto4[i].SetActive(false);
            texto4[i].name = i.ToString();
            palabraFrase4[i].name = i.ToString();
        }
        for (int i = 0; i < texto5.Length; i++)
        {
            texto5[i].SetActive(false);
            texto5[i].name = i.ToString();
            palabraFrase5[i].name = i.ToString();
        }
        for (int i = 0; i < texto6.Length; i++)
        {
            texto6[i].SetActive(false);
            texto6[i].name = i.ToString();
            palabraFrase6[i].name = i.ToString();
        }
        for (int i = 0; i < texto7.Length; i++)
        {
            texto7[i].SetActive(false);
            texto7[i].name = i.ToString();
            palabraFrase7[i].name = i.ToString();
        }
        for (int i = 0; i < texto8.Length; i++)
        {
            texto8[i].SetActive(false);
            texto8[i].name = i.ToString();
            palabraFrase8[i].name = i.ToString();
        }
        for (int i = 0; i < texto9.Length; i++)
        {
            texto9[i].SetActive(false);
            texto9[i].name = i.ToString();
            palabraFrase9[i].name = i.ToString();
        }


    }
    void mostrarTextos(int a) {

        switch (numeroSecuencia) {
            case 0:
                texto0[a].SetActive(true);
                break;
            case 1:
                texto1[a].SetActive(true);
                break;
            case 2:
                texto2[a].SetActive(true);
                break;
            case 3:
                texto3[a].SetActive(true);
                break;
            case 4:
                texto4[a].SetActive(true);
                break;
            case 5:
                texto5[a].SetActive(true);
                break;
            case 6:
                texto6[a].SetActive(true);
                break;
            case 7:
                texto7[a].SetActive(true);
                break;
            case 8:
                texto8[a].SetActive(true);
                break;
            case 9:
                texto9[a].SetActive(true);
                break;
        }
    }
   public void abrirCarta() {
        //FALTA CERRAR LA ANTERIOR Y CAMBIARL
   
        TodasSecuencias[numeroSecuencia].gameObject.SetActive(true);
        TodasSecuencias[numeroSecuencia].gameObject.GetComponent<Animator>().SetTrigger("Carta_On");
        numerarTextos();
        Invoke("desaparecerTodasCartas", 1f);
    }
    public void cerrarCarta()
    {
        TodasSecuencias[numeroSecuencia].gameObject.GetComponent<Animator>().SetTrigger("Carta_Off");
        Invoke("desaparecerSecuencias", 1f);
    }

    void numerarTextos() {
        switch (numeroSecuencia)
        {
            case 0:
                numeroDeJuegosTotales = texto0.Length;
                break;
            case 1:
                numeroDeJuegosTotales = texto1.Length;
                break;
            case 2:
                numeroDeJuegosTotales = texto2.Length;
                break;
            case 3:
                numeroDeJuegosTotales = texto3.Length;
                break;
            case 4:
                numeroDeJuegosTotales = texto4.Length;
                break;
            case 5:
                numeroDeJuegosTotales = texto5.Length;
                break;
            case 6:
                numeroDeJuegosTotales = texto6.Length;
                break;
            case 7:
                numeroDeJuegosTotales = texto7.Length;
                break;
            case 8:
                numeroDeJuegosTotales = texto8.Length;
                break;
            case 9:
                numeroDeJuegosTotales = texto9.Length;
                break;
        }
   

    }
    public void verificarEleccion(Button b)
    {
        if (b.tag == "Verdadero")
        {
           
            b.GetComponent<Button>().interactable = false;
            mostrarTextos(int.Parse(b.name));
            numeroDeJuegosActuales++;       
            if (numeroDeJuegosActuales == numeroDeJuegosTotales)
            {
                numeroDeJuegosActuales = 0;
                desaparecerTodasCartas();
                cerrarCarta();
                numeroSecuencia++;
                mostrarCarta();
                ganar();
            }
         
        }
        else
        {
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
 

    void Update () {
		
	}
}