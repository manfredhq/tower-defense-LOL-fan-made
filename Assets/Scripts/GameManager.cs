using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public GameObject firstEnemy;

    public DialogManager dialogManager;

    public static GameManager instance;

    //to handle the singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("too many Build manager");
            return;
        }
        instance = this;

    }
    private void Start()
    {
        isGameEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameEnded == true)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
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
                if (EMovement.waypointIndex > temp.waypointIndex)
                {
                    temp = EMovement;
                }
                else if (EMovement.waypointIndex == temp.waypointIndex && EMovement.waypointIndex > 0)
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
            firstEnemy = temp.gameObject;
        }
        else
        {
            firstEnemy = null;
        }

    }

    private void EndGame()
    {
        isGameEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        isGameEnded = true;
        completeLevelUI.SetActive(true);
    }

    public bool GetGameStatus()
    {
        return isGameEnded;
    }
}
