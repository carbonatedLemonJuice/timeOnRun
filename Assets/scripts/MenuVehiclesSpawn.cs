using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVehiclesSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] vehicles;
    [SerializeField] GameObject[] positions;
    [SerializeField] float vehiclesGap;
    private bool canSpawn = true;

    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn)
        {
            GameObject newVeh = Instantiate(vehicles[Random.Range(0, vehicles.Length)], positions[Random.Range(0, positions.Length)].transform.position, Quaternion.identity);
            canSpawn = false;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(vehiclesGap);
        canSpawn = true;
    }
}
