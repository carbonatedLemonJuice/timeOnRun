using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] RoadObstacles; //array of obstacles
    [SerializeField] private GameObject[] pavementObstacles;
    [SerializeField] private GameObject[] RoadSpawnPos; //array of possible positions obstacles can spawn
    [SerializeField] private GameObject[] pavementSpawnPos;
    [SerializeField] private float spawnTimeMax, spawnTimeMin; //the interval in which obstacle(s) can spawn, takes random between the two
    [SerializeField] private Slider chaosSlider;
    private bool spawnAble, pavementSpawnable; //checks if spawning of obstacle is possible

    private void Start()
    {
        chaosSlider = chaosSlider.GetComponent<Slider>();
        spawnAble = true; //at start set to true
        pavementSpawnable = true;
    }

    private void Update()
    {
        if (spawnAble)
        {
            StartCoroutine(timer());
        }

        if (pavementSpawnable && !spawnAble)
        {
            StartCoroutine(pavementTimer());
        }
    }

    private void spawnRoadObstacle() //for spawning on road
    {
        //takes random index value of from obstacle array and store it in a game object
        int ObsIndex = Random.Range(0, RoadObstacles.Length);
        GameObject obstacle = RoadObstacles[ObsIndex];

        //takes random index value of from spawnPosition array and store it in a game object
        int PosIndex = Random.Range(0, RoadSpawnPos.Length);
        GameObject spawn = RoadSpawnPos[PosIndex];

        if (chaosSlider.value >= 12.5f)
        {
            Debug.Log("value greater than 12.5f");
            if (Random.Range(0, 3) == 2)
            {
                if (ObsIndex != 3)
                {
                    GameObject carObs = Instantiate(obstacle, spawn.transform.position, Quaternion.identity);
                    carObs.transform.localScale = new Vector3(5, -5, 5);
                }

                else
                {
                    Debug.Log("big boi coming up");
                    Instantiate(obstacle, RoadSpawnPos[1].transform.position, Quaternion.identity);
                }

            }

            else
            {
                if (ObsIndex != 3)
                {
                    Instantiate(obstacle, spawn.transform.position, Quaternion.identity);
                }

                else
                {
                    Instantiate(obstacle, RoadSpawnPos[1].transform.position, Quaternion.identity);
                }
            }
        }

        else
        {
            if (ObsIndex != 3)
            {
                Instantiate(obstacle, spawn.transform.position, Quaternion.identity);
            }

            else
            {
                Instantiate(obstacle, RoadSpawnPos[1].transform.position, Quaternion.identity);
            }
        }
        //spawns the obstacle at the selected position

        //Debug.Log("spawning done");
    }

    private IEnumerator timer() //coroutine function to spawn platform
    {
        //Debug.Log("spawning start");
        spawnAble = false; //bool set to false 
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax)); //random interval time is calculated
        spawnRoadObstacle(); //function called
        spawnAble = true; //bool set to true after spawning
        //Debug.Log("spawning stopped");
    }

    private IEnumerator pavementTimer() 
    {
        pavementSpawnable = false;
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        spawnPavementObstacle();
        pavementSpawnable = true;
    }

    private void spawnPavementObstacle() //for spawning on pavement
    {
        //takes random index value of from obstacle array and store it in a game object
        int ObsIndex = Random.Range(0, pavementObstacles.Length);
        GameObject obstacle = pavementObstacles[ObsIndex];

        //takes random index value of from spawnPosition array and store it in a game object
        int PosIndex = Random.Range(0, pavementSpawnPos.Length);
        GameObject spawn = pavementSpawnPos[PosIndex];

        //spawns the obstacle at the selected position
        Instantiate(obstacle, spawn.transform.position, Quaternion.identity);
        //Debug.Log("spawning done");
    }
}
