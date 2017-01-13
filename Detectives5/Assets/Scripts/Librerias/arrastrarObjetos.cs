using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class arrastrarObjetos : MonoBehaviour {
    public static bool dragging = false;
    private float distance;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (dragging)
        {
            Vector3 cambioposicion = new Vector3(-3f, 0, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            this.transform.position = rayPoint;
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        achicarColliders();
    }
    void achicarColliders()
    {

        this.gameObject.GetComponent<BoxCollider2D>().size= new Vector2(10f, 10f);
    }

    }
