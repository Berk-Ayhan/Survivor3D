using UnityEngine;
using UnityEngine.AI;

public class PlayerChaser : IChaser
{
    NavMeshAgent _navMeshAgent;
    IEntityController _controller;

    public PlayerChaser(IEntityController controller, NavMeshAgent navMeshAgent)
    {
         _controller = controller;
         _navMeshAgent = navMeshAgent;
    }

    public void Chase(){
        _navMeshAgent.SetDestination(_controller.transform.position);
    }
}
