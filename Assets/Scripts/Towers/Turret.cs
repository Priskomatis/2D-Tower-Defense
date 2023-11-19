using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<Monster> _enemies = new List<Monster>();     //List of all enemies within range;

    private Monster CurrentEnemyTarget;
    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private float attackInterval = 1f;
    [SerializeField] private GameObject projectilePrefab;

    private void Start()
    {
        StartCoroutine(AttackCoroutine());
    }
    private void Update()
    {
        GetCurrentEnemyTarget();
        RotateTowardsTarget();
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (CurrentEnemyTarget != null)
            {
                Attack();
            }
            yield return new WaitForSeconds(attackInterval); // Moved inside the loop
        }
    }

    private void Attack()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, projectileSpawnPosition.position, Quaternion.identity);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetEnemy(CurrentEnemyTarget);
        }
    }
    private void GetCurrentEnemyTarget()
    {
        if(_enemies.Count <=0)
        {
            CurrentEnemyTarget = null;
            return;
        }
        CurrentEnemyTarget = _enemies[0];
    }
    private void RotateTowardsTarget()
    {
        if (CurrentEnemyTarget == null)
            return;

        Vector3 targetDirection = CurrentEnemyTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        // Adjust the angle by 90 degrees to make the sprite face left
        angle -= 90f;

        // Set the rotation
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Monster newEnemy = other.GetComponent<Monster>();
            _enemies.Add(newEnemy);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Monster enemy = other.GetComponent<Monster>();
            if (_enemies.Contains(enemy))
                _enemies.Remove(enemy);
        }
    }

}
