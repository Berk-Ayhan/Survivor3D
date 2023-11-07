using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorX : IRotator
{
    PlayerController _playerController;
    public RotatorX(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void Rotate(float direction, float speed)
    {
        _playerController.transform.Rotate(Vector3.up * direction * Time.deltaTime * speed);
    }
}
