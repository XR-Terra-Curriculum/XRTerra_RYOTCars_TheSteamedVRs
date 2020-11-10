using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    [Tooltip("Move speed when the object seeks target.")]
    public float physicMoveSpeed;
    [Tooltip("Transform of current seek target")]
    public Transform target;
    [Tooltip("Lower number results in earlier size change during travel, 0 would be instant change")]
    public float scaleFactor;
    [Tooltip("Speed at which target rotation is matched")]
    public float turnSpeed;
    [Tooltip("The return point for the object when SendHome is called")]
    public Transform home;
    [Tooltip("The return point for the object when SendDisplay is called")]
    public Transform display;


    private Vector3 _heading;//direction towards target
    private Vector3 _originalScale;//storing old scale to have a starting point for next transition
    private float _newScaleX;//x for new scale
    private float _newScaleY;//y for new scale
    private float _newScaleZ;//z for new scale
    private float _currDist;//distance between object and the target
    private Vector3 _newScaleAll;//full set of new scale attributes

    //these variables are for altering joints per frame because scaling causes issues
    private Transform[] children;
    private Vector3[] _connectedAnchor;
    private Vector3[] _anchor;

    private float ScaleMin;
    private float ScaleMax;

    // Start is called before the first frame update
    void Start()
    {
        //save all joints on children
        children = transform.GetComponentsInChildren<Transform>();
        _connectedAnchor = new Vector3[children.Length];
        _anchor = new Vector3[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].GetComponent<Joint>() != null)
            {
                _connectedAnchor[i] = children[i].GetComponent<Joint>().connectedAnchor;
                _anchor[i] = children[i].GetComponent<Joint>().anchor;
            }
        }

        //grab original scale for use later
        _originalScale = transform.localScale;
    }

    void OnEnable()
    {
        if (GetComponent<Rigidbody>() != null)
            GetComponent<Rigidbody>().isKinematic = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

        //establish trajectory
        _heading = target.position - transform.position;


        //check to stop processing to save on performance, if the object is in place don't both replacing it
        if (Vector3.Distance(transform.position, target.transform.position) > .001f)
        {
            
            MoveToTarget();
            ScaleToTarget();
        }
        RotateToTarget();
    }


    /// <summary>
    /// switches to a new target remembering the scale of the old target
    /// </summary>
    public bool SetTarget(Transform newTarg)
    {
            _originalScale = target.localScale;
            target = newTarg;
            return true;
        
    }

    /// <summary>
    /// move the object towards the target
    /// </summary>
    private void MoveToTarget()
    {
        transform.Translate(_heading * physicMoveSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// alter scale depending on distance to the goal, altered by scaleFactor
    /// </summary>
    private void ScaleToTarget()
    {
        _currDist = Vector3.Distance(transform.position, target.transform.position);

        //scales need to be changed per axis and also clamped to stay withing the bounds of the smaller
        //and larger travel points

        //x scaling
        if (_originalScale.x < target.transform.localScale.x)
        {
            ScaleMin = _originalScale.x;
            ScaleMax = target.transform.localScale.x;
        }
        else
        {
            ScaleMin = target.transform.localScale.x;
            ScaleMax = _originalScale.x;
        }
        _newScaleX = Mathf.Clamp(
            (target.transform.localScale.x - _currDist * scaleFactor),
            ScaleMin,
            ScaleMax);

        //y scaling
        if (_originalScale.y < target.transform.localScale.y)
        {
            ScaleMin = _originalScale.y;
            ScaleMax = target.transform.localScale.y;
        }
        else
        {
            ScaleMin = target.transform.localScale.y;
            ScaleMax = _originalScale.y;
        }
        _newScaleY = Mathf.Clamp(
            (target.transform.localScale.y - _currDist * scaleFactor),
            ScaleMin,
            ScaleMax);

        //z scaling
        if (_originalScale.z < target.transform.localScale.z)
        {
            ScaleMin = _originalScale.z;
            ScaleMax = target.transform.localScale.z;
        }
        else
        {
            ScaleMin = target.transform.localScale.z;
            ScaleMax = _originalScale.z;
        }
        _newScaleZ = Mathf.Clamp(
            (target.transform.localScale.z - _currDist * scaleFactor),
            ScaleMin,
            ScaleMax);


        //apply the new scale
        _newScaleAll = new Vector3(_newScaleX, _newScaleY, _newScaleZ);
        transform.localScale = _newScaleAll;

        //per frame we need to reassign joint achors. Scaling is not normally supported on joints
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].GetComponent<Joint>() != null)
            {
                children[i].GetComponent<Joint>().connectedAnchor = _connectedAnchor[i];
                children[i].GetComponent<Joint>().anchor = _anchor[i];
            }
        }
    }

    /// <summary>
    /// Rotate our transform a step closer to the target's at "turnspeed"
    /// </summary>
    private void RotateToTarget()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, turnSpeed * Time.deltaTime * 10);
    }


    void OnDisable()
    {
        if(GetComponent<Rigidbody>() != null)
            GetComponent<Rigidbody>().isKinematic = false;
    }

    /// <summary>
    /// send the object back to it's home location
    /// </summary>
    public void SendHome()
    {
        SetTarget(home);
    }

    /// <summary>
    /// send the object to the display location
    /// </summary>
    public void SendDisplay()
    {
        SetTarget(display);
    }

}
