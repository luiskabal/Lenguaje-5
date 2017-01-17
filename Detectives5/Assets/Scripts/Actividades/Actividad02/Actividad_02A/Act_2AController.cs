using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_2AController : MonoBehaviour {
    BigBoss bb;
    public string[] Oraciones;
    public GameObject[] Objetos;
    public GameObject Preguntas;
    public Text textoPregunta;
    public GameObject Luz;

	void Start () {
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        Invoke("apagarLuz", 12f);
	}
    public void objetoSeleccionado(GameObject o) {
        o.GetComponent<Button>().interactable = false;
        for (int i=0;i<Objetos.Length;i++) {
            if (o==Objetos[i]) {
                textoPregunta.text = Oraciones[i];
                abrirPregunta();
            }

        }

    }
    void apagarLuz() {
        Luz.SetActive(false);

    }
    void abrirPregunta() {
        Preguntas.SetActive(true);
        Preguntas.GetComponent<Animator>().SetTrigger("Preguntas_On");
    }
    void cerrarPregunta()
    {
        
        Preguntas.GetComponent<Animator>().SetTrigger("Preguntas_Off");
        Invoke("borrarPreguntas",3f);
    }
    void borrarPreguntas() {
        Preguntas.SetActive(false);
    }
  public  void verificarRespuesta(GameObject o) {
        if (o.tag == "Verdadero") {
            ganar();
        }else
        {



        }

    }
    void ganar()
    {
        if (!bb.Good())
        {
            if (bb.StarWon())
            {
                cerrarPregunta();
            }
        }
    }
    void perder()
    {
        bb.Bad();
    }


}
