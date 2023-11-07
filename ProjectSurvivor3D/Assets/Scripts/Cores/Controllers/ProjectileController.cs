using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // public Transform target;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 0.3f;
    IChaser _chaser;
    IEntityController _enemy;
    private void Awake() {
    _enemy = FindObjectOfType<EnemyController>();
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
