using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    public static FoodSpawner instance;
    
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    
    [Header("Food Prefab")] 
    public GameObject foodPrefab;
    
    [Header("Ground")] 
    public GameObject ground;
    
    public void SpawnFood()
    {
        Vector3 randSpawnLocation = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
        Instantiate(foodPrefab, randSpawnLocation, quaternion.identity);
        
        Vector3 randSpawnLocation2 = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
        Instantiate(foodPrefab, randSpawnLocation, quaternion.identity);
    }
}
