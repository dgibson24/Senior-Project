using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwing : MonoBehaviour
{
    [Tooltip("If it is false door can't be used")]
    public bool Locked = false;
    [Tooltip("It is true for remote control only")]
    public bool Remote = false;

    [Tooltip("Door can be opened")]
    public bool CanOpen = true;
    [Tooltip("Door can be closed")]
    public bool CanClose = true;

    public bool isOpened = false;
    [Range(0f, 4f)]
    [Tooltip("Speed for door opening, degrees per sec")]
    public float OpenSpeed = 3f;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    // Hinge
    [HideInInspector]
    public Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;
    float currentLim;

    void Start()
    {
        rbDoor = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if ( !Remote && Input.GetKeyDown(KeyCode.E) && NearView() )
            Action();
        
    }

    public void Action() // void to open/close door
    {
        if (!Locked)
        {
            if (isOpened && CanClose)
            {
                isOpened = false;
            }
            else if (!isOpened && CanOpen)
            {
                isOpened = true;
                rbDoor.AddRelativeTorque(new Vector3(0, 0, 20f)); 
            }
        
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 3f) return true; // angleView < 35f && 
        else return false;
    }

    private void FixedUpdate() // door is physical object
    {
        if (isOpened)
        {
            currentLim = 85f;
        }
        else
        {
            // currentLim = hinge.angle; // door will closed from current opened angle
            if (currentLim > 1f)
                currentLim -= .5f * OpenSpeed;
        }

        // using values to door object
        hingeLim.max = currentLim;
        hingeLim.min = -currentLim;
        hinge.limits = hingeLim;
    }
}
