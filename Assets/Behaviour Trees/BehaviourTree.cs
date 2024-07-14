using JetBrains.Annotations;
using UnityEngine;

namespace BehaviourTrees
{
    [RequireComponent(typeof(Blackboard))]
    public class BehaviourTree : MonoBehaviour
    {
        private Node root;

        public Node Root
        {
            get => root;
            protected set => root = value;
        }

        private Blackboard blackboard;

        [UsedImplicitly]
        private void Awake()
        {
            blackboard = GetComponent<Blackboard>();
            OnSetup();
        }

        public Blackboard Blackboard
        {
            get => blackboard;
            set => blackboard = value;
        }


        protected virtual void Update()
        {
            root?.Evaluate(gameObject.transform, blackboard);
        }

        protected virtual void OnSetup()
        {
        }
    }
}