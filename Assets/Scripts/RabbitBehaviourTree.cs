using BehaviourTrees;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RabbitBehaviourTree : BehaviourTree
{
    [SerializeField] private Transform[] waypoints = null;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Transform home = null;
    public GameObject carrot;
    public Text amoutText;
    protected override void OnSetup()
    {
        Blackboard.Add("speed", speed);
        var patrolTask = new PatrolTask(waypoints);
        var seeCarrotTask = new SeeCarrotTask();
        var catchCarrotTask = new CatchCarrotTask();
        var backHomeTask = new BackHomeTask(home, amoutText);
        Node[] sequencerChildren = { seeCarrotTask, catchCarrotTask, backHomeTask };
        var sequencer = new Sequencer(sequencerChildren.ToList());

        Node[] selectorChildren = { sequencer, patrolTask };
        var selector = new Selector(selectorChildren.ToList());

        Root = selector;
    }

    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            Vector3 worldPos = cam.ScreenPointToRay(Input.mousePosition).origin;
            GameObject gb =  Instantiate(carrot);
            gb.transform.position = new Vector3(worldPos.x,worldPos.y,0);
        }

        base.Update();

    }
}