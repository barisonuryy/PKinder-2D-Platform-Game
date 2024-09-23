using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexTrapMech : MonoBehaviour
{
    public GameObject objectToSpawn; // Üretilecek obje (başlangıçta aktif olmalı)
    public Transform[] spawnPositions; // Üretilecek pozisyonların listesi
    public float respawnDelay = 5f; // Yeniden etkinleştirme gecikmesi
    private int lastSpawnIndex = -1; // Son üretilen pozisyonun indeksi

    void Start()
    {
        SpawnObject(); // İlk objeyi üret
    }

    void SpawnObject()
    {
        // Son üretilen pozisyonu hariç tutarak rastgele pozisyon seç
        int newIndex;
        do
        {
            newIndex = Random.Range(0, spawnPositions.Length);
        } while (newIndex == lastSpawnIndex);

        lastSpawnIndex = newIndex; // Yeni pozisyonun indeksini kaydet

        // Objeyi seçilen pozisyona taşı ve aktif hale getir
        objectToSpawn.transform.position = spawnPositions[newIndex].position;
        objectToSpawn.SetActive(true); // Objeyi tekrar aktif hale getir
    }

    public IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(respawnDelay); // Bekleme süresi
        SpawnObject(); // Yeni objeyi seçilen pozisyonda etkinleştir
    }
}