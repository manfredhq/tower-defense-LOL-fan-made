using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public float startSpeed = 10f;
    public float hp = 100;
    public int moneyValue = 15;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }
    private void Die()
    {
        PlayerStats.money += moneyValue;


        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}
