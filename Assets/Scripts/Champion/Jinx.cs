using UnityEngine;

public class Jinx : MonoBehaviour
{
    public Turret turret;
    public float fireRateAugmentRate;
    public int maxStack;

    private float baseFireRate;
    private float effectiveFireRate;

    private void Start()
    {
        baseFireRate = turret.fireRate;
    }
    private void Update()
    {
        if (turret.timeShooted > maxStack)
        {
            effectiveFireRate = baseFireRate + fireRateAugmentRate * maxStack;
        }
        else
        {
            effectiveFireRate = baseFireRate + fireRateAugmentRate * turret.timeShooted;
        }
        turret.fireRate = effectiveFireRate;
    }

}
