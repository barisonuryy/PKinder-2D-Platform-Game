using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector2 mousePos;
    private Vector2 startMousePos;
   
 
    // Start is called befo_line the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0,new Vector3(startMousePos.x,startMousePos.y,0));
            _lineRenderer.SetPosition(1,new Vector3(mousePos.x,mousePos.y,0));
        } 
        if (Input.GetMouseButtonUp(1))
        {
            
            _lineRenderer.SetPosition(0,Vector3.zero);
            _lineRenderer.SetPosition(1,Vector3.zero);
        }
   
    }
}
