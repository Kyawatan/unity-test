using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private float m_spawnInterval = 10f;
    [SerializeField] private float m_spawnDistance = 15f;

    void Start()
    {
        // 10秒に1体敵を生成する
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        // 畑にニンジンが残っていれば生成
        while (GameDirector.GetInstance.IsExistCarrot)
        {
            // 畑を中心に出現する方向をランダム決定（距離は固定）
            float rand = Random.Range(-120f, 120f);
            Vector3 spawnVec = Quaternion.Euler(0f, rand, 0f) * new Vector3(0f, 0f, m_spawnDistance);
            Instantiate(m_enemyPrefab, spawnVec, Quaternion.identity);

            yield return new WaitForSeconds(m_spawnInterval);
        }
    }
}
