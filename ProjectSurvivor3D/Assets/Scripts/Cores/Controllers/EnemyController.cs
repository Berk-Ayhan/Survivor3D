using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IEntityController
{
    IChaser _chaser;
    NavMeshAgent _navMeshAgent;
    IEntityController _player;
    private void Awake() {
        _player = FindObjectOfType<PlayerController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
         _chaser = new PlayerChaser(_player, _navMeshAgent);
    }
    
    private void FixedUpdate() {
        _chaser.Chase();
    }
}
