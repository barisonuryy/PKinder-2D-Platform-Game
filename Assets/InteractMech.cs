using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractMech : MonoBehaviour
{
    private bool canUseJetPack;
    [SerializeField] private InputActionReference moveValue;
    [SerializeField] private float boostValue,pushValue;
    private Rigidbody2D rbCharacter;
    private BasicMech _basicMech;
    // Start is called before the first frame update
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody2D>();
        _basicMech = GetComponent<BasicMech>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
        //JetPack
        if (canUseJetPack )
        {
            rbCharacter.velocity = Vector2.right * (pushValue * Time.deltaTime);
            if(moveValue.action.IsPressed())
            rbCharacter.velocity = Vector2.up * (boostValue * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JetPack"))
        {
            canUseJetPack = true;
            _basicMech.SetMoveState(false);
          
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JetPack"))
        {
            canUseJetPack = false;
            _basicMech.SetMoveState(true);
           
        }
    }
}
