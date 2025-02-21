using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : GoapAction
{
    // public override void Start()
    // {
    //     base.Start();
    // }
    
    public override bool IsAchievable()
    {
        return GetComponent<GoapPlanner>().health > 40;
    }


    public override void Execute()
    {
        if (GetComponent<GoapPlanner>().health > 40)
            isCompleted = true;

    }
}
