using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viktor : MonoBehaviour
{
    public Turret turret;
    public float manaMax = 50f;
    public float manaGain = 10f;
    public float currentMana = 0f;
    public float fireRateBonus = .5f;
    public float timeComp = 4f;
    public GameObject ultimatePrefab;

    private float timeCompActivated = 0f;
    private bool isCompActivated = false;
    private ViktorUltimate ultimateRef;


    private int numberTimeShooted;

    private void Start()
    {
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
            GameObject ultimate = Instantiate(ultimatePrefab, turret.target.position, Quaternion.identity);
            ultimateRef = ultimate.GetComponent<ViktorUltimate>();
            ultimateRef.creator = turret;

            //need anyway
            timeCompActivated = Time.time;
            isCompActivated = true;
        }

        //When the comp reach the end
        if (Time.time > timeComp + timeCompActivated && isCompActivated)
        {
            Destroy(ultimateRef.gameObject);
            isCompActivated = false;
        }
    }
}
