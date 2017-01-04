using UnityEngine;
using System.Collections;

public class PruebasAcelerometro : MonoBehaviour {

    public float limiteXDer;
    public float limiteXIzq;
    public float limiteYSup;
    public float limiteYInf;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float temporalX = Input.acceleration.x;
        float temporalY = Input.acceleration.y;

        if (transform.position.x > limiteXIzq &&
            transform.position.x < limiteXDer)
        {
            transform.Translate(temporalX, transform.position.y, 0);
        }
        else if (transform.position.x < limiteXIzq)
        {
            transform.Translate(limiteXIzq, transform.position.y, 0);
        }
        else if(transform.position.x > limiteXDer)
        {
            transform.Translate(limiteXDer, transform.position.y, 0);
        }

        if (transform.position.y > limiteYInf &&
            transform.position.y < limiteYSup)
        {
            transform.Translate(transform.position.x, temporalY, 0);
        }
        else if (transform.position.y < limiteYInf)
        {
            transform.Translate(transform.position.x, limiteYInf, 0);
        }
        else if (transform.position.x > limiteYSup)
        {
            transform.Translate(transform.position.x, limiteYSup, 0);
        }
    }
}
