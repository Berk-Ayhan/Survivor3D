using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [Header("Movement Informations")]
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _rotationSpeed = 3f;
    [SerializeField] float _searchRadius = 3f;

    bool _canRotate;

    IInputReader _input;
    IMover _mover;
    IRotator _xRotator;
    IClosestEnemy _closestEnemy;
    ILookAtEnemy _lookAtEnemy;

    private void Awake() {
        _input = GetComponent<IInputReader>();
        _mover = new Mover(this);
        _xRotator = new RotatorX(this);
        _closestEnemy = new ClosestEnemy(this, _searchRadius);
        _lookAtEnemy = new LookAtEnemy(this, _rotationSpeed);
    }

    private void Update() {
        _mover.Move(_input.Direction, _moveSpeed);
        _closestEnemy.Find();
        if(_canRotate) _xRotator.Rotate(_input.Direction, _rotationSpeed);
    }

    private void OnEnable() {
        ClosestEnemy.OnFindClosestEnemy += HandleOnFindClosestEnemy;
    }

    private void OnDisable() {
        ClosestEnemy.OnFindClosestEnemy -= HandleOnFindClosestEnemy;
    }

    private void HandleOnFindClosestEnemy(IEntityController controller)
    {
        _lookAtEnemy.Look(controller);
        _canRotate = controller == null ? true : false;
    }

    private void OnDrawGizmos() {
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}
