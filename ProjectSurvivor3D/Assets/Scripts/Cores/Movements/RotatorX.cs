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

    public void Rotate(Vector3 direction, float speed)
    {
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            _controller.transform.GetChild(0).rotation = Quaternion.RotateTowards(_controller.transform.GetChild(0).rotation, toRotation, speed * Time.deltaTime);            
        }
    }
}
