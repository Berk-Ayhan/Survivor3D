using UnityEngine;

public class SpawnerController : MonoBehaviour, IEntityController
{
    [SerializeField] GameObject projectileParent;
    
    float _maxSpawnTime = 1;
    float _currentSpawnTime = 0f;

    void Update()
    {
        _currentSpawnTime += Time.deltaTime;

        if (_currentSpawnTime > _maxSpawnTime) Spawn();
    }

    void Spawn()
    {
        ProjectileController newProjectile = ProjectileManager.Instance.GetPool();
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = transform.position;
        newProjectile.gameObject.SetActive(true);

        _currentSpawnTime = 0f;
    }
}
