using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour, IEntityController
{
    // public Transform target;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 0.3f;
    [SerializeField] float _searchRadius = 3f;
    IChaser _chaser;
    IClosestEnemy _closestEnemy;
    IEntityController _enemy;
    private void Awake() {
        _closestEnemy = new ClosestEnemy(this, _searchRadius);
        _enemy = _closestEnemy.Find();
    }

    private void Start() {
        _chaser = new EnemyChaser(this, _enemy, transform, speed, rotateSpeed);
    }
    
    private void FixedUpdate() {
        _chaser.Chase();
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
