using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    private Transform playerTransform;

    [Header("Cover points")]
    [SerializeField] private GameObject coverPointPrefab;
    [SerializeField] private List<CoverPoint> coverPoints = new List<CoverPoint>();
    [SerializeField] private float xOffset = 1;
    [SerializeField] private float yOffset = .2f;
    [SerializeField] private float zOffset = 1;

    private void Start()
    {
        GenerateCoverPoints();
        playerTransform = FindObjectOfType<Player>().transform;
    }

    private void GenerateCoverPoints()
    {
        Vector3[] localCoverPoints =
        {
            new Vector3(0, yOffset, zOffset),  //front
            new Vector3(0, yOffset, -zOffset), //Back
            new Vector3(xOffset, yOffset, 0),  //Right
            new Vector3(-xOffset, yOffset, 0)  //Left
        };

        foreach (Vector3 localPoint in localCoverPoints)
        {
            Vector3 worldPoint = transform.TransformPoint(localPoint);
            CoverPoint coverPoint = Instantiate(coverPointPrefab, worldPoint, Quaternion.identity, transform).GetComponent<CoverPoint>();
            coverPoints.Add(coverPoint);    
        }
    }

    public List<CoverPoint> GetValidCoverPoints(Transform enemy)
    {
        List<CoverPoint> validCoverPoints = new List<CoverPoint>();

        foreach (CoverPoint coverPoint in coverPoints)
        {
            if(IsValidCoverPoint(coverPoint, enemy))
                validCoverPoints.Add(coverPoint);
        }

        return validCoverPoints;
    }

    private bool IsValidCoverPoint(CoverPoint coverPoint, Transform enemy)
    {
        if(coverPoint.occupied)
            return false;

        if(IsFurthestFromPlayer(coverPoint) == false)
            return false;

        if(IsCoverCloseToPlayer(coverPoint))
            return false;

        if (IsCoverBehindPlayer(coverPoint, enemy))
            return false;

        if (IsCoverCloseToLastOne(coverPoint, enemy))
            return false;

        return true;
    }

    private bool IsFurthestFromPlayer(CoverPoint coverPoint)
    {
        CoverPoint futhestPoint = null;
        float furthestDistance = 0;

        foreach(CoverPoint point in coverPoints)
        {
            float distance = Vector3.Distance(point.transform.position, playerTransform.position);
            if(distance > furthestDistance)
            {
                furthestDistance = distance;
                futhestPoint = point;
            }
        }

        return futhestPoint == coverPoint;
    }

    private bool IsCoverBehindPlayer(CoverPoint coverPoint, Transform enemyTransform)
    {
        float distanceToPlayer = Vector3.Distance(coverPoint.transform.position, playerTransform.position);
        float distanceToEnemy = Vector3.Distance(coverPoint.transform.position, enemyTransform.position);

        return distanceToPlayer < distanceToEnemy;
    }

    private bool IsCoverCloseToPlayer(CoverPoint coverPoint)
    {
        return Vector3.Distance(coverPoint.transform.position, playerTransform.transform.position) < 2;
    }

    private bool IsCoverCloseToLastOne(CoverPoint coverPoint, Transform enemy)
    {
        CoverPoint lastCover = enemy.GetComponent<Enemy_Range>().lastCover;
        return lastCover != null && 
            Vector3.Distance(coverPoint.transform.position, lastCover.transform.position) < 3;
    }
}
