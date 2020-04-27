using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject currentTurret;

    private Renderer rend;
    private Color baseColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (currentTurret != null)
        {
            //TODO: upgrade systeme aswell as a selling one
            Debug.Log("there is already something here");
            return;
        }

        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        currentTurret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = baseColor;
    }
}
