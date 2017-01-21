using UnityEngine;
using System.Collections;

public class Renombrador : MonoBehaviour {

    public string nombreArchivos = "Hijo_";
    public int empiezaDesde = 0;

	public void RenombrarHijos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = nombreArchivos + empiezaDesde;
            empiezaDesde++;
        }
    }
}
