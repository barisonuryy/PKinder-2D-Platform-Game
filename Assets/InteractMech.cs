using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractMech : MonoBehaviour
{
    private bool canUseJetPack;
    [SerializeField] private InputActionReference moveValue;
    [SerializeField] private float boostValue, pushValue;
    private Rigidbody2D rbCharacter;
    private BasicMech _basicMech;
    [SerializeField] GameObject fuel;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody2D>();
        _basicMech = GetComponent<BasicMech>();
        anim = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().buildIndex == 5)
            canUseJetPack = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (canUseJetPack && !_basicMech.isGrounded())
        {

            anim.SetTrigger("isIdle");
            anim.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {

        if (canUseJetPack)
        {
            rbCharacter.velocity = Vector2.right * (pushValue * Time.deltaTime);
            if (moveValue.action.IsPressed())
                rbCharacter.velocity = Vector2.up * (boostValue * Time.deltaTime);
            rbCharacter.gravityScale = 8;
            anim.SetTrigger("isIdle");
            anim.SetBool("isWalking", false);
            fuel.SetActive(true);   

        }
        else
            fuel.SetActive(false);
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
            rbCharacter.gravityScale = 5;
            canUseJetPack = false;
            _basicMech.SetMoveState(true);
            anim.enabled = true;

        }
    }
}