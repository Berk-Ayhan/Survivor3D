using UnityEngine;

public class Mover : IMover
{

    CharacterController _characterController;

    public Mover(PlayerController playerController)
    {
        _characterController  = playerController.GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction, float moveSpeed)
    {
        if (direction.magnitude == 0f) return;
                    
        Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
        Vector3 movement = worldPosition * (Time.deltaTime * moveSpeed);

        _characterController.Move(movement);
    }
}
