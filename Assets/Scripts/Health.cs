using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;

    public void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " got damage: " + damage +  ". Current health: " + health);
        if(health <= 0) Destroy(gameObject);
    }
}