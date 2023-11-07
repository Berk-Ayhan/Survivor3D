using UnityEngine;

public class PcInput : IPlayerInput
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");

}
