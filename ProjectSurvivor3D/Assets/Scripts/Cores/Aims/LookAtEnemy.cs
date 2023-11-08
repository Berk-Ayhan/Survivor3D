using UnityEngine;

public class LookAtEnemy : ILookAtEnemy
{
    Quaternion enemyRotation;
    float _rotationSpeed;
    IEntityController _controller;
    public LookAtEnemy(IEntityController controller, float rotationSpeed)
    {
        _controller = controller;
        _rotationSpeed = rotationSpeed;
    }
    public void Look(EnemyController enemy)
    {
        if(enemy == null) return;

        Vector3 direction = enemy.transform.position - _controller.transform.GetChild(0).position;
        enemyRotation = Quaternion.LookRotation(direction);
        Quaternion lookAt = Quaternion.RotateTowards(_controller.transform.GetChild(0).rotation, enemyRotation, Time.deltaTime * _rotationSpeed);
        _controller.transform.GetChild(0).rotation = lookAt;
    }
}
