﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ennemy))]
public class EnnemyMovement : MonoBehaviour
{

    private Transform target;
    private int waypointIndex = 0;

    private Ennemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Ennemy>();
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }


        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            DamagePlayer();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void DamagePlayer()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }


}