using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit to: Matthew Miner  (matthew@matthewminer.com)

[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
    public float speed = 5;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 30;

    private bool moving;
    CharacterController controller;
    float heading;
    Vector3 targetRotation;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        moving = false;

        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
        var forward = transform.TransformDirection(Vector3.forward);
        if (moving)
        {
            controller.SimpleMove(forward * speed);
        }
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>
    // 0 is stand
    // 1 is sit
    // 2 is move
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            if (Random.Range(0, 10) < 3)
            {
                moving = false;
                if (Random.Range(0,2) == 1)
                {
                    GetComponent<Animator>().SetInteger("state", 1);
                }
                else
                {
                    GetComponent<Animator>().SetInteger("state", 0);
                }
            }
            else
            {
                moving = true;
                GetComponent<Animator>().SetInteger("state", 2);
            }
            directionChangeInterval = Random.Range(2, 5);
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// <summary>
    /// Calculates a new direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }
    /*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        NewHeadingRoutine();
    }*/ 
}