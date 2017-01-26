using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionarObjetos : MonoBehaviour {
public posicionarObjetos po;
    public List<GameObject> ColisionesOriginales = new List<GameObject>();
    public List<GameObject> ArrastrablesOriginales = new List<GameObject>();
    public GameObject acierto;//cuando esté
    GameObject Objeto_Arrastrable;
    GameObject Colision;

  
    RaycastHit2D[] hit;
    public bool Tocado;
    public bool Acertado;



    [Header("Si el Objeto Arrastrable se compara por tags o nombre con la Colisión")]
    public bool Tags;
    public bool Names;

    [Header("Si se juntan los objetos que colisionan")]
    public bool JuntarObjetos;

    [Header("Si desaparece el Objeto Arrastrable, la Colisión o ambos")]

    public bool DesaparecerArrastrable;
    public bool DesaparecerColisión;

    [Header("Si se quiere eliminar el collider del Objeto Arrastrable, Colisión o ambos")]
    public bool ColliderArrastrable;
    public bool ColliderColision;
    [Header("Si se agrandan los objetos")]
    public bool AgrandaArrastrable;
    public bool AgrandaColision;
    [Header("Si se agrandan los objetos al arrastrar")]
    public bool AgrandaArrastrableArrastre;
    public bool AgrandaColisionArrastre;


    private Bounds checkRadius;
    public static bool dragging;
    // Use this for initialization
    void Start() {
 
        po = GameObject.FindWithTag("Scripts").GetComponent<posicionarObjetos>();
        ColisionesOriginales.Clear();
        ArrastrablesOriginales.Clear();
    }

    // Update is called once per frame
    void Update() {
    }

     void AgrandarColision(GameObject o) {
        checkRadius = o.GetComponent<BoxCollider2D>().bounds;
        Vector2 originPoint = (Vector2)o.gameObject.transform.position;
        hit = Physics2D.BoxCastAll(originPoint, checkRadius.size, 0f, Vector2.zero);
    }
    public void detectarColision(GameObject o) {
   
        checkRadius = o.GetComponent<BoxCollider2D>().bounds;
        Vector2 originPoint = (Vector2)o.gameObject.transform.position;
         hit = Physics2D.BoxCastAll(originPoint, checkRadius.size, 0f, Vector2.zero);
        if (hit != null && hit.Length >1 && hit.Length <=2)
        {
            Tocado = true;
            Objeto_Arrastrable = hit[0].collider.gameObject;
            Colision = hit[1].collider.gameObject;
   
            if (acierto != null)
            {
              
                acierto.transform.position = hit[1].collider.gameObject.transform.position;
            }
         
            VerificarColisiones(Objeto_Arrastrable, Colision);
          
      }
        if (hit.Length<=1) {
            volverPosicion(o);
  
        }
    }
    public void ColisionAlMover(GameObject o) {
        checkRadius = o.GetComponent<BoxCollider2D>().bounds;
        Vector2 originPoint = (Vector2)o.gameObject.transform.position;
        hit = Physics2D.BoxCastAll(originPoint, checkRadius.size, 0f, Vector2.zero);
        if (hit != null && hit.Length > 1 && hit.Length <= 2) {
            Objeto_Arrastrable = hit[0].collider.gameObject;
            Colision = hit[1].collider.gameObject;
            agrandarObjetos(Objeto_Arrastrable, Colision);
        }else { todoNormal(); }

    }
  
    void VerificarColisiones(GameObject a, GameObject b) {

        if (Tags) {
            if (a.gameObject.tag == b.gameObject.tag)
            {
                siDesaparece(a, b);
                siSeJunta(a, b);
                eliminarColliders(a, b);
                Acertado = true;
            }
            else {

                volverPosicion(a);
            }
        }
        
        if (Names) {
            if (a.gameObject.name == b.gameObject.name)
            {
                siDesaparece(a, b);
                siSeJunta(a, b);
                eliminarColliders(a, b);
                Acertado = true;
            }
            else {
                volverPosicion(a);
            }
        }

    }
    void eliminarHits() {
      
    }
    void siDesaparece(GameObject a, GameObject b) {
        if (DesaparecerArrastrable) {
            a.SetActive(false);
        }
        if (DesaparecerColisión) {
            b.SetActive(false);
        }
    }

    void siSeJunta(GameObject a, GameObject b) {
        if (JuntarObjetos) {
            a.transform.position = b.transform.position;
        }
    }
    void eliminarColliders(GameObject a, GameObject b) {
        if (ColliderArrastrable) {
          
            a.GetComponent<BoxCollider2D>().size = new Vector2(0f,0f);
         }
        if (ColliderColision)
        {
            b.GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);
        }
    }

  public  void agrandarObjetos(GameObject a, GameObject b)
    {
        if (AgrandaArrastrable) {
            b.transform.localScale = new Vector3(1f, 1f, 0f);
            if (!ArrastrablesOriginales.Contains(a))
            {
                ArrastrablesOriginales.Add(a);
            }
            for (int i = 0; i < ArrastrablesOriginales.Count; i++)
            {
                if (a == ArrastrablesOriginales[i])
                {
                     ArrastrablesOriginales[i].transform.localScale = new Vector3(1.5f, 1.5f, 0f);
                }
                else
                {
                    ArrastrablesOriginales[i].transform.localScale = new Vector3(1f, 1f, 0f);
                }

            }
        }
        if (AgrandaColision)
        {
            a.transform.localScale = new Vector3(1f, 1f, 0f); 
            if (!ColisionesOriginales.Contains(b)) {
                ColisionesOriginales.Add(b);
            }
            for (int i=0;i<ColisionesOriginales.Count;i++) {
                if (b == ColisionesOriginales[i])
                {
                    ColisionesOriginales[i].transform.localScale = new Vector3(1.5f, 1.5f, 0f);
                    ColisionesOriginales[i].GetComponent<BoxCollider2D>().size = new Vector2(40,40);
                }
                else {
                    ColisionesOriginales[i].transform.localScale = new Vector3(1f, 1f, 0f); ;

                }
                
            }
            Debug.Log(b.name);
        }
    }
   public void agrandarAlArrastrar(GameObject o) {
        float x =3f;
        float y =3f;
        if (AgrandaArrastrableArrastre) {
        
                o.transform.localScale = new Vector3(x,y,0);
        }
    }
    void volverPosicion(GameObject o)
    {
        Debug.Log("Vuelve a la posicion");
        po.reposicionarUnObjeto(o);
    }
    public void reiniciarCollision() {
        Acertado = false;
        Tocado = false;
    }
    public void todoNormal() {
        for (int i = 0; i < ColisionesOriginales.Count; i++)
        {
            ColisionesOriginales[i].transform.localScale = new Vector3(1, 1, 0f);
        }
        for (int i = 0; i < ArrastrablesOriginales.Count; i++)
        {
            ArrastrablesOriginales[i].transform.localScale = new Vector3(1, 1, 0f);
        }

    }

}
