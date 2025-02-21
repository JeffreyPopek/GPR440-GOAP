using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject newFood;
    

    public void GetCollected()
    {
        StartCoroutine(CO_Move());
    }

    private IEnumerator CO_Move()
    {
        Vector3 randSpawnLocation = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));


        //Instantiate(newFood, randSpawnLocation, quaternion.identity);
        
        Destroy(gameObject);

        yield return null;
    }
}
