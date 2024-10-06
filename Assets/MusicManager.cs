using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioSource currentMusic; // Şu an çalan müzik
    public AudioSource newMusic;     // Geçiş yapmak istediğin yeni müzik
    public float transitionTime = 3.0f; // Geçiş süresi (saniye olarak)

    // Yeni müziğe geçiş başlatmak için
    public void TransitionToNewMusic()
    {
        StartCoroutine(FadeMusic());
    }

    IEnumerator FadeMusic()
    {
        float currentVolume = currentMusic.volume;
        float newVolume = 0;

        // Yeni müziği çalmaya başla (sessiz bir şekilde)
        newMusic.Play();
        newMusic.volume = 0;

        float elapsedTime = 0;

        // Geçiş süresi boyunca ses seviyelerini ayarla
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            float ratio = elapsedTime / transitionTime;

            // Şu anki müziğin sesini azalt
            currentMusic.volume = Mathf.Lerp(currentVolume, 0, ratio);

            // Yeni müziğin sesini artır
            newMusic.volume = Mathf.Lerp(newVolume, currentVolume, ratio);

            yield return null;
        }

        // Eski müziği durdur ve yeni müziği tam sesle çal
        currentMusic.Stop();
        currentMusic.volume = currentVolume;
    }
}
