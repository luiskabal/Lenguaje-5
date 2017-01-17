using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionarObjetos : MonoBehaviour {
public posicionarObjetos po;
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



    private Bounds checkRadius;
    public static bool dragging;
    // Use this for initialization
    void Start() {
 
        po = GameObject.FindWithTag("Scripts").GetComponent<posicionarObjetos>();
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
            po.reposicionarUnObjeto(o);
  
        }
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
      
                po.reposicionarUnObjeto(a);
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
                po.reposicionarUnObjeto(a);
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
   public void reiniciarCollision() {
        Acertado = false;
        Tocado = false;
    }
}
