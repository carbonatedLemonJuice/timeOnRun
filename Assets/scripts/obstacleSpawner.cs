using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles; //array of obstacles
    [SerializeField] private GameObject[] spawnPositions; //array of possible positions obstacles can spawn
    [SerializeField] private float spawnTimeMax, spawnTimeMin; //the interval in which obstacle(s) can spawn, takes random between the two
    private bool spawnAble; //checks if spawning of obstacle is possible

    private void Start()
    {
        spawnAble = true; //at start set to true
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
        //takes random index value of from obstacle array and store it in a game object
        int ObsIndex = Random.Range(0, obstacles.Length);
        GameObject obstacle = obstacles[ObsIndex];

        //takes random index value of from spawnPosition array and store it in a game object
        int PosIndex = Random.Range(0, spawnPositions.Length);
        GameObject spawn = spawnPositions[PosIndex];

        //spawns the obstacle at the selected position
        Instantiate(obstacle, spawn.transform.position, Quaternion.identity);
        Debug.Log("spawning done");
    }

    private IEnumerator timer() //coroutine function to spawn platform
    {
        Debug.Log("spawning start");
        spawnAble = false; //bool set to false 
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax)); //random interval time is calculated
        spawnObstacle(); //function called
        spawnAble = true; //bool set to true after spawning
        Debug.Log("spawning stopped");
    }
}
