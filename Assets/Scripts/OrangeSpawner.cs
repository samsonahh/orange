using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrangeSpawner : MonoBehaviour
{
    public Orange orangePrefab;

    [Header("Config")]
    public Vector2 spawnIntervalRange = new Vector2(2, 3);
    public Vector2 spawnCenter;
    public float spawnWidth = 5f;

    private float timePassed = 0f;
    public float intervalMultiplier = 0.9f;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnCenter, new Vector3(2f * spawnWidth, 1f, 0));
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float randomSpawnInterval = Random.Range(spawnIntervalRange.x, spawnIntervalRange.y) * Mathf.Pow(intervalMultiplier, timePassed);
            yield return new WaitForSeconds(randomSpawnInterval);

            Vector2 randomPosition = new Vector2(spawnCenter.x + Random.Range(-spawnWidth, spawnWidth), spawnCenter.y);
            Instantiate(orangePrefab, randomPosition, Quaternion.identity);
        }
    }
}
