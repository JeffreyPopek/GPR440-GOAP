using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAction : GoapAction
{
    private GameObject targetFood;

    public override void Start()
    {
        base.Start();
        cost = 5f; // high cost, do last
    }
    
    public override bool IsAchievable()
    {
        targetFood = GameObject.FindWithTag("Food"); // Find a food item
        return targetFood != null && !GetComponent<GoapPlanner>().hasFood;
    }

    public override void Execute()
    {
        if (targetFood == null) return;
        
        //Debug.Log("executing find food action");

        agent.SetDestination(targetFood.transform.position);

        if (Vector3.Distance(agent.transform.position, targetFood.transform.position) < 1f)
        {
            Destroy(targetFood); // Simulate picking up food
            GetComponent<GoapPlanner>().hasFood = true;
            isCompleted = true;
            
            Debug.Log("completed find food action");
        }
    }
}
