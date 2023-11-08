using UnityEngine;

public interface IRotator
{
    void Rotate(Vector3 direction, float speed, bool canRotate);
}