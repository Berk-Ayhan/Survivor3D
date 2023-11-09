using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : SingletonMonoBehaviorObject<ProjectileManager>
{
    [SerializeField] ProjectileController _projectilePrefab;

    Queue<ProjectileController> _projectiles = new Queue<ProjectileController>();

    private void Awake() {
        SingletonThisObject(this);
    }

    private void Start() {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < 5; i++)
        {
            ProjectileController newProjectile = Instantiate(_projectilePrefab);
            newProjectile.gameObject.SetActive(false);
            newProjectile.transform.parent = this.transform;
            _projectiles.Enqueue(newProjectile);
        }
    }

    public void SetPool(ProjectileController projectileController){
        projectileController.gameObject.SetActive(false);
        projectileController.transform.parent = this.transform;
        _projectiles.Enqueue(projectileController);
    }

    public ProjectileController GetPool(){
        if(_projectiles.Count == 0){
            InitializePool();
        }
        return _projectiles.Dequeue();
    }
}
