using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colicionarObjetos : MonoBehaviour {
 
    private Bounds checkRadius;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseUp() {
        arrastrarObjetos.dragging = false;
        Vector2 originPoint = (Vector2)gameObject.transform.position;
        RaycastHit2D[] hit = Physics2D.BoxCastAll(originPoint, checkRadius.size, 0f, Vector2.zero);
        if (hit != null && hit.Length > 1)
        {


        }
        }
}
