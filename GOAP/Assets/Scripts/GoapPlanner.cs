using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoapPlanner : MonoBehaviour
{
    private List<GoapAction> actions;
    private GoapAction currentAction;
    
    public bool hasFood;
    
    
    public float health = 100f;
    public float maxHealth = 100f;
    public bool isTired;

    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI hpText;

    public GameObject restStop;

    void Update()
    {
        health -= Time.deltaTime * 5f; // HP decreases over time

        hpText.text = health.ToString();

        if (health <= 50f) isTired = true;
        if (health <= 0f) Debug.Log("Agent died!"); // Handle death condition

        if (currentAction != null)
        {
            if (!currentAction.isCompleted)
                currentAction.Execute();
            else
                SelectNextAction();
        }
    }


    void Start()
    {
        actions = new List<GoapAction>(GetComponents<GoapAction>());

        hasFood = false;
        
        SelectNextAction();
    }

    void SelectNextAction()
    {
        GoapAction bestAction = null;
        float lowestCost = Mathf.Infinity;

        foreach (GoapAction action in actions)
        {
            if (action.IsAchievable())
            {
                Debug.Log("Action: " + action.actionName + " | Cost: " + action.cost);

                if (action.cost < lowestCost)
                {
                    bestAction = action;
                    lowestCost = action.cost;
                }
            }
        }

        if (bestAction != null)
        {
            Debug.Log("Selected Action: " + bestAction.actionName);
            currentAction = bestAction;
        }
        else
        {
            Debug.Log("No valid action found!");
        }
    }


}