using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_2AController : MonoBehaviour {

    public string[] Oraciones;
    public GameObject[] Objetos;
    public GameObject Preguntas;
    public Text textoPregunta;


	void Start () {
		
	}
    public void verificarSeleccion(GameObject o) {
        Debug.Log("SE TOCA");
        for (int i=0;i<Objetos.Length;i++) {
            if (o==Objetos[i]) {
                textoPregunta.text = Oraciones[i];
                abrirPregunta();
            }

        }

    }
    void abrirPregunta() {
        Preguntas.GetComponent<Animator>().SetTrigger("Preguntas_On");
    }
    void cerrarPregunta()
    {
        Preguntas.GetComponent<Animator>().SetTrigger("Preguntas_Off");
    }


}
