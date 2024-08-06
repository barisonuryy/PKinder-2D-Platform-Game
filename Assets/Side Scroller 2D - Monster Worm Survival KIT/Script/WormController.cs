using UnityEngine;
using System.Collections;

public class WormController : MonoBehaviour {

	public static int score;
	public int shield=100;
	public int speed=9;
	public int sprint=11;
	bool showGUI = true;
	float startTime;
	bool paused = false;
	public AudioClip EatSound;
	public AudioClip BombSound;
	public AudioClip ComeOutSound;
	public AudioClip PoisonSound;
	public AudioClip DieSound;
	public Texture GUITexture1;
	public Texture GUITexture2;
	public Texture DeadTexture;

	float m_Timer = 1.0f;
	public GUIStyle DisplayTimeSurvived = new GUIStyle();
	public GUIStyle DisplayHealth = new GUIStyle();

	public static int numberofasteroids = 100;
	
	// Use this for initialization
	void Start () {
		score = 0;
		startTime = Time.time;
		StartCoroutine(Example());
	}
	
	// Update is called once per frame
	void Update () {

		m_Timer -= Time.deltaTime;
		if(m_Timer <= 0.0f)

		{
			score++;
			m_Timer = 1.0f;
		}



		if (Input.GetKeyDown (KeyCode.P)) {
			paused = !paused;
		}
		if (paused == true) {
			Time.timeScale = 0f;
		} else { Time.timeScale = 1f;
		}


		
		
		
		if (paused == false) {
		//Debug.Log (numberofasteroids > 0);
		if ((shield > 0))
		{
			//mouse/touch input
			//-------------------------------
			
			/* Vector3 mousePos = Input.mousePosition;
			
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
			
			/*
			if (Input.GetKeyDown(KeyCode.Space) && moves > 0)
			{
				randomX = Random.Range(-topRightCorner.x + 1, topRightCorner.x - 1);
				randomY = Random.Range(-topRightCorner.y + 1, topRightCorner.y - 1);
				transform.position = new Vector3(randomX, randomY);
				moves--;
			} */
			//------------------KEYBOARD CONTROL-----------------------
				if(Input.GetKey(KeyCode.LeftShift))
				{
					transform.Translate(Vector3.up * sprint * Input.GetAxis("Vertical") * Time.deltaTime);
				}
			transform.Translate(Vector3.up * speed * Input.GetAxis("Vertical") * Time.deltaTime);
			transform.Rotate(Vector3.back * 70f * Input.GetAxis("Horizontal") * Time.deltaTime);
			//------------------END KEYBOARD CONTROL-------------------
		}
		else
			{
			showGUI = false;
		}
	}
	}


	IEnumerator Example() {
		while (true) {
		print(Time.time);
		yield return new WaitForSeconds(5);
		shield -= 10;
	}
	}
	
	void OnTriggerEnter2D(Collider2D otherObject)
	{
		if (otherObject.tag == "enemy")
		{
			shield = 100;
			Destroy(otherObject.gameObject);
			GetComponent<AudioSource>().PlayOneShot(EatSound, 2.7F);
			numberofasteroids--;
		}
		/*if (otherObject.tag == "shield")
		{
			shield = 100;
			GetComponent<AudioSource>().PlayOneShot(HealthSound, 7.7F);
			Destroy(otherObject.gameObject);
			
		}*/
		if (otherObject.tag == "bomb")
		{
			shield -= 10;
			GetComponent<AudioSource>().PlayOneShot(BombSound, 7.7F);
			Destroy(otherObject.gameObject);
		}

		if (otherObject.tag == "ground")
		{
			GetComponent<AudioSource>().PlayOneShot(ComeOutSound, 7.7F);
		}

		if (otherObject.tag == "friend")
		{
			GetComponent<AudioSource>().PlayOneShot(EatSound, 2.7F);
			numberofasteroids--;
		}

		if (otherObject.tag == "bug")
		{
			shield -= 10;
			GetComponent<AudioSource>().PlayOneShot(PoisonSound, 2.7F);
			numberofasteroids--;
			Destroy(otherObject.gameObject);
		}

		if (otherObject.tag == "npc")
		{
			GetComponent<AudioSource>().PlayOneShot(EatSound, 2.7F);
			numberofasteroids--;
			Destroy(otherObject.gameObject);
		}

	}
	
	
	void OnGUI()
	{
		//if (((Time.time - startTime) > levelLenght))
		{
			//GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 34.5f), 200, 25), "DAY SURVIVED");
			//GUI.Button(new Rect(((Screen.width / 2) - 50f), ((Screen.height / 2) - 12.5f), 100, 25),"RETRY");
		}
		
		if (showGUI)
		{
			//GUI.color = Color.red;
			//GUI.Label(new Rect(100, 7, 100, 25), "Ammo:" + ammo);
			//GUI.Label(new Rect(200, 7, 100, 25), "Shots Fired:" + shotsfired);
			//GUI.Label(new Rect(17, 25, 100, 25), "Health:" + shield);
			//GUI.Label (new Rect (10, 55, 150, 50), "Time Left: " + (levelLenght-(Time.time - startTime)));
			//GUI.Label (new Rect (17, 7, 150, 50), "Time Survived: " + (Time.time - startTime));
			GUI.Label (new Rect (7, 17, 110, 110), "Health: " +shield, DisplayHealth);
			GUI.Label (new Rect (7, 17, 110, 110), "Time Survived: " +score+ "s", DisplayTimeSurvived);
			GUI.DrawTexture(new Rect(0, -23, 100, 100), GUITexture1, ScaleMode.ScaleToFit, true, 0.0F);
			GUI.color = Color.red;
			GUI.DrawTexture(new Rect(0, 8, 100, 100), GUITexture2, ScaleMode.ScaleToFit, true, 0.0F);
		}
		else
		{
			//Game ENDED
			if (shield ==0)
			{
				GUI.DrawTexture(new Rect(0, -133, 950, 1000), DeadTexture, ScaleMode.ScaleToFit, true, 0.0F);
				GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 12.5f), 250, 25), "YOU DIED, WORM");
				GetComponent<AudioSource>().PlayOneShot(DieSound, 0.5F);
				if (GUI.Button(new Rect(((Screen.width / 2) - 50f), ((Screen.height / 2) - -10.5f), 118, 25),"CONTINUE"))
				{
							Application.LoadLevel(0);		
				}
				if (Time.timeScale == 1.0F)
					Time.timeScale = 0.0F;
					AudioListener.volume = 1 - AudioListener.volume;
			}

		/*	else
			{
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
			} */
			
		}
	}
	
}