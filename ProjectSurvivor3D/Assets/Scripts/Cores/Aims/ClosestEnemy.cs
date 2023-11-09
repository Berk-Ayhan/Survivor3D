using UnityEngine;

public class ClosestEnemy : IClosestEnemy
{
    public static event System.Action<IEntityController> OnFindClosestEnemy;
    float _searchRadius;
    IEntityController _controller;

    public ClosestEnemy(IEntityController controller, float searchRadius)
    {
        _controller = controller;
        _searchRadius = searchRadius;
    }

    public void Find()
    {
        float _distanceToClosestEnemy = Mathf.Infinity;
		EnemyController _closestEnemy = null;
		EnemyController[] _allEnemies = GameObject.FindObjectsOfType<EnemyController>();

		foreach (EnemyController _currentEnemy in _allEnemies) {
			float _distanceToEnemy = (_currentEnemy.transform.position - _controller.transform.position).sqrMagnitude;

			if(_distanceToEnemy > Mathf.Pow(_searchRadius, 2) || _distanceToEnemy > _distanceToClosestEnemy) continue;

            _distanceToClosestEnemy = _distanceToEnemy;
			_closestEnemy = _currentEnemy;
		}
        if (_closestEnemy != null)  Debug.DrawLine (_controller.transform.position, _closestEnemy.transform.position);
        OnFindClosestEnemy?.Invoke(_closestEnemy);
    }
}
