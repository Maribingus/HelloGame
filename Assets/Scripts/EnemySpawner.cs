using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public Transform player;
    public float spawnDelay;
    public float distMin;
    public float distMax;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SpawnTestEnemy());
    }

    IEnumerator SpawnTestEnemy()
    {
        Instantiate(Enemies[0], player.position + GetRandomDirection(), Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnTestEnemy());
    }

    private Vector3 GetRandomDirection()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float distance = Random.Range(distMin, distMax);
        float x = Mathf.Cos(angle) * distance;
        float y = Mathf.Sin(angle) * distance;
        return new Vector3(x, y, 0);
    }
}
