using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_3AController : MonoBehaviour {
    List<int> numeroCartas = new List<int>();
    List<int> numeroOpciones = new List<int>();
    public bool EtapaA;
    public bool EtapaB;
    public bool EtapaC;
    Model_3A Model3A;
    NumeroRandom nr = new NumeroRandom();
    BigBoss bb;
    public Mecanicas_3C mec;



    // Use this for initialization
    void Start() {
        Model3A = GameObject.FindWithTag("Scripts").GetComponent<Model_3A>();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        bb.Comenzar();
     
    }

    // Update is called once per frame
    void Update() {

    }
    public void AbrirOraciones(GameObject o)
    {
        generarOracion(o);
        HabilitarPreguntas();
        o.GetComponent<Button>().interactable = false;


    }
    void generarOracion(GameObject o) {
        GenerarOracionRandom();
        GenerarOpciones();
        for (int i = 0; i < Model3A.GetNumeroOraciones(); i++) {
            if (o==Model3A.Botones[i]) {
                Model3A.Pregunta.gameObject.GetComponent<Image>().sprite = Model3A.Cartas[i];
                if (numeroCartas[i] != i)
                {
                    Model3A.TextoPregunta.text = Model3A.Oraciones[numeroCartas[i]];
                    generarAlternativas(numeroCartas[i]);
                    if (EtapaC)
                    {
                        mec= GameObject.FindWithTag("Scripts").GetComponent<Mecanicas_3C>();
                        mec.generarArrastrables(mec.OracionesSeparadoras[numeroCartas[i]]);
                     
                    }
                    break;
                }
                else {                  
                    generarOracion(o);
                }
            }
        }
       
    }
    void generarAlternativas(int NumeroSeleccion) {
        todosFalsos();
        if (EtapaA|| EtapaC) {          
            Model3A.Opciones[numeroOpciones[0]].transform.GetChild(0).GetComponent<Text>().text = crearAlternativas(NumeroSeleccion, 0);
            Model3A.Opciones[numeroOpciones[0]].tag = "Verdadero";
            Model3A.Opciones[numeroOpciones[1]].transform.GetChild(0).GetComponent<Text>().text = crearAlternativas(NumeroSeleccion, 1);
            Model3A.Opciones[numeroOpciones[2]].transform.GetChild(0).GetComponent<Text>().text = crearAlternativas(NumeroSeleccion, 2);
        }
        if (EtapaB) {           
            Model3A.Opciones[numeroOpciones[0]].transform.GetChild(0).GetComponent<Text>().text = crearAlternativas(NumeroSeleccion, 0);
            Model3A.Opciones[numeroOpciones[0]].tag = "Verdadero";
            Model3A.Opciones[numeroOpciones[1]].transform.GetChild(0).GetComponent<Text>().text = crearAlternativas(NumeroSeleccion, 1);
            Model3A.Opciones[numeroOpciones[1]].tag = "Verdadero";
            Model3A.Opciones[numeroOpciones[2]].transform.GetChild(0).GetComponent<Text>().text = crearAlternativas(NumeroSeleccion, 2);
        }

        

    }
    void todosFalsos() {
        foreach (GameObject a in Model3A.Opciones) {
            a.tag = "Ninguno";
        }
    }

   public  void verificarSeleccion(GameObject o) {
        if (o.tag == "Verdadero")
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
            if (EtapaC) {
                cerrarPreguntas();
                HabilitarParte2();
            }
            if (bb.StarWon())
            {

                cerrarPreguntas();
            }
        }
    }
    void perder()
    {
        bb.Bad();
    }

    public void HabilitarPreguntas()
    {
        Model3A.Preguntas_alternativas.SetActive(true);
        Model3A.Preguntas_alternativas.GetComponent<Animator>().SetTrigger("Pregunta_On");
    }
    void HabilitarParte2() {
        Model3A.Parte2.SetActive(true);
        Model3A.Parte2.GetComponent<Animator>().SetTrigger("Parte2_On");
    }
    void desHabilitarParte2()
    {
    
        Model3A.Parte2.GetComponent<Animator>().SetTrigger("Parte2_Off");
        Model3A.Parte2.SetActive(false);
    }

    void cerrarPreguntas() {
        Model3A.Preguntas_alternativas.GetComponent<Animator>().SetTrigger("Pregunta_Off");
        Invoke("desHabilitarPreguntas",1f);
    }
    public void desHabilitarPreguntas()
    {
        Model3A.Preguntas_alternativas.SetActive(false);
    }



    string crearAlternativas(int fila, int columna) {
        string[,] Alternativas ={
         {Model3A.Alternativas0[0],Model3A.Alternativas0[1],Model3A.Alternativas0[2]},
         {Model3A.Alternativas1[0],Model3A.Alternativas1[1],Model3A.Alternativas1[2]},
         {Model3A.Alternativas2[0],Model3A.Alternativas2[1],Model3A.Alternativas2[2]},
         {Model3A.Alternativas3[0],Model3A.Alternativas3[1],Model3A.Alternativas3[2]},
         {Model3A.Alternativas4[0],Model3A.Alternativas4[1],Model3A.Alternativas4[2]},
         {Model3A.Alternativas5[0],Model3A.Alternativas5[1],Model3A.Alternativas5[2]},
         {Model3A.Alternativas6[0],Model3A.Alternativas6[1],Model3A.Alternativas6[2]},
        };
        return Alternativas[fila, columna];
    }

    void GenerarOracionRandom() {
     nr.GNR_Numeros(numeroCartas, Model3A.GetNumeroOraciones());
        
    }
    void GenerarOpciones()
    {
        nr.GNR_Numeros(numeroOpciones, Model3A.Opciones.Length);

    }

}
