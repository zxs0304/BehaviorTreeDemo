using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourTrees
{
    public class Selector : Composite
    {
        public Selector(List<Node> children)
        {
            this.children = children;
        }

        //Selector节点是当第一个子节点不为failure的话，第二个子节点就不会执行，只有第一个子节点为failure，才会执行第二个。
        protected override Status OnEvaluate(Transform agent, Blackboard blackboard)
        {
            bool isRunning = false;
            bool failed = children.All((child) =>
            {
                Status status = child.Evaluate(agent, blackboard);
                if (status == Status.Running) isRunning = true;
                return status == Status.Failure;
            });

            return isRunning ? Status.Running : failed ? Status.Failure : Status.Success;
        }
    }
}