using UnityEngine;

public class Mover : IMover
{
    // Rigidbody _rigidbody;
    float _moveSpeed;
    // PlayerController _playerController;
    IEntityController _controller;

    public Mover(IEntityController controller, float moveSpeed)
    {
        // _rigidbody = playerController.GetComponent<Rigidbody>();
        _controller = controller;
        _moveSpeed = moveSpeed;
    }
    public void Move(float horizontal, float vertical)
    {
        if (horizontal == 0f && vertical == 0f) return;
        Vector3 movement = new Vector3 (horizontal, 0 ,vertical);
        // _rigidbody.velocity = movement * Time.fixedDeltaTime * _moveSpeed;
        _controller.transform.Translate(movement * Time.fixedDeltaTime * _moveSpeed);
    }
}
