using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAccelerator : MonoBehaviour
{
    public Transform leftLegChild;
    public Transform rightLegChild;

    public float playerMoveSpeed = 5f;
    public float sidewaysOverSteer = 1.5f;

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

        propelLeftFowardDir.Normalize();

        playerRigidbody.AddForce(propelLeftFowardDir * playerMoveSpeed);
    }

      private void propelplayerRight()
    {
        Vector3 propelRightFowardDir = rightLegChild.position - transform.position;

        propelRightFowardDir.Normalize();

        playerRigidbody.AddForce(propelRightFowardDir * playerMoveSpeed);
    }
}
