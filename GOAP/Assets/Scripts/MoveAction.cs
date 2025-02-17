using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : GoapAction
{
    public Transform target;

    public override bool IsAchievable()
    {
        return target != null;
    }

    public override void Execute()
    {
        agent.SetDestination(target.position);
        if (Vector3.Distance(agent.transform.position, target.position) < 1f)
            isCompleted = true;
    }
}
