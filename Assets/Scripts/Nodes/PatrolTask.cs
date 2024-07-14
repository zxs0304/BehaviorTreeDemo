using BehaviourTrees;
using UnityEngine;

public class PatrolTask : Task
{
    private int currentIndex;
    private Transform[] waypoints;


    public PatrolTask(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        currentIndex = 0;
    }

    protected override Status OnEvaluate(Transform agent, Blackboard blackboard)
    {
        float speed = blackboard.Get<float>("speed");
        Transform currentWaypoint = waypoints[currentIndex];
        bool arrived = Vector2.Distance(agent.position, currentWaypoint.position) < 0.1f;
        if (arrived)
        {
            // update current index
            ++currentIndex;
            currentIndex %= waypoints.Length;
        }

        agent.position = Vector2.MoveTowards(agent.position, currentWaypoint.position, speed * Time.deltaTime);

        return Status.Running;
    }
}