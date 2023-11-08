using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorX : IRotator
{
    IEntityController _controller;
    public RotatorX(IEntityController controller)
    {
       _controller = controller;
    }

    public void Rotate(Vector3 direction, float speed, bool canRotate)
    {
        // Debug.Log("Can rotate:  " +canRotate);
        // _playerController.transform.GetChild(0).Rotate(Vector3.up * direction * Time.deltaTime * speed);
        if (direction != Vector3.zero && canRotate)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            _controller.transform.GetChild(0).rotation = Quaternion.RotateTowards(_controller.transform.GetChild(0).rotation, toRotation, speed * Time.deltaTime);            
        }
    }
}
