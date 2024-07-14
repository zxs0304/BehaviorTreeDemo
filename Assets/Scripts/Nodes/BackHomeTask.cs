
using UnityEngine;
using UnityEngine.UI;

namespace BehaviourTrees
{
    public class BackHomeTask : Task
    {
        public Transform home;
        public int carrotAmount = 0;
        public Text amountText;

        public BackHomeTask(Transform home  , Text text)
        {
            this.home = home;
            this.amountText = text;
        }
        protected override Status OnEvaluate(Transform agent, Blackboard blackboard)
        {
            var haveCarrot = blackboard.Get<bool>("HaveCarrot");
            if (!haveCarrot) return Status.Failure;

            if (Vector2.Distance(agent.position, home.position) <= 0.25f)
            {
                blackboard.Remove("SeeCarrot");
                blackboard.Remove("HaveCarrot");
                carrotAmount++;
                amountText.text = $": {carrotAmount}";
                return Status.Success;
            }

            

            var speed = blackboard.Get<float>("speed");
            Vector2 position = Vector2.MoveTowards(agent.position, home.position, speed * Time.deltaTime);
            position.y = agent.position.y;
            agent.position = position;
            return Status.Running;
        }

    }
}
