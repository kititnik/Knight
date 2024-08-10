using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;

    public void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " got damage: " + damage +  ". Current health: " + health);
        if(health <= 0) Death();
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}