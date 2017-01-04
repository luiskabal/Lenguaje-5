using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarsNumeric : MonoBehaviour
{
    public Animator bien;
    public Animator ticket;
    public Animator miniStar;

    public Image counterBar;

    public Text stars_current;
    public Text stars_total;

    private bool show_counter;
    private int total_count;
    private int count_current;
    private int count_to_star;

    private bool star_won;
    private int star_c_int;
    private int star_t_int;
    private int counting_stars;


    // Use this for initialization
    void Start()
    {
        star_c_int = Halp.ConvertToInt(stars_current.text);
        star_t_int = Halp.ConvertToInt(stars_total.text);
        count_current = 0;
        count_to_star = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Configure(int t_star, int counter_hits, bool is_counter)
    {
        star_t_int = t_star;
        stars_total.text = Halp.cambioUnidades(t_star);

        if (!is_counter)
        {
            count_to_star = 1;
            count_current = 0;
            counterBar.enabled = false;
        }
        else
        {
            count_to_star = counter_hits;
            count_current = 0;
            counterBar.fillAmount = 0;
        }

        show_counter = true;
    }

    public bool AddStar()
    {
        bool respuesta;

        //ganamos una estrella, resetear counter si existe
        star_won = true;
        Debug.Log("STAR JUST WON MAN!");
        counting_stars++;
        star_c_int++;

        stars_current.text = Halp.cambioUnidades(star_c_int);

        if (show_counter)
        {
            miniStar.SetTrigger("STAR_ON");
            Invoke("EmptyBar", 0.8f);
        }

        //si completamos el juego, mandar true
        if (star_c_int < star_t_int)
            respuesta = false;
        else
            respuesta = true;

        return respuesta;
    }

    private void EmptyBar()
    {
        counterBar.fillAmount = 0;
        miniStar.SetTrigger("STAR_OFF");
    }

    public bool Hit()
    {
        count_current++;
        total_count++;
        star_won = false;

        if (count_current < count_to_star)
        {
            ticket.SetTrigger("BIEN");
            //llenar barra aca
            float fillby = 1.0f * count_current / count_to_star;
            Debug.Log("llenando barra por == " + fillby);
            counterBar.fillAmount = fillby;
            return false;
        }
        else
        {
            counterBar.fillAmount = 1;
            bien.SetTrigger("EJERCICIO_TERMINADO");
            count_current = 0;
            return AddStar();
        }
    }

    public bool Hit(Vector3 myPos)
    {
        count_current++;
        total_count++;
        star_won = false;

        if (count_current < count_to_star)
        {
            ticket.transform.position = myPos;
            ticket.SetTrigger("BIEN");
            //llenar barra aca
            float fillby = 1.0f * count_current / count_to_star;
            Debug.Log("llenando barra por == " + fillby);
            counterBar.fillAmount = fillby;
            return false;
        }
        else
        {
            counterBar.fillAmount = 1;
            bien.SetTrigger("EJERCICIO_TERMINADO");
            count_current = 0;
            return AddStar();
        }
    }

    public int GetHits()
    {
        return total_count;
    }

    public int GetCurrentHits()
    {
        return count_current;
    }

    public void Fail()
    {
        ticket.SetTrigger("MAL");
    }

    public void Fail(Vector3 myPos)
    {
        ticket.transform.position = myPos;
        ticket.SetTrigger("MAL");
    }

    public void TriggerBien()
    {
        bien.SetTrigger("EjercicioTerminado");
    }

    public void TriggerTicket(string opcion)
    {
        //forzar al centro
        ticket.transform.position = new Vector3(0, 0, 0);
        ticket.SetTrigger(opcion);
    }

    public void TriggerTicket(string opcion, Vector3 posAt)
    {
        ticket.transform.position = posAt;
        ticket.SetTrigger(opcion);
    }

    public bool GetWon()
    {
        if (star_won)
        {
            //star_won = false; // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetWonStars()
    {
        return counting_stars;
    }
}