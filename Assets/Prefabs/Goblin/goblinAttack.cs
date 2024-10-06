using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goblinAttack : MonoBehaviour
{
   public GameObject Arrow;
    public float launchForce;
    public Transform shotPoint;
    public GameObject point;
    GameObject[] points;
    public int numberofPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    private float dirPlayer;
    private float constantDir;
    Vector2 mousePosition;
    Vector2 direcPosition;
    private float coolDownWeap;
    public AnimationClip animationClip;
    float weapTime;
    [SerializeField] private Transform playerPos;
    private bool rangeControl;
    private Animator _animator;
   
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        weapTime = 0;


        coolDownWeap = animationClip.length;


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            playerPos = GameObject.Find("MainCharacter").transform;
        }
        if (playerPos != null)
        {
            // Karakterin yerel ölçeğine göre yönünü kontrol et
            dirPlayer = transform.root.localScale.x;

            // Karakterin pozisyonu ile oyuncu arasındaki farkı hesapla
            Vector2 gunPosition = transform.position;
            direcPosition = new Vector2(playerPos.position.x, playerPos.position.y) - gunPosition;

            // Karakterin sağa veya sola bakıp bakmadığına göre yönünü belirle
            direction = Mathf.Sign(dirPlayer) * direcPosition.normalized;

            // Eğer karakter sola bakıyorsa yayı 180 derece döndür
            if (dirPlayer < 0)
            {
                transform.right = -direction; // Yay sola bakarken sağa dönmek zorunda
            }
            else
            {
                transform.right = new Vector2(direction.x, direction.y); // Yay sağa bakarken normalde
            }
        }

            rangeControl = transform.GetComponentInParent<TriggerControlArcher>().isInRange;

            if (Time.time > weapTime && rangeControl)
            {
                Invoke(nameof(Shoot), 0.51f);
                _animator.SetBool("attack", true);
                weapTime = Time.time + coolDownWeap;
            }
            else
            {
                _animator.SetBool("attack", false);
            }
        
    }

    void Shoot()
    {
        GameObject newSB = Instantiate(Arrow, shotPoint.position,shotPoint.rotation);
        newSB.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
       
 
    }
  
   

}
