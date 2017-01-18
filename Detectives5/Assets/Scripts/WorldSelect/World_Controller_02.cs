using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class World_Controller_02 : MonoBehaviour
{
    public EtapasController etapas;
    public string default_name = "ACT_";
    public Loading loader;
    public Button[] etapa;

    private bool[] desbloqueos = new bool[60];
    private bool[] logrados = new bool[60];
    private ArrayList etapas_lista;
    private int etapaTarget;
    private bool aplicarDesbloqueo = false;
    private int targetEtapas;
    void Start()
    {
        etapas.OpenFile();

        etapas_lista = etapas.GetSaveData();

        for (int i = 0; i < etapas_lista.Count; i++)
        {
            Debug.Log("Etapa " + (i + 1) + ": " + etapas_lista[i]);
        }

        for (int i = 0; i < 60; i++)
        {
            desbloqueos[i] = false;
        }

        CargarMundosInicial();
    }

    public void CargarMundosInicial()
    {
        //Carga mundos en base a etapas pasadas
        //cargará de a 12 etapas pasadas
        //60 en total

        int cuenta = 0;
        bool[] comprobador = new bool[7];

        for (int i = 0; i < 42; i++)
        {
            if (i < 6)
            {
                comprobador[0] = comprobador[0] && System.Convert.ToBoolean(etapas_lista[i]);
                Debug.Log(etapas_lista[i]);
            }
            else if (i < 12)
            {
                comprobador[1] = comprobador[1] && System.Convert.ToBoolean(etapas_lista[i]);
            }
            else if (i < 18)
            {
                comprobador[2] = comprobador[2] && System.Convert.ToBoolean(etapas_lista[i]);
            }
            else if (i < 24)
            {
                comprobador[3] = comprobador[3] && System.Convert.ToBoolean(etapas_lista[i]);
            }
            else if (i < 30)
            {
                comprobador[4] = comprobador[4] && System.Convert.ToBoolean(etapas_lista[i]);
            }
            else if (i < 36)
            {
                comprobador[5] = comprobador[4] && System.Convert.ToBoolean(etapas_lista[i]);
            }
            else if (i < 42)
            {
                comprobador[6] = comprobador[4] && System.Convert.ToBoolean(etapas_lista[i]);
            }
        }

        cuenta = comprobador[0] ? 12 : 6;
        if(comprobador[1])
            cuenta = comprobador[1] ? 18 : 12;
        if (comprobador[2])
            cuenta = comprobador[2] ? 24 : 18;
        if (comprobador[3])
            cuenta = comprobador[3] ? 30 : 24;
        if (comprobador[4])
            cuenta = comprobador[4] ? 36 : 30;
        if (comprobador[5])
            cuenta = comprobador[4] ? 42 : 36;
        if (comprobador[6])
            cuenta = comprobador[4] ? 45 : 45;

        for (int i = 0; i < 45; i++)
        {
            logrados[i] = System.Convert.ToBoolean(etapas_lista[i]);

            if (i < cuenta)
                desbloqueos[i] = true;
            else
                desbloqueos[i] = false;

            Debug.Log("Desbloqueo: " + desbloqueos[i]);
        }
    }

    public void MostrarDesbloqueos()
    {
        for (int i = 0; i < 60; i++)
        {
            Debug.Log(desbloqueos[i]);
        }
    }

    public void DesbloquearEtapa(int requisito)
    {
        bool comprobador = true;

        if (requisito != 0)
        {
            //Revisa si etapas previas requisito están completadas
            for (int i = 0; i < requisito; i++)
            {
                comprobador = comprobador && logrados[i];
            }
        }
        
        etapaTarget = 0;
        targetEtapas = requisito;
        aplicarDesbloqueo = comprobador;
        if (requisito == 24 || requisito == 54)
        {
            Invoke("AplicarDesbloqueo06", .1f);
        }
        else
        {
            Invoke("AplicarDesbloqueo12", .1f);
        }
    }

    private void AplicarDesbloqueo06()
    {
        Debug.Log("Salta" + aplicarDesbloqueo + " " + etapaTarget);
        if(etapaTarget < 6)
        {
            etapa[targetEtapas + etapaTarget].interactable = aplicarDesbloqueo;
            etapa[targetEtapas + etapaTarget].GetComponentsInChildren<Image>()[1].enabled = logrados[targetEtapas + etapaTarget];
            Debug.Log(etapa[targetEtapas + etapaTarget].interactable);
            etapaTarget++;

            AplicarDesbloqueo06();
        }
    }

    private void AplicarDesbloqueo12()
    {
        if (etapaTarget < 12)
        {
            Debug.Log("Salta" + aplicarDesbloqueo + " " + etapaTarget);
            etapa[targetEtapas + etapaTarget].interactable = aplicarDesbloqueo;
            etapa[targetEtapas + etapaTarget].GetComponentsInChildren<Image>()[1].enabled = logrados[targetEtapas + etapaTarget];
            Debug.Log(etapa[targetEtapas + etapaTarget].interactable);
            etapaTarget++;

            AplicarDesbloqueo12();
        }
    }
}
