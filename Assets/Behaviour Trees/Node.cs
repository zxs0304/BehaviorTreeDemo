using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public enum Status
    {
        Failure = 0,
        Success,
        Running
    }

    public abstract class Node
    {
        protected Node parent;
        protected List<Node> children = new();
        
        private Status status;

        public Status Status
        {
            get => status;
            protected set => status = value;
        }

        public Status Evaluate(Transform agent, Blackboard blackboard)
        {
            //Debug.Log($"{GetType().Name} - Entered...");
            status = OnEvaluate(agent, blackboard);
            Debug.Log($"{GetType().Name} - {status}");
            //Debug.Log($"{GetType().Name} - Exited...");

            return status;
        }

        protected abstract Status OnEvaluate(Transform agent, Blackboard blackboard);
    }

    class Animal
    {
        public void Buy()
        {
            Console.WriteLine($"Good afternoon, {OnPrintName()}");
        }

        protected virtual string OnPrintName()
        {
            return "Animal";
        }
    }

    class Cat : Animal
    {
        protected override string OnPrintName()
        {
            return "Cat";
        }
    }

    class Dog : Animal
    {
        protected override string OnPrintName()
        {
            return "Dog";
        }
    }
}