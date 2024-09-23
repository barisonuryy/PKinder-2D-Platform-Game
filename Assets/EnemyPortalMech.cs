using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortalMech : MonoBehaviour
{
    public GameObject portalPrefab;
    public GameObject enemyPrefab; // Düşman prefab'ı
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;
    public float spawnDelay = 5f; // Portal yeniden doğma süresi
    public float enemySpawnTime = 10f; // Düşmanların spawn olacağı süre
    public int enemyCount = 3; // Kaç düşman spawn edilecek
    public AnimationClip portalAnimClip;
    private GameObject currentPortal;
    private bool portalDestroyed = false;

    void Start()
    {
        enemySpawnTime = portalAnimClip.length;
        SpawnPortal();
    }

    void SpawnPortal()
    {
        Vector3 randomPosition = GetRandomPosition();
        currentPortal = Instantiate(portalPrefab, randomPosition, Quaternion.identity);
        portalDestroyed = false;

        // Portal yok edilmezse belirli süre sonra düşmanları spawn et
        Invoke("SpawnEnemies", enemySpawnTime);

        // Portalın yok edilmesi için event dinleyicisi ekle
        currentPortal.GetComponent<EnemyPortal>().OnPortalDestroyed += HandlePortalDestroyed;
    }

    void HandlePortalDestroyed()
    {
        portalDestroyed = true;
        Destroy(currentPortal);
        CancelInvoke("SpawnEnemies"); // Portal yok edilirse düşman spawn'ı iptal et
        Invoke("SpawnPortal", spawnDelay); // Belirli süre sonra yeni portal oluştur
    }

    void SpawnEnemies()
    {
        if (!portalDestroyed) // Portal hala duruyorsa düşmanları spawn et
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefab, currentPortal.transform.position, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
            spawnAreaCenter.y,
            Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
        );
    }
}
