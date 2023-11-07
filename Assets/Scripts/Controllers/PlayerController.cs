using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float searchRadius = 3f;
    [SerializeField] float rotationSpeed = 3f;

    IPlayerInput _input;
    IMover _mover;
    IClosestEnemy _closestEnemy;
    ILookAtEnemy _lookAtEnemy;

    float _horizontal;
    float _vertical;

    private void Awake() {
        _input = new PcInput();
        _mover = new Mover(this, moveSpeed);
        _closestEnemy = new ClosestEnemy(this, searchRadius);
        _lookAtEnemy = new LookAtEnemy(this, rotationSpeed);
    }

    private void Update() {
        _horizontal = _input.Horizontal;
        _vertical = _input.Vertical;
        _closestEnemy.Find();
        _lookAtEnemy.Look(_closestEnemy.Find());
    }

    private void FixedUpdate() {
        _mover.Move(_horizontal, _vertical);
    }
}
