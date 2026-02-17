using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] Transform[] Lane;
    [SerializeField] GameObject[] TrafficVehicle;
    [SerializeField] CarController carController;
    [SerializeField] float minSpawnTime = 30f;
    [SerializeField] float maxSpawnTime = 60f;
    private float dynamicTimer ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrafficSpwaner());
    }

    public void SetCarController(CarController controller)
    {
        carController = controller;
    }

    IEnumerator TrafficSpwaner()
    {
        yield return new WaitForSeconds(4f);
        while (true)
        {
            if (carController.CarSpeed() > 20f)
            {
                dynamicTimer = Random.Range(minSpawnTime, maxSpawnTime) /carController.CarSpeed();
                SpawnTrafficVehicle();
            }
            
            yield return new WaitForSeconds(dynamicTimer);
        }
    }

    void SpawnTrafficVehicle()
    {
        int randomLaneIndex = Random.Range(0, Lane.Length);
        int randomTrafficVehicleIndex = Random.Range(0, TrafficVehicle.Length);
        Instantiate(TrafficVehicle[randomLaneIndex], Lane[randomLaneIndex].position, Quaternion.identity);
    }
}
