using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    bool isStarted;

    void Start()
    {
        isStarted = true;
    }

    IEnumerator OpenTile(int b)
    {
        isStarted = false;

        for (int i = 0; i < gameObject.transform.GetChild(b).childCount; i++)
        {
            gameObject.transform.GetChild(b).GetChild(i).gameObject.SetActive(true);
            StartCoroutine(gameObject.GetComponent<FadeInFadeOut>()
                .FadeIn(gameObject.transform.GetChild(b).GetChild(i).gameObject.GetComponent<SpriteRenderer>()));
            yield return new WaitForSeconds(0.1f);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isStarted && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Talha");
            StartCoroutine(HandleKeyInput());
        }
    }

    IEnumerator HandleKeyInput()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Talha1");
                StartCoroutine(OpenTile(0));
                break;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Talha2");
                StartCoroutine(OpenTile(1));
                break;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Talha3");
                StartCoroutine(OpenTile(2));
                break;
            }
            yield return null;
        }
    }
}
