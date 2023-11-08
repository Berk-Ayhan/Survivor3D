using UnityEngine;

public class ClosestEnemy : IClosestEnemy
{
    float _searchRadius = 10f;

    EnemyController closestEnemy;
    IEntityController _controller;

    public ClosestEnemy(IEntityController controller, float searchRadius)
    {
        _controller = controller;
        _searchRadius = searchRadius;
    }

    public EnemyController Find()
    {
        int maxColliders = 5;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(_controller.transform.position, _searchRadius, hitColliders);
        float closestDistance = Mathf.Infinity;
        
        for (int i = 0; i < numColliders; i++)
        {
            EnemyController enemy;
            hitColliders[i].TryGetComponent(out enemy);

            if(enemy == null) {closestEnemy = null; continue;};
            
            float distance = Vector3.Distance(_controller.transform.position, hitColliders[i].transform.position);

            if(distance > closestDistance) continue;

            closestEnemy = enemy;
            closestDistance = distance;
            // Debug.Log("Closest Enemy Is " + closestEnemy);
        }
        return closestEnemy;
    }

    private void OnDrawGizmos() {
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_controller.transform.position, _searchRadius);
    }


}
