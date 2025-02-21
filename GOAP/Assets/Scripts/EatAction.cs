using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatAction : GoapAction
{
    public override void Start()
    {
        base.Start();
        cost = 3f; // medium cost, higher prio if hp is low
    }
    
    public override bool IsAchievable()
    {
        return GetComponent<GoapPlanner>().hasFood;
    }

    
    public override void Execute()
    {
        Debug.Log("executing eat food action");
        GoapPlanner planner = GetComponent<GoapPlanner>();

        if (!planner.hasFood)
        {
            Debug.Log("dont have food but executing1");
            return;
        }
    
        planner.health += 40f; // Restore HP
        if (planner.health > planner.maxHealth) 
            planner.health = planner.maxHealth;
    
        planner.hasFood = false; // Food consumed
        planner.isTired = false; // Reset tired status
        isCompleted = true;
        Debug.Log("completed eat food action");
    }
}
