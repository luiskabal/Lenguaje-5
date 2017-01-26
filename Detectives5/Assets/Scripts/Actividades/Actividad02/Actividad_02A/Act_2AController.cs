using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Act_2AController : BigMama {
    List<int> numeroOraciones = new List<int>();
    List<int> numeroTipoOracion = new List<int>();
    List<int> numeroAlternativas = new List<int>();
    FadeOutObjects foo = new FadeOutObjects();
   public  List<GameObject> ObjetosOcupados = new List<GameObject>();
    public GameObject acierto;
    public string[] messages;
    GeneradorAlternativas ga;
    NumeroRandom nr = new NumeroRandom();
    BigBoss bb;
    public string[] tipoOracion;
    public string[] Oraciones;
    public GameObject[] Objetos;
    public GameObject[] Alternativas;
    public GameObject Preguntas;
    public Text textoPregunta;
    public GameObject Luz;
    public GameObject CuadroPregunta;
    static GameObject ObjetoDesvancedor;
    string[,,] a;
    static int numeroPartida;
    static string Tipo;

    void Start() {
        ObjetosOcupados.Clear();
        a = new string[Oraciones.Length, 4, Alternativas.Length];
        ga = GameObject.FindWithTag("Scripts").GetComponent<GeneradorAlternativas>();
        bb = GameObject.FindWithTag("Scripts").GetComponent<BigBoss>();
        generarOracionRandom();
        Invoke("apagarLuz", 12f);
        numeroPartida = 0;
        bb.Comenzar();
        StartTheGame();
    }
    private void StartTheGame()
    {
        if (!bb.IsMusicPlaying())
            bb.PlayDefaultMusic();
        bb.SetMainMessage(messages[0]);
    }
    public void objetoSeleccionado(GameObject o) {
        falsearAlternativas();
        for (int i=0;i<Objetos.Length;i++) {
            Objetos[i].GetComponent<Button>().interactable = false;
        }
        foo.FadeOut(o);
        ObjetosOcupados.Add(o);
        ObjetoDesvancedor = o;
        generarAlternativasRandom();
        generarTipoOracion();
        Tipo = tipoOracion[numeroTipoOracion[0]];
        generarAlternativas();
        textoPregunta.text = Oraciones[numeroOraciones[numeroPartida]] ;
        CuadroPregunta.transform.GetChild(0).gameObject.GetComponent<Text>().text = Tipo;


        abrirPregunta();
        numeroPartida++;

    }
    void FadeOut() {
    

    }

    void deshabilitarObjetos() {
        for (int i = 0; i < Objetos.Length; i++)
        {
            Objetos[i].GetComponent<Button>().interactable = false;
        }
    }
    void habilitarObjetos() {
        for (int i = 0; i < Objetos.Length; i++)
        {
            if (!ObjetosOcupados.Contains(Objetos[i])) {
                Objetos[i].GetComponent<Button>().interactable = true;
            }
        }
    }
    void falsearAlternativas() {
        foreach (GameObject a in Alternativas) {
            a.tag = "Ninguno";
        }
    }
    void generarAlternativas() {
        switch (numeroOraciones[numeroPartida]) {
            case 0:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas0[0], ga.QUE_alternativas0[1], ga.QUE_alternativas0[2]);
                }
                else {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.QUE_alternativas0[0], ga.QUE_alternativas0[1], ga.QUE_alternativas0[2]);
                        Tipo = tipoOracion[0];
                    }
                    else {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas0[0], ga.PARAQUE_alternativas0[1], ga.PARAQUE_alternativas0[2]);
                        }
                        else {
                            if (numeroTipoOracion[0]==3) {
                                llenarAlternativas(ga.PARAQUE_alternativas0[0], ga.PARAQUE_alternativas0[1], ga.PARAQUE_alternativas0[2]);
                                Tipo = tipoOracion[3];
                            }
                        }
                    }
                }
                break;
            case 1:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas1[0], ga.QUE_alternativas1[1], ga.QUE_alternativas1[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.QUE_alternativas1[0], ga.QUE_alternativas1[1], ga.QUE_alternativas1[2]);
                        Tipo = tipoOracion[0];
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas1[0], ga.PARAQUE_alternativas1[1], ga.PARAQUE_alternativas1[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUE_alternativas1[0], ga.PARAQUE_alternativas1[1], ga.PARAQUE_alternativas1[2]);
                                Tipo = tipoOracion[3];
                            }
                        }
                    }
                }
                break;
            case 2:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas2[0], ga.QUE_alternativas2[1], ga.QUE_alternativas2[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.QUE_alternativas2[0], ga.QUE_alternativas2[1], ga.QUE_alternativas2[2]);
                        Tipo = tipoOracion[0];
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas2[0], ga.PARAQUE_alternativas2[1], ga.PARAQUE_alternativas2[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas2[0], ga.PARAQUIEN_alternativas2[1], ga.PARAQUIEN_alternativas2[2]);
                            }
                        }
                    }
                }
                break;
            case 3:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas3[0], ga.QUE_alternativas3[1], ga.QUE_alternativas3[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.QUE_alternativas3[0], ga.QUE_alternativas3[1], ga.QUE_alternativas3[2]);
                        Tipo = tipoOracion[0];
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas3[0], ga.PARAQUE_alternativas3[1], ga.PARAQUE_alternativas3[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas3[0], ga.PARAQUIEN_alternativas3[1], ga.PARAQUIEN_alternativas3[2]);
                            }
                        }
                    }
                }
                break;
            case 4:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas4[0], ga.QUE_alternativas4[1], ga.QUE_alternativas4[2]);
                    Tipo = tipoOracion[0];
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.QUE_alternativas4[0], ga.QUE_alternativas4[1], ga.QUE_alternativas4[2]);
                        Tipo = tipoOracion[0];
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.QUE_alternativas4[0], ga.QUE_alternativas4[1], ga.QUE_alternativas4[2]);
                            Tipo = tipoOracion[0];
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.QUE_alternativas4[0], ga.QUE_alternativas4[1], ga.QUE_alternativas4[2]);
                                Tipo = tipoOracion[0];
                            }
                        }
                    }
                }
                break;
            case 5:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas5[0], ga.QUE_alternativas5[1], ga.QUE_alternativas5[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.Quien_alternativas5[0], ga.Quien_alternativas5[1], ga.Quien_alternativas5[2]);
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas5[0], ga.PARAQUE_alternativas5[1], ga.PARAQUE_alternativas5[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas5[0], ga.PARAQUIEN_alternativas5[1], ga.PARAQUIEN_alternativas5[2]);
                            }
                        }
                    }
                }
                break;
            case 6:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas6[0], ga.QUE_alternativas6[1], ga.QUE_alternativas6[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.Quien_alternativas6[0], ga.Quien_alternativas6[1], ga.Quien_alternativas6[2]);
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas6[0], ga.PARAQUE_alternativas6[1], ga.PARAQUE_alternativas6[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas6[0], ga.PARAQUIEN_alternativas6[1], ga.PARAQUIEN_alternativas6[2]);
                            }
                        }
                    }
                }
                break;
            case 7:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas7[0], ga.QUE_alternativas7[1], ga.QUE_alternativas7[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.Quien_alternativas7[0], ga.Quien_alternativas7[1], ga.Quien_alternativas7[2]);
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas7[0], ga.PARAQUE_alternativas7[1], ga.PARAQUE_alternativas7[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas7[0], ga.PARAQUIEN_alternativas7[1], ga.PARAQUIEN_alternativas7[2]);
                            }
                        }
                    }
                }
                break;
            case 8:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas8[0], ga.QUE_alternativas8[1], ga.QUE_alternativas8[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.Quien_alternativas8[0], ga.Quien_alternativas8[1], ga.Quien_alternativas8[2]);
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas8[0], ga.PARAQUE_alternativas8[1], ga.PARAQUE_alternativas8[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas8[0], ga.PARAQUIEN_alternativas8[1], ga.PARAQUIEN_alternativas8[2]);
                            }
                        }
                    }
                }
                break;
            case 9:
                if (numeroTipoOracion[0] == 0)
                {
                    llenarAlternativas(ga.QUE_alternativas9[0], ga.QUE_alternativas9[1], ga.QUE_alternativas9[2]);
                }
                else
                {
                    if (numeroTipoOracion[0] == 1)
                    {
                        llenarAlternativas(ga.Quien_alternativas9[0], ga.Quien_alternativas9[1], ga.Quien_alternativas9[2]);
                    }
                    else
                    {
                        if (numeroTipoOracion[0] == 2)
                        {
                            llenarAlternativas(ga.PARAQUE_alternativas9[0], ga.PARAQUE_alternativas9[1], ga.PARAQUE_alternativas9[2]);
                        }
                        else
                        {
                            if (numeroTipoOracion[0] == 3)
                            {
                                llenarAlternativas(ga.PARAQUIEN_alternativas9[0], ga.PARAQUIEN_alternativas9[1], ga.PARAQUIEN_alternativas9[2]);
                            }
                        }
                    }
                }
                break;


        }

    }
    void llenarAlternativas(string A, string B, string C) {

        Alternativas[numeroAlternativas[0]].transform.GetChild(0).gameObject.GetComponent<Text>().text = A;
        Alternativas[numeroAlternativas[0]].tag = "Verdadero";
        Alternativas[numeroAlternativas[1]].transform.GetChild(0).gameObject.GetComponent<Text>().text = B;
        Alternativas[numeroAlternativas[2]].transform.GetChild(0).gameObject.GetComponent<Text>().text = C;

    }
    void apagarLuz() {
        Luz.SetActive(false);

    }
    void abrirPregunta() {
      
        Preguntas.SetActive(true);
        Preguntas.GetComponent<Animator>().SetTrigger("Preguntas_On");
        Invoke("activarAlternativas",1f);

    }
    void activarAlternativas()
    {
        Preguntas.GetComponent<Animator>().enabled = false;
        for (int i=0;i< Alternativas.Length;i++) {
            Alternativas[i].GetComponent<Button>().interactable = true;
        }

    }
    void desactivarAlternativas() {
      
        Preguntas.GetComponent<Animator>().enabled = true;

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
        acierto.transform.position = o.transform.position;
        if (o.tag == "Verdadero") {
            ganar();
        }else
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
                desactivarAlternativas();
                cerrarPregunta();
             
                Invoke("habilitarObjetos",2f);
            }
        }
    }
    void perder()
    {
        bb.Bad();
    }

    void generarOracionRandom()
    {
        nr.GNR_Numeros(numeroOraciones, Oraciones.Length);
    }
    void generarTipoOracion()
    {
        nr.GNR_Numeros(numeroTipoOracion, 3);
    }
    void generarAlternativasRandom()
    {
        nr.GNR_Numeros(numeroAlternativas, Alternativas.Length);
    }
}
