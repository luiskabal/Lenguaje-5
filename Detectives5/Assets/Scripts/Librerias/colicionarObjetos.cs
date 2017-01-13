using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class colicionarObjetos : MonoBehaviour {
    public posicionarObjetos po;
    public GameObject acierto;//cuando esté
    GameObject Objeto_Arrastrable;
    GameObject Colicion;

    [Header("Si el Objeto Arrastrable se compara por tags o nombre con la Colición")]
    public bool Tags;
    public bool Names;

    [Header("Si se juntan los objetos que colicionan")]
    public bool JuntarObjetos;

    [Header("Si desaparece el Objeto Arrastrable, la Colición o ambos")]

    public bool DesaparecerArrastrable;
    public bool DesaparecerColición;

    [Header("Si se quiere eliminar el collider del Objeto Arrastrable, Colición o ambos")]
    public bool ColliderArrastrable;
    public bool ColliderColicion;



    private Bounds checkRadius;
    public static bool dragging;
    // Use this for initialization
    void Start() {
        po = GameObject.FindWithTag("Scripts").GetComponent<posicionarObjetos>();
    }

    // Update is called once per frame
    void Update() {

    }
    public void detectarColision(GameObject o) {
        checkRadius = o.GetComponent<BoxCollider2D>().bounds;
        Vector2 originPoint = (Vector2)o.gameObject.transform.position;
        RaycastHit2D[] hit = Physics2D.BoxCastAll(originPoint, checkRadius.size, 0f, Vector2.zero);
        if (hit != null && hit.Length > 1)
        {
            Objeto_Arrastrable = hit[1].collider.gameObject;
            Colicion = hit[0].collider.gameObject;
             if (acierto != null)
            {
                acierto.transform.position = hit[1].collider.gameObject.transform.position;
            }
            VerificarColiciones(Objeto_Arrastrable, Colicion);
        }
        if (hit.Length<=1) {
            po.reposicionarUnObjeto(o);
        }

    }
    void VerificarColiciones(GameObject a, GameObject b) {
        if (Tags) {
            if (a.gameObject.tag == b.gameObject.tag)
            {
                siDesaparece(a, b);
                siSeJunta(a, b);
                eliminarColliders(a, b);
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
            }
            else {
                po.reposicionarUnObjeto(a);
            }
        }

    }
    void siDesaparece(GameObject a, GameObject b) {
        if (DesaparecerArrastrable) {
            a.SetActive(false);
        }
        if (DesaparecerColición) {
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
        if (ColliderColicion)
        {
            b.GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);
        }
    }
}
