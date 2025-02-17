using UnityEngine;
using UnityEngine.AI;

public abstract class GoapAction : MonoBehaviour
{
    public string actionName;
    public float cost = 1f;
    public bool isCompleted;
    protected NavMeshAgent agent;

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public abstract bool IsAchievable();
    public abstract void Execute();
}