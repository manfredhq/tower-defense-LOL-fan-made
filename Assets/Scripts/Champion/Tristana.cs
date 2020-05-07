using UnityEngine;

public class Tristana : MonoBehaviour
{
    public Turret turret;
    public float manaMax = 100f;
    public float manaGain = 10f;
    public float currentMana = 0f;
    public float fireRateBonus = .5f;
    public float timeComp = 4f;

    private float timeCompActivated = 0f;
    private float baseFireRate;
    private float effectiveFireRate;
    private bool isCompActivated = false;


    private int numberTimeShooted;

    private void Start()
    {
        baseFireRate = turret.fireRate;
        numberTimeShooted = 0;
        currentMana = 0f;
    }
    private void Update()
    {
        //Reset
        if (isCompActivated)
        {
            currentMana = 0;
        }

        //Mana gain
        if (numberTimeShooted < turret.timeShooted && !isCompActivated)
        {
            currentMana += manaGain * (turret.timeShooted - numberTimeShooted);
            numberTimeShooted = turret.timeShooted;
        }

        //Activate the spell
        if (currentMana >= manaMax && !isCompActivated && Time.time > timeComp + timeCompActivated)
        {
            effectiveFireRate = baseFireRate + fireRateBonus;
            turret.fireRate = effectiveFireRate;
            timeCompActivated = Time.time;
            isCompActivated = true;
        }

        //When the comp reach the end
        if (Time.time > timeComp + timeCompActivated)
        {
            numberTimeShooted = turret.timeShooted;
            turret.fireRate = baseFireRate;
            isCompActivated = false;
        }
    }
}
