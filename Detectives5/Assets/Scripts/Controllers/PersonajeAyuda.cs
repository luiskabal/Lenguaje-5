using UnityEngine;
using UnityEngine.UI;

public class PersonajeAyuda : MonoBehaviour
{
    public string Text_Ayuda;
    public string Text_Atencion;
    public Text Text_Grufus;
    public Text Text_Alert;

    void Start ()
    {
        Text_Alert.text = Text_Atencion;
        Text_Grufus.text = Text_Ayuda;
	}
	
	void Update ()
    {
	    
	}

    void OnMouseDown()
    {
        transform.GetComponent<Animator>().SetTrigger("ON");
    }

    void OnMouseUp()
    {
        transform.GetComponent<Animator>().SetTrigger("OFF");
    }

    public void ShowAlert()
    {
        transform.GetComponent<Animator>().SetTrigger("ALERT");
    }

    public void ChangeAlertText( string newalert )
    {
        Text_Alert.text = newalert;
    }

    public void ChangeGrufusText( string newgrufus )
    {
        Text_Grufus.text = newgrufus;
    }
}
