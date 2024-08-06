using UnityEngine;
using System.Collections;

public class enemygenerator : MonoBehaviour {

    public GameObject enemy;
    public GameObject npc;
    public GameObject bomb;
    public int maxEnemies;
    int enemies=0;

    void Start()
    {
         
		WormController.numberofasteroids = maxEnemies;
		StartCoroutine ("countDown");
    }
	IEnumerator countDown()
	{
		yield return new WaitForSeconds (5f);
		StartCoroutine("generateEnemies");
		StartCoroutine("generatePowerups");

	}
    IEnumerator generateEnemies()
    {
        while(enemies < maxEnemies) {
			float randomX = Random.Range(-21f,40f); //-9 , 9f //(1f,40f);
            float randomY = Random.Range(9f,9f);

            Vector3 position = new Vector3(randomX,randomY,0f);
            Instantiate (enemy, position,Quaternion.identity);
            enemies++;
            yield return new WaitForSeconds(6f);
        }

    }

    IEnumerator generatePowerups()
    {
        while (true)
        {
            float randomX = Random.Range(-3f, 40f); //4
            float randomY = Random.Range(-40f, 3f); //4

            int npcorbomb = Random.Range(0, 2);

            
            Vector3 position = new Vector3(randomX, randomY, 0f);

			if (npcorbomb == 1)
            {
                Instantiate(bomb, position, Quaternion.identity);
            }
            else
            {
                Instantiate(npc, position, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }


    /*
    IEnumerator generateEnemies()
    {
        while (true)
        {
           // Debug.Log(enemies);
            enemies = GameObject.FindGameObjectsWithTag("enemy").Length;
            if (enemies <= maxEnemies)
            {
                int direction = Random.Range(0, 4);

                if (direction == 0)
                    Instantiate(enemy, new Vector3(0, 4, 0), Quaternion.identity);


                if (direction == 1)
                    Instantiate(enemy, new Vector3(0, -4, 0), Quaternion.identity);

                if (direction == 2)
                    Instantiate(enemy, new Vector3(4, 0, 0), Quaternion.identity);

                if (direction == 3)
                    Instantiate(enemy, new Vector3(-4, 0, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1f);
        }
     }*/

    
}
