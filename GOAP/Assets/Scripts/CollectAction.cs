using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectAction : GoapAction
{
    public GameObject targetFood;

    public override void Start()
    {
        base.Start();
        cost = 5f; // high cost, do last
        FindClosestFood();
    }
    
    public override bool IsAchievable()
    {
        // find if a food exists
        targetFood = GameObject.FindWithTag("Food");
        return targetFood != null && !GetComponent<GoapPlanner>().hasFood;
    }

    public override void Execute()
    {
        if (targetFood == null) return;
        
        //Debug.Log("executing find food action");

        agent.SetDestination(targetFood.transform.position);

        if (Vector3.Distance(agent.transform.position, targetFood.transform.position) < 1f)
        {
            targetFood.GetComponent<Food>().GetCollected();
            
            targetFood = null;
            GetComponent<GoapPlanner>().hasFood = true;
            isCompleted = true;
            
            Debug.Log("completed find food action");
        }
    }

    private void FindClosestFood()
    {
        //Debug.Log($"agent pos {agent.transform.position}");
        GameObject[] found;
        found = GameObject.FindGameObjectsWithTag("Food");

        targetFood = found[0];
        
        if (found.Length != 1)
        {
            foreach (var go in found)
            {
                if (Vector3.Distance(go.transform.position, agent.transform.position) <
                    Vector3.Distance(targetFood.transform.position, agent.transform.position))
                    targetFood = go;
            } 
        }
    }
}
