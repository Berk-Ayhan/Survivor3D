using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [Header("Movement Informations")]
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _rotationSpeed = 3f;
    // [SerializeField] float _searchRadius = 3f;

    IInputReader _input;
    IMover _mover;
    IRotator _xRotator;
    // IClosestEnemy _closestEnemy;
    // ILookAtEnemy _lookAtEnemy;

    Vector3 _direction;

    float _horizontal;
    float _vertical;

    private void Awake() {
        _input = GetComponent<IInputReader>();
        _mover = new Mover(this);
        _xRotator = new RotatorX(this);
        // _closestEnemy = new ClosestEnemy(this, _searchRadius);
        // _lookAtEnemy = new LookAtEnemy(this, _rotationSpeed);
    }

    private void Update() {
        _direction = _input.Direction;
        _xRotator.Rotate(_input.Rotation.x, _rotationSpeed);
        // _lookAtEnemy.Look(_closestEnemy.Find());
    }

    private void FixedUpdate() {
        _mover.Move(_direction, _moveSpeed);
    }
}
