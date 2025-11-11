using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyDetector : MonoBehaviour
{
    [SerializeField] private float dectctionRadius = 10f;
    [SerializeField] private LayerMask enemyLayer;

    public GameObject GetClosestEnemy()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, dectctionRadius, enemyLayer);       //구체로 적이 있는지 검사
        
        if (enemiesInRange.Length > 0)     //범위 안에 들어온 적이 있는지 검사 (0 이상이면 적이 범위 내에 들어옴)
        {
            GameObject bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;      //최대 숫자로 시작해서 가까운 거리로 계속 전환 된다.
            Vector3 currentPosition = transform.position;   

            foreach(Collider enemyCollider in enemiesInRange)
            {
                //자기 자신은 제외
                if (enemyCollider.gameObject == this.gameObject)
                    continue;

                Vector3 directionToTarget = enemyCollider.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;   

                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = enemyCollider.gameObject;
                }
            }
            return bestTarget;

        }
        else
        {
            return null;

        }
    }

    public List<GameObject> GetEnemiesInRange()
    {
        List<GameObject> enemiesList = new List<GameObject>();
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, dectctionRadius, enemyLayer);       //구체로 적이 있는지 검사   

        foreach (Collider enemyCollider in enemiesInRange)
        {
            
            if (enemyCollider.gameObject == this.gameObject)
            {
                enemiesList.Add(enemyCollider.gameObject);
            }
        }
        return enemiesList;
    }    


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dectctionRadius);
    }
}
