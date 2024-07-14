using System.Collections;
using System.Collections.Generic;
using BehaviourTrees;
using UnityEngine;

public class SeeCarrotTask : Task
{
    private float radius = 2.0f;

    protected override Status OnEvaluate(Transform agent, Blackboard blackboard)
    {
        if (blackboard.Get<bool>("HaveCarrot")) return Status.Success;
        var colliders = Physics2D.OverlapCircleAll(agent.position, radius);
        if (colliders == null) return Status.Failure;


        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("Carrot")) continue;
            if(blackboard.Get<GameObject>("SeeCarrot") == null)
            {
                
                blackboard.Add("SeeCarrot", collider.gameObject);
            }

            return Status.Success;
        }

        return Status.Failure;
    }
}