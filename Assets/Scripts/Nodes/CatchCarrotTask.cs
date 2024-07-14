

using BehaviourTrees;
using UnityEngine;

public class CatchCarrotTask : Task
{
    protected override Status OnEvaluate(Transform agent, Blackboard blackboard)
    {
        var carrot = blackboard.Get<GameObject>("SeeCarrot");
        var speed = blackboard.Get<float>("speed");

        if (blackboard.Get<bool>("HaveCarrot"))
            return Status.Success;

        if (carrot == null) return Status.Failure;


        if (Vector2.Distance(agent.position, carrot.transform.position) <= 0.5f)
        {

            blackboard.Add<bool>("HaveCarrot",true);
            carrot.GetComponent<Carrot>().OnCatched();
            return Status.Success;
        }


        Vector2 position = Vector2.MoveTowards(agent.position, carrot.transform.position, speed * Time.deltaTime);
        position.y = agent.position.y;
        agent.position = position;
        return Status.Running;
    }
}