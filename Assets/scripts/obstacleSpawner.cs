using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject[] spawnPositions;
    [SerializeField] private float spawnTimeMax, spawnTimeMin;
    private bool spawnAble;

    private void Start()
    {
        spawnAble = true;
    }

    private void Update()
    {
        if (spawnAble)
        {
            StartCoroutine(timer());
        }
    }

    private void spawnObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacle = obstacles[index];

        int index1 = Random.Range(0, spawnPositions.Length);
        GameObject spawn = spawnPositions[index1];

        Instantiate(obstacle, spawn.transform.position, Quaternion.identity);
        Debug.Log("spawning done");
    }

    private IEnumerator timer()
    {
        Debug.Log("spawning start");
        spawnAble = false;
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        spawnObstacle();
        spawnAble = true;
        Debug.Log("spawning stopped");
    }
}
