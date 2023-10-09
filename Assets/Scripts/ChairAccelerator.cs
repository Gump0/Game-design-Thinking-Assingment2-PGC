using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAccelerator : MonoBehaviour
{
    public Transform leftLegChild;
    public Transform rightLegChild;

    public float playerMoveSpeed = 5f;
    public float sidewaysOverSteer = 1.5f;
    public float rotationalTorque = 1.5f;
    private Rigidbody2D playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        detectinputs();
    }

    private void detectinputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            propelplayerLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            propelplayerRight();
        }
    }

    private void propelplayerLeft()
    {
        Vector3 propelLeftFowardDir = leftLegChild.position - transform.position;
    Vector3 propelLeftOverSteerDir = leftLegChild.position - transform.position;

    propelLeftFowardDir.Normalize();
    propelLeftOverSteerDir.Normalize();

    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, propelLeftFowardDir.normalized);

    targetRotation *= Quaternion.Euler(0, 0, 180);

    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationalTorque * Time.deltaTime);

    playerRigidbody.AddForce(propelLeftFowardDir * playerMoveSpeed);
    playerRigidbody.AddForce(propelLeftFowardDir * playerMoveSpeed);
    }

      private void propelplayerRight()
    {
        Vector3 propelRightFowardDir = rightLegChild.position - transform.position;
        Vector3 propelRightOverSteerDir = rightLegChild.position - transform.position;

        propelRightFowardDir.Normalize();
        propelRightOverSteerDir.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, propelRightFowardDir.normalized);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationalTorque * Time.deltaTime);

        playerRigidbody.AddForce(propelRightFowardDir * playerMoveSpeed);
        playerRigidbody.AddForce(propelRightFowardDir * sidewaysOverSteer);
    }
}
