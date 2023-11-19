using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float minDistanceToDealDamage = 2f;

    private int damage = 40;

    private bool hit;

    private Monster _enemyTarget;

    private void Start()
    {
        hit = false;
    }
    protected virtual void Update()
    {
        if (_enemyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
        else
        {
            // If the enemy target is null, return the projectile to the object pool
            ObjectPooler.ReturnToPool(gameObject);
        }
        if (hit)
        {
            hit = false;
            // Deal damage to the enemy
            _enemyTarget.DealDamage(damage);

            // Return the projectile to the object pool
            ObjectPooler.ReturnToPool(gameObject);
        }
    }

    protected virtual void MoveProjectile()
    {
        // Move the projectile towards the enemy
        transform.position = Vector2.MoveTowards(transform.position, _enemyTarget.transform.position, moveSpeed * Time.deltaTime);

        // Check the distance to the target
        float distanceToTarget = (_enemyTarget.transform.position - transform.position).magnitude;


    }

    protected virtual void RotateProjectile()
    {
        // Rotate the projectile to face the enemy
        Vector3 enemyPos = _enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f, 0f, angle);
    }

    public void SetEnemy(Monster enemy)
    {
        _enemyTarget = enemy;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hit = true;
        }
    }
}
