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

    public void Rotate(Vector3 direction, float speed)
    {
        // _playerController.transform.GetChild(0).Rotate(Vector3.up * direction * Time.deltaTime * speed);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            _playerController.transform.GetChild(0).rotation = Quaternion.RotateTowards(_playerController.transform.GetChild(0).rotation, toRotation, speed * Time.deltaTime);            
        }
    }
}
