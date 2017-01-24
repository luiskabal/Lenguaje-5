using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Mecanicas_3C : MonoBehaviour {
    public string[] OracionesSeparadoras;
   public posicionarObjetos po;
    public string[] PartesOracion;
    int numeroObjetos;
	// Use this for initialization
	void Start () {
      
        po.guardarLocacionesTodosLosObjetos();
        numeroObjetos = po.objetos.Length;
        desActivarObjetos();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void generarArrastrables(string a) {
        Debug.Log(numeroObjetos );
        PartesOracion= a.Split(' ');
        for (int i=0;i< numeroObjetos; i++) {
            po.objetos[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = PartesOracion[i];
            activarObjetos();
        }

    }
    void activarObjetos() {
        for (int i = 0; i < po.objetos.Length; i++)
        {
            po.objetos[i].SetActive(true);
        }
    }
    void desActivarObjetos()
    {
        for (int i=0;i<po.objetos.Length;i++) {
            po.objetos[i].SetActive(false);
        }
    }
}
