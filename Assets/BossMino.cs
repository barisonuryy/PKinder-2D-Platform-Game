using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMino : MonoBehaviour
{
    [SerializeField] Level2EnemySystem enemySystem;

    // Start is called before the first frame update
    private void OnDestroy()
    {
        Debug.Log("Mino Yok edildi");
        enemySystem.minoDie();
    }
}
