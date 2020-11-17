using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class FollowPoint : MonoBehaviour
{
    [Tooltip("Move speed when the object seeks target.")]
    public float physicMoveSpeed;
    [Tooltip("Transform of current seek target")]
    public Transform target;
    [Tooltip("Lower number results in earlier size change during travel. 0 is instant change")]
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

    private Vector3 colliderPos;
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

            //turn off all the lights. they will be enabled and disable depending on the size of the car
            if (children[i].GetComponent<Light>() != null)
            {
                children[i].GetComponent<Light>().enabled = false;
            }
            //disable all child colliders until display time
            if (children[i].GetComponent<Collider>() != null)
            {
                children[i].GetComponent<Collider>().enabled = false;
            }
        }

        //Start the car at the scale, rotation and position of home
        transform.localScale = home.localScale;
        transform.rotation = home.rotation;
        transform.position = home.position;

        //grab original scale for use later
        _originalScale = home.localScale;

        //set the first target to be home if no target is assigned
        if (target == null)
        {
            target = home;
        }

        //re enable main collider
        GetComponent<Collider>().enabled = true;
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
        if (target != null)
        {
            //establish trajectory
            _heading = target.position - transform.position;


            //check to stop processing to save on performance, if the object is in place don't both replacing it
            if (Vector3.Distance(transform.position, target.transform.position) > .01f)
            {
                MoveToTarget();
                ScaleToTarget();
            }

            RotateToTarget();
        }
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
            _newScaleX = Mathf.Clamp(
                (target.transform.localScale.x - (_currDist * scaleFactor)),
                _originalScale.x,
                target.transform.localScale.x);
        }
        else
        {
            _newScaleX = Mathf.Clamp(
                (target.transform.localScale.x - (_currDist * scaleFactor)),
                target.transform.localScale.x,
                _originalScale.x);
        }


        //y scaling
        if (_originalScale.y < target.transform.localScale.y)
        {
            _newScaleY = Mathf.Clamp(
                (target.transform.localScale.y - (_currDist * scaleFactor)),
                _originalScale.y,
                target.transform.localScale.y);
        }
        else
        {
            _newScaleY = Mathf.Clamp(
                (target.transform.localScale.y - (_currDist * scaleFactor)),
                target.transform.localScale.y,
                _originalScale.y);
        }

        //z scaling
        if (_originalScale.z < target.transform.localScale.z)
        {
            _newScaleZ = Mathf.Clamp(
                (target.transform.localScale.z - (_currDist * scaleFactor)),
                _originalScale.z,
                target.transform.localScale.z);
        }
        else
        {
            _newScaleZ = Mathf.Clamp(
                (target.transform.localScale.z - (_currDist * scaleFactor)),
                target.transform.localScale.z,
                _originalScale.z);
        }


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

            if (children[i].GetComponent<Light>() != null)
            {
                if (_newScaleX > .7f)
                {
                    children[i].GetComponent<Light>().enabled = true;
                }
                else if(children[i].GetComponent<Light>().enabled)
                {
                    children[i].GetComponent<Light>().enabled = false;
                }
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
        foreach (Collider box in GetComponentsInChildren<Collider>())
        {
            box.enabled = false;
        }
        GetComponent<AudioSource>().Stop();
        GetComponent<BoxCollider>().enabled = true;
        SetTarget(home);
    }

    /// <summary>
    /// send the object to the display location
    /// </summary>
    public void SendDisplay()
    {
        foreach (Collider box in GetComponentsInChildren<Collider>())
        {
            box.enabled = true;
        }
        GetComponent<BoxCollider>().enabled = false;
        SetTarget(display);
    }

}
