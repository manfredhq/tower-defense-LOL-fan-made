using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 15f;
    private Transform target;
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public string ennemyTag = "Enemy";
    public string containerTag = "EnnemyContainer";

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(ennemyTag);
        GameObject container = GameObject.FindGameObjectWithTag(containerTag);

        //To focus on the nearest ennemy
        /*float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject ennemy in ennemies)
        {
            float distanceToEnnemy = Vector3.Distance(transform.position, ennemy.transform.position);
            if (shortestDistance > distanceToEnnemy)
            {
                shortestDistance = distanceToEnnemy;
                nearestEnemy = ennemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }*/

        //focus on the ennemy closer to the end
        for (int i = 0; i < container.transform.childCount; i++)
        {
            float distanceToEnnemy = Vector3.Distance(transform.position, container.transform.GetChild(i).transform.position);
            if (distanceToEnnemy <= range)
            {
                target = container.transform.GetChild(i).transform;
                return;
            }
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
