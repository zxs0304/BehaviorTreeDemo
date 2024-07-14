using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourTrees
{
    public class Sequencer : Composite
    {
        public Sequencer(List<Node> children)
        {
            this.children = children;
        }
        //Selector节点是当第一个子节点不为success的话，第二个子节点就不会执行，只有第一个子节点为seccess，才会执行第二个。
        protected override Status OnEvaluate(Transform agent, Blackboard blackboard)
        {
            bool isRunning = false;
            bool success = children.All((child) =>
            {
                Status status = child.Evaluate(agent, blackboard);
                switch (status)
                {
                    case Status.Failure:
                        return false;
                    case Status.Running:
                        isRunning = true;
                        break;
                }

                return status == Status.Success;
            });

            return isRunning ? Status.Running : success ? Status.Success : Status.Failure;
        }
    }
}