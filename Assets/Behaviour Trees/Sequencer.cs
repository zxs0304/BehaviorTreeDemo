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
        //Selector�ڵ��ǵ���һ���ӽڵ㲻Ϊsuccess�Ļ����ڶ����ӽڵ�Ͳ���ִ�У�ֻ�е�һ���ӽڵ�Ϊseccess���Ż�ִ�еڶ�����
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