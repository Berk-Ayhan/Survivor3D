using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyChaser : IChaser
{
    IEntityController _controller;
    Transform _transform;
    Rigidbody _rigidbody;
    float _speed;
	float _rotateSpeed = 200f;

    public EnemyChaser(ProjectileController projectileController, IEntityController controller, Transform transform, float speed, float rotateSpeed)
    {
        _rigidbody = projectileController.GetComponent<Rigidbody>();
        _controller = controller;
        _transform = transform;
        _speed = speed;
        _rotateSpeed = rotateSpeed;
    }
    public void Chase()
    {
        Vector3 direction = _controller.transform.position - _rigidbody.position;
        direction.Normalize();
        Vector3 amountToRotate = Vector3.Cross(direction, _transform.forward) * Vector3.Angle(_transform.forward, direction);
        _rigidbody.angularVelocity = -amountToRotate * _rotateSpeed;
        _rigidbody.velocity = _transform.forward * _speed;
    }
}
