using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class arrastrarObjetos : MonoBehaviour {
    public bool dragging = false;
    private float distance;
    ColisionarObjetos co;
    // Use this for initialization
    void Start() {
        co = GameObject.FindWithTag("Scripts").GetComponent<ColisionarObjetos>();
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        achicarColliders();
        eliminarOtrosColliders();
      
  
    }
    void OnMouseDrag() {
        if (dragging)
        {
            Vector3 cambioposicion = new Vector3(-3f, 0, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            this.gameObject.transform.position = rayPoint;
        }
    }

    void OnMouseUp() {

        dragging = false;
        Invoke("activarColliders",0.1f);
      }

    void achicarColliders()
    {
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
    }
    void eliminarOtrosColliders() {
        for (int i = 0; i < co.po.objetos.Length; i++)
        {
            if (co.po.objetos[i].activeInHierarchy) {
                if (co.po.objetos[i] != this.gameObject)
                {
                    co.po.objetos[i].GetComponent<BoxCollider2D>().enabled = false;
                }
            }
           
        }
    }

    void activarColliders()
    {
        for (int i = 0; i < co.po.objetos.Length; i++)
        {
            if (co.po.objetos[i].activeInHierarchy)
            {
                co.po.objetos[i].GetComponent<BoxCollider2D>().enabled = true;
           }
        }
    }
}
