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
        // if(enemy == null) {
        //    enemyRotation = Quaternion.Euler(0,0,0);
        //    _controller.transform.GetChild(0).transform.rotation = Quaternion.RotateTowards(_controller.transform.GetChild(0).transform.rotation, enemyRotation, Time.deltaTime * _rotationSpeed);
        //    return;
        // };
        if(enemy == null) return;

        Vector3 direction = enemy.transform.position - _controller.transform.GetChild(0).transform.position;
        enemyRotation = Quaternion.LookRotation(direction);
        Quaternion lookAt = Quaternion.RotateTowards(_controller.transform.GetChild(0).transform.rotation, enemyRotation, Time.deltaTime * _rotationSpeed);
        _controller.transform.GetChild(0).transform.rotation = lookAt;
    }
}
