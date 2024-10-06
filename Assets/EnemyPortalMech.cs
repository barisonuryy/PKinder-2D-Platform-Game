using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortalMech : MonoBehaviour
{
   public GameObject portalPrefab;
    public GameObject[] enemyPrefabs; // Çeşitli düşman prefab'ları
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;
    public float spawnDelay = 5f;
    public float enemySpawnTime = 10f;
    public int enemyCount = 3;
    public float spawnRadius = 2f; // Minimum mesafe
    [SerializeField] private AnimationClip enemyAnimClip;
    public bool isCreatedByPortal,isDestroyed;
    [SerializeField] float valOff,valCam,tempValOff,tempValCam;
    [SerializeField] GameObject Cam;
    [SerializeField] GameObject door;
   [SerializeField] MusicManager musicManager;
    [SerializeField] GameObject boss;
    private GameObject currentPortal;
    private bool portalDestroyed = false;

    void Start()
    {
       
        tempValOff=Cam.GetComponent<CameraController>().offset.y;
        tempValCam = Cam.GetComponent<Camera>().orthographicSize;
        isCreatedByPortal = false;
        enemySpawnTime = enemyAnimClip.length;
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
        CancelInvoke("SpawnEnemies");
        Invoke("SpawnPortal", spawnDelay);
    }

    void SpawnEnemies()
    {
        if (!portalDestroyed) 
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPositionNearPortal(currentPortal.transform.position);
                GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Rastgele düşman seçimi
                Instantiate(randomEnemy, spawnPosition, Quaternion.identity);
                
            }

            isCreatedByPortal = true;
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2),
           0
            
        );
    }

    Vector3 GetRandomSpawnPositionNearPortal(Vector3 portalPosition)
    {
        Vector3 randomOffset;
        do
        {
            randomOffset = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                0f, // Yükseklik sabit kalabilir
                Random.Range(-spawnRadius, spawnRadius)
            );
        }
        while (randomOffset.magnitude < spawnRadius / 2); // Belirli bir minimum mesafeyi garanti et

        return portalPosition + randomOffset;
    }
    private void OnDestroy()
    {
        isDestroyed = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cam.GetComponent<Camera>().orthographicSize = valCam;
            Cam.GetComponent<CameraController>().offset.y = valOff;
        }
        boss.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        door.SetActive(true);
        musicManager.TransitionToNewMusic();
    }
}
