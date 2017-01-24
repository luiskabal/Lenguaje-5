using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Model_3A : MonoBehaviour {
    public string[] Oraciones;
    
    public Sprite[] Cartas;
    public GameObject[] Botones;
    public GameObject[] Opciones;
    public string[] Alternativas0;
    public string[] Alternativas1;
    public string[] Alternativas2;
    public string[] Alternativas3;
    public string[] Alternativas4;
    public string[] Alternativas5;
    public string[] Alternativas6;

    public GameObject Preguntas_alternativas;
    public GameObject Preguntas;
    public GameObject Pregunta;
    public Text TextoPregunta;
    public static GameObject ObjetoSeleccionado;
    [Header("SI ES LA ETAPA 3C")]
    public GameObject Parte2;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

  
    public int GetNumeroOraciones() {
        return Oraciones.Length;
    }
}
