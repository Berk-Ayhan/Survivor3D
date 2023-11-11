using UnityEngine;

public class ProjectileController : MonoBehaviour, IEntityController
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 0.3f;
    IChaser _chaser;
    bool isLocked;

    private void Update() {
        _chaser.Chase();
    }

    private void HandleOnFindClosestEnemy(IEntityController controller)
    {
        if(isLocked) return;
        _chaser = new EnemyChaser(this, controller, transform, speed, rotateSpeed);
        isLocked = true;
    }

    private void OnEnable() {
        ClosestEnemy.OnFindClosestEnemy += HandleOnFindClosestEnemy;
    }

    private void OnDisable() {
        ClosestEnemy.OnFindClosestEnemy -= HandleOnFindClosestEnemy;
    }

    private void OnTriggerEnter() {
        isLocked = false;
        ProjectileManager.Instance.SetPool(this);
    }
}
