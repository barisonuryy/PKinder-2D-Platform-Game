using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemyMovement : MonoBehaviour
{
    private BoxCollider2D bd;
    // Start is called before the first frame update
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private EnemyPortalMech _enemyPortalMech;
    private bool isSelfSpawn;
    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Start()
    {
        if (_enemyPortalMech != null)
        {
            _enemyPortalMech = GameObject.Find("EnemyPortalArea").GetComponent<EnemyPortalMech>();
            isSelfSpawn = _enemyPortalMech.isCreatedByPortal;
            if (isSelfSpawn)
            {
                leftEdge = _enemyPortalMech.GetComponent<Transform>().GetChild(0);
                rightEdge = _enemyPortalMech.GetComponent<Transform>().GetChild(1);
            }

            bd = GetComponent<BoxCollider2D>();
        }
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }

       
     
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }


 
}
