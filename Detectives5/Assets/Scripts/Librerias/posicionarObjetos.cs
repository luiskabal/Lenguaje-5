using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionarObjetos : MonoBehaviour {


    public GameObject[] objetos;
    List<Vector3> posicion = new List<Vector3>();
    List<Vector3> tamaño = new List<Vector3>();
    List<Vector3> tamañoCollider = new List<Vector3>();

    void Start()
    {
        Debug.Log("Numero de objetos: "+ objetos.Length);
    }
    void Update()
    {

    }
    public void reposicionarUnObjeto(GameObject palabra)
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            if (palabra == objetos[i])
            {
                retornarTodo(objetos[i], posicion[i], tamaño[i], tamañoCollider[i]);
            }
        }
    }
    public void guardarLocacionesTodosLosObjetos()
    {
        posicion.Clear();
        tamaño.Clear();
        tamañoCollider.Clear();
        for (int i = 0; i < objetos.Length; i++)
        {
            posicion.Add(objetos[i].transform.position);
            tamaño.Add(objetos[i].transform.localScale);
            objetos[i].transform.position = posicion[i];
            if (objetos[i].GetComponent<BoxCollider2D>())
            {
                tamañoCollider.Add(objetos[i].GetComponent<BoxCollider2D>().size);

            }
            else
            {
                Debug.Log("No tiene collider");
            }
        }
        Debug.Log("SE GUARDA TODO");
    }
    public void retornarTodo(GameObject objetos, Vector3 posicion, Vector3 tamaño, Vector3 tamañoCollider)
    {
        if (!objetos.gameObject.activeInHierarchy) {
            objetos.gameObject.SetActive(true);
        }
        if (objetos.transform.localScale!=tamaño) {
            objetos.transform.localScale = tamaño;
        }
        if (objetos.transform.position != posicion) {
            objetos.transform.position = posicion;
        }
        if (objetos.GetComponent<BoxCollider2D>())
        {
            objetos.GetComponent<BoxCollider2D>().size = tamañoCollider;// VUELVE EL TAMAÑO ORIGINAL DEL COLLIDER DEL OBJETO
        }

    }
    public void returnOriginalPositionTODOS()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            if (objetos[i] == objetos[i])
            {
                retornarTodo(objetos[i], posicion[i], tamaño[i], tamañoCollider[i]);
            }
        }
    }
    public void borrarTodo() {
        posicion.Clear();
        tamaño.Clear();
        tamañoCollider.Clear();
    }
    public void borrarPosiciones() {
        posicion.Clear();
    }
    public void borrarTamaño() {
        tamaño.Clear();
    }
    public void borrarColliderTamaño() {
        tamañoCollider.Clear();
    }
}
