using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public Image hpBar;

    public float startSpeed = 10f;

    public float startHp = 100;
    public float currentHp;
    public int moneyValue = 15;
    public float armor;
    public float magicResistance;

    public GameObject deathEffect;
    public GameObject hpBarCanvas;

    [HideInInspector]
    public GameObject hpBarGO;
    private bool isAlive = true;

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
        isAlive = false;
        PlayerStats.money += moneyValue;
        Destroy(hpBarGO);

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlives--;
        EndlessWaveSpawner.EnemiesAlives--;
        Destroy(gameObject);
    }

    public void TakeDamage(float amount, Turret.damageType type)
    {
        //physical
        if (type == Turret.damageType.Physical)
        {
            currentHp -= amount - (amount * (armor / 100));
        }
        //magic
        else if (type == Turret.damageType.Magical)
        {
            currentHp -= amount - (amount * (magicResistance / 100));
        }
        //true damage
        else
        {
            currentHp -= amount;
        }


        hpBar.fillAmount = currentHp / startHp;
        if (currentHp <= 0 && isAlive)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}
