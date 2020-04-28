using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public Image hpBar;

    public float startSpeed = 10f;

    public float startHp = 100;
    public float currentHp;
    public int moneyValue = 15;
    public GameObject deathEffect;
    public GameObject hpBarCanvas;

    private GameObject hpBarGO;

    private void Start()
    {
        speed = startSpeed;
        currentHp = startHp;
        hpBarGO = Instantiate(hpBarCanvas);
        var temp = hpBarGO.GetComponentsInChildren<Transform>()[2];
        hpBar = temp.GetComponent<Image>();
    }

    private void Update()
    {
        hpBarGO.transform.position = transform.position + new Vector3(0, 3, 0);
    }
    private void Die()
    {
        PlayerStats.money += moneyValue;
        Destroy(hpBarGO);

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;

        hpBar.fillAmount = currentHp / startHp;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}
