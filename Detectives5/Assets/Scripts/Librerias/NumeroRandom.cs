using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumeroRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
     public int numeroRandom( int min,  int max,  List<int> numero)//numero random unico
    {
        int val = Random.Range(min, max);
        while (numero.Contains(val))
        {
            val = Random.Range(min, max);
        }
        return val;
    }
    public void GNR_Numeros(List<int> numero, int numeros) {
        numero.Clear();
       for (int i = 0; i < numeros; i++)
        {
            numero.Add(numeroRandom(0, numeros, numero));
        }
    }
}
