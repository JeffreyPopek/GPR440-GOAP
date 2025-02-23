using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestAction : GoapAction
{
    public override void Start()
    {
        base.Start();
        cost = GetComponent<GoapPlanner>().isTired ? 1f : 10f; // Prioritize when tired
    }
    
    public override bool IsAchievable()
    {
        bool canRest = GetComponent<GoapPlanner>().isTired && GetComponent<GoapPlanner>().restStop != null;
        //Debug.Log("Can Rest: " + canRest);
        return canRest;
    }


    public override void Execute()
    {
        Debug.Log("executing rest pre");
        //if (GetComponent<GoapPlanner>().restStop == null)
            //GetComponent<GoapPlanner>().restStop = GameObject.FindWithTag("RestStop");

        GameObject restStop = GetComponent<GoapPlanner>().restStop;
        if (restStop != null)
        {
            agent.SetDestination(restStop.transform.position);

            if (Vector3.Distance(agent.transform.position, restStop.transform.position) < 1.5f)
            {
                Debug.Log("Resting...");
                GoapPlanner planner = GetComponent<GoapPlanner>();

                planner.health += 50f;
                if (planner.health > planner.maxHealth) planner.health = planner.maxHealth;

                planner.isTired = false;
                isCompleted = true;
                
                FoodSpawner.instance.SpawnFood();
            }
        }
    }

}
