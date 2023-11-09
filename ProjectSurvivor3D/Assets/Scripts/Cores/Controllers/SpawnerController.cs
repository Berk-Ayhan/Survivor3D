using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour, IEntityController
{
    [SerializeField] GameObject projectileParent;
    [SerializeField] float _searchRadius = 10f;
    
    float _maxSpawnTime = 1;
    float _currentSpawnTime = 0f;

    IClosestEnemy _closestEnemy;

    private void Awake() {
        _closestEnemy = new ClosestEnemy(this, _searchRadius);
    }

    void Update()
    {
        _currentSpawnTime += Time.deltaTime;

        // if (_currentSpawnTime > _maxSpawnTime) Spawn();
    }

    void Spawn()
    {
        ProjectileController newProjectile = ProjectileManager.Instance.GetPool();
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = this.transform.position;
        newProjectile.gameObject.SetActive(true);

        _currentSpawnTime = 0f;
    }
}
