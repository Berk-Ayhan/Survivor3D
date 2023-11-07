using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float searchRadius = 3f;
    [SerializeField] float rotationSpeed = 3f;

    IInputReader _input;
    IMover _mover;
    IClosestEnemy _closestEnemy;
    ILookAtEnemy _lookAtEnemy;

    Vector3 _direction;

    float _horizontal;
    float _vertical;

    private void Awake() {
        _input = GetComponent<IInputReader>();
        _mover = new Mover(this);
        _closestEnemy = new ClosestEnemy(this, searchRadius);
        _lookAtEnemy = new LookAtEnemy(this, rotationSpeed);
    }

    private void Update() {
        _direction = _input.Direction;
        // _lookAtEnemy.Look(_closestEnemy.Find());
    }

    private void FixedUpdate() {
        _mover.Move(_direction, moveSpeed);
    }
}
