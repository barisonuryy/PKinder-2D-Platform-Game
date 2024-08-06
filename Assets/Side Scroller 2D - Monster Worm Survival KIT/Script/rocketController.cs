using UnityEngine;
using System.Collections;

public class rocketController : MonoBehaviour {

    public static int score;
	public int shield=100;
    public int ammo=50;
    int shotsfired;
	public int speed=2;
	public int sprint=2;
    public int moves = 3;
    public GameObject PrimaryWeaponBullet;
	public GameObject SecondaryWeaponBullet;
	public GameObject ThirdWeaponBullet;
    bool showGUI = true;
	bool paused = false;
	public AudioClip HurtSound;
	public AudioClip AmmoSound;
	public AudioClip HealthSound;
	bool gun2 = false;
	bool gun1 = true;
	bool gun3 = false;
	
	public static int numberofasteroids = 0;

	// Use this for initialization
	void Start () {
		score = 0;
	   
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.LeftShift))
		{
			transform.Translate(Vector3.up * sprint * Input.GetAxis("Vertical") * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			paused = !paused;
		}
		if (paused == true) {
			Time.timeScale = 0f;
		} else { Time.timeScale = 1f;
		}

        //top right corner
        Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0f));

        if (transform.position.x > topRightCorner.x)
        {
            transform.position = new Vector3(-topRightCorner.x, transform.position.y);
        }


        if (transform.position.x < -topRightCorner.x)
        {
            transform.position = new Vector3(topRightCorner.x, transform.position.y);
        }


        if (transform.position.y > topRightCorner.y)
        {
            transform.position = new Vector3(transform.position.x, -topRightCorner.y);
        }


        if (transform.position.y < -topRightCorner.y)
        {
            transform.position = new Vector3(transform.position.x, topRightCorner.y);
        }


		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			gun1 = true;
		}
		if (gun1 == true) {

		if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo>0))
        {
			if (paused == false) {
            shotsfired++;
            ammo--;
            Instantiate(PrimaryWeaponBullet, GameObject.FindGameObjectWithTag("shooter").transform.position, transform.rotation);
			}
        }
	}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			gun1 = !gun1;
			gun1 = false;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			gun2 = true;
		}
		if (gun2 == true) {

		if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo>0))
		{
			if (paused == false) {
				shotsfired++;
				ammo--;
				Instantiate(SecondaryWeaponBullet, GameObject.FindGameObjectWithTag("shooter2").transform.position, transform.rotation);
					Instantiate(SecondaryWeaponBullet, GameObject.FindGameObjectWithTag("shooter3").transform.position, transform.rotation);
				}
			}
	}

		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			gun2 = !gun2;
			gun2 = false;
		}

		//Third wep

		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			gun2 = !gun2;
			gun2 = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			gun3 = true;
		}
		if (gun3 == true) {
			
			if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo>0))
			{
				if (paused == false) {
					shotsfired++;
					ammo--;
					Instantiate(ThirdWeaponBullet, GameObject.FindGameObjectWithTag("shooter4").transform.position, transform.rotation);
					Instantiate(ThirdWeaponBullet, GameObject.FindGameObjectWithTag("shooter5").transform.position, transform.rotation);
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			gun3 = !gun3;
			gun3 = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			gun3 = !gun3;
			gun3 = false;
		}

		
		float randomX = 0f;
		float randomY = 0f;



		if (paused == false) {
		//Debug.Log (numberofasteroids > 0);
		if ((shield > 0) && (numberofasteroids > 0))
        {
            //mouse/touch input
            //-------------------------------
           
			Vector3 mousePos = Input.mousePosition;

            Vector3 mouseScreenPoint = Camera.main.ScreenToWorldPoint
                (mousePos);

            transform.LookAt(mouseScreenPoint, Vector3.forward);

            transform.eulerAngles = new Vector3
                (0, 0, -transform.eulerAngles.z);


			/*
            if (Input.GetMouseButton(0))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(mouseScreenPoint.x,mouseScreenPoint.y), 1f * Time.deltaTime);
            }
*/

            //-----------------------------------------------------------------------
            
            
            if (Input.GetKeyDown(KeyCode.Space) && moves > 0)
            {
                randomX = Random.Range(-topRightCorner.x + 1, topRightCorner.x - 1);
                randomY = Random.Range(-topRightCorner.y + 1, topRightCorner.y - 1);
                transform.position = new Vector3(randomX, randomY);
                moves--;
            }
            //------------------KEYBOARD CONTROL-----------------------
            transform.Translate(Vector3.up * speed * Input.GetAxis("Vertical") * Time.deltaTime);
           	transform.Rotate(Vector3.back * 2f * Input.GetAxis("Horizontal") * Time.deltaTime);
            //------------------END KEYBOARD CONTROL-------------------
        }
        else
        {
            showGUI = false;
        }
	}
	}


    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "enemy")
        {
            shield -= 10;
			GetComponent<AudioSource>().PlayOneShot(HurtSound, 2.7F);
            Destroy(otherObject.gameObject);
			numberofasteroids--;
        }
        if (otherObject.tag == "shield")
        {
            shield = 100;
			GetComponent<AudioSource>().PlayOneShot(HealthSound, 7.7F);
            Destroy(otherObject.gameObject);

        }
        if (otherObject.tag == "ammo")
        {
            ammo = 50;
			GetComponent<AudioSource>().PlayOneShot(AmmoSound, 7.7F);
            Destroy(otherObject.gameObject);
        }

    }


    void OnGUI()
    {

        if (showGUI)
        {
            GUI.color = Color.white;
            GUI.Label(new Rect(320, 7, 100, 25), "Reset Position:" + moves);
            GUI.Label(new Rect(100, 7, 100, 25), "Ammo:" + ammo);
            GUI.Label(new Rect(200, 7, 100, 25), "Shots Fired:" + shotsfired);
            GUI.Label(new Rect(10, 7, 100, 25), "Health:" + shield);
			GUI.Label(new Rect(450, 7, 100, 25), "Score:" + score);
        }
        else
        {
			//Game ENDED
			if (shield ==0)
			{
				GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 12.5f), 250, 25), "YOU DIED");
				ammo = 0;
			}
			else
			{
				ammo = 0;
				GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 34.5f), 200, 25), "DAY SURVIVED");
				if (GUI.Button(new Rect(((Screen.width / 2) - 50f), ((Screen.height / 2) - 12.5f), 100, 25),"CONTINUE"))
				{
					int currentLevel = Application.loadedLevel;
					Debug.Log(currentLevel);
					if (currentLevel < Application.levelCount-1)
					{
						Application.LoadLevel(currentLevel + 1);
					}
					else
					{
						Application.LoadLevel(0);		
					}
				}
			}

        }
    }

}
