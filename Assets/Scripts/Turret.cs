using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum damageType { Physical, Magical, True };
    [Header("Target system")]
    public damageType typeOfDamage;

    public enum shootMode { Closer, First };
    [Header("Target system")]
    public shootMode actualMode;

    [Header("General")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public BasicAttackScript attackScript;

    [Header("Use bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use laser")]
    public bool isLaser = false;
    public float DOT = 30f;
    public float slowPercent = .5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    //[HideInInspector]
    public Transform target;
    private Ennemy ennemy;

    [HideInInspector]
    public int timeShooted = 0;

    [Header("Reference")]
    public Transform partToRotate;
    public Transform firePoint;


    [Header("tags")]
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
        if (actualMode == shootMode.Closer)
        {

            float shortestDistance = Mathf.Infinity;
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
                ennemy = target.GetComponent<Ennemy>();
            }
            else
            {
                target = null;
                ennemy = null;
            }
        }
        else if (actualMode == shootMode.First)
        {
            if ((WaveSpawner.EnemiesAlives > 0 || EndlessWaveSpawner.EnemiesAlives > 0))
            {
                SetFirstEnemy();
                //target = GameManager.instance.firstEnemy.transform;
                //ennemy = GameManager.instance.firstEnemy.GetComponent<Ennemy>();
            }
            //focus on the ennemy closer to the end
            /*for (int i = 0; i < container.transform.childCount; i++)
            {
                float distanceToEnnemy = Vector3.Distance(transform.position, container.transform.GetChild(i).transform.position);
                if (distanceToEnnemy <= range)
                {
                    target = container.transform.GetChild(i).transform;
                    ennemy = target.GetComponent<Ennemy>();
                    return;
                }
                else if (distanceToEnnemy >= range)
                {
                    target = null;
                    ennemy = null;
                }
            }*/
        }
    }

    public void SetFirstEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnnemyMovement temp;
        if (enemies.Length > 0)
        {
            temp = enemies[0].GetComponent<EnnemyMovement>();
            foreach (GameObject enemy in enemies)
            {

                EnnemyMovement EMovement = enemy.GetComponent<EnnemyMovement>();
                if (!isInRange(temp.gameObject))
                {
                    temp = EMovement;
                }
                if (EMovement.waypointIndex > temp.waypointIndex && isInRange(EMovement.gameObject))
                {
                    temp = EMovement;
                }
                else if (EMovement.waypointIndex == temp.waypointIndex && EMovement.waypointIndex > 0 && isInRange(EMovement.gameObject))
                {
                    Vector3 posWaypoint = Waypoints.points[EMovement.waypointIndex].transform.position;

                    Vector3 posPreviousWaypoint = Waypoints.points[EMovement.waypointIndex - 1].transform.position;
                    Vector3 dirWaypoint = posPreviousWaypoint - posWaypoint;
                    if (dirWaypoint.x > 2 || dirWaypoint.x < -2)
                    {
                        //X
                        if (Mathf.Abs((EMovement.transform.position - EMovement.target.position).x) < Mathf.Abs((temp.transform.position - temp.target.position).x))
                        {
                            temp = EMovement;
                        }
                    }
                    else if (dirWaypoint.z > 2 || dirWaypoint.z < -2)
                    {
                        //Z
                        if (Mathf.Abs((EMovement.transform.position - EMovement.target.position).z) < Mathf.Abs((temp.transform.position - temp.target.position).z))
                        {
                            temp = EMovement;
                        }
                    }
                }
            }
            if (isInRange(temp.gameObject))
                target = temp.gameObject.transform;
            else
            {
                target = null;
            }
        }
        else
        {
            target = null;
        }

    }

    private bool isInRange(GameObject obj)
    {
        GameObject container = GameObject.FindGameObjectWithTag(containerTag);
        float distanceToEnnemy = Vector3.Distance(transform.position, obj.transform.position);
        if (distanceToEnnemy <= range)
        {
            target = obj.transform.transform;
            ennemy = target.GetComponent<Ennemy>();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Laser()
    {
        ennemy.TakeDamage(DOT * Time.deltaTime, typeOfDamage);
        ennemy.Slow(slowPercent);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized * .5f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    private void Update()
    {
        if (target == null)
        {
            if (isLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }


            return;
        }

        LockOnTarget();

        if (isLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            attackScript.PlayAttackAnimation(fireRate);
            bullet.Initiate(target);
            timeShooted++;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
