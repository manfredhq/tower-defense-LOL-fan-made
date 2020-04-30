using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViktorUltimate : MonoBehaviour
{
    public Turret creator;
    public float speed = 30f;
    public int tickDamage = 30;
    public float timeBetweenTick = .5f;

    private float lastTick;
    private GameObject selfTarget;

    private List<GameObject> enemyInRange = new List<GameObject>();
    private void Start()
    {
        selfTarget = creator.target.gameObject;
        enemyInRange.Add(selfTarget);
        lastTick = 0f;
    }
    private void Update()
    {
        for (int i = 0; i < enemyInRange.Count; i++)
        {
            if (enemyInRange[i] == null)
            {
                enemyInRange.RemoveAt(i);
            }
        }

        if (selfTarget == null || selfTarget == creator.gameObject)
        {
            enemyInRange.Remove(selfTarget);
            if (creator.target != null)
            {
                selfTarget = creator.target.gameObject;
            }
            else
            {
                selfTarget = creator.gameObject;
            }
        }
        //Debug.Log(selfTarget);

        Vector3 dir = selfTarget.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (Time.time > lastTick + timeBetweenTick)
        {
            //apply damage
            foreach (GameObject enemy in enemyInRange)
            {
                enemy.GetComponent<Ennemy>().TakeDamage(tickDamage);
            }

            lastTick = Time.time;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ennemy>())
        {
            enemyInRange.Add(other.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ennemy>())
        {
            enemyInRange.Remove(other.gameObject);
        }

    }
}
