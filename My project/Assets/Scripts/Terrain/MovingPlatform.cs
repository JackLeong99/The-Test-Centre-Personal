using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WayPointHandler _waypointPath;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private bool smoothing = true;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    void Start()
    {
        TargetNextWaypoint();
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        switch (smoothing) 
        {
            case true:
                elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
                break;
        }
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true || other.CompareTag("movable") == true)
            other.transform.SetParent(this.gameObject.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true || other.CompareTag("movable") == true)
            other.transform.SetParent(null);
    }
}