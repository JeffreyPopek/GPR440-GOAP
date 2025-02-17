using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [Header("Food Prefab")] 
    public GameObject foodPrefab;
    
    [Header("Ground")] 
    public GameObject ground;


    private float _timer;

    private void Awake()
    {
        SpawnFood();

        _timer = 0f;    
    }

    private void Update()
    {
        if (_timer > 5f)
        {
            SpawnFood();
            _timer = 0;
        }
        else
            _timer += Time.deltaTime;
    }

    private void SpawnFood()
    {
        Bounds bounds = ground.GetComponent<Collider>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
        
        Instantiate(foodPrefab);
        foodPrefab.transform.position = bounds.center + new Vector3(offsetX, 1, offsetZ);
    }
}
