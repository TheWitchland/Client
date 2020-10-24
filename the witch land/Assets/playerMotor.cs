using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    public float speed = 3;
    public float walkSpeed = 9;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    [SerializeField]
    private float lookSensitivity = 3f;
    private Vector3 rotation;
    private Vector3 cameraRotation;

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }



    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>(); //réferencer playerCollider en temps que components
    }


    [SerializeField] LayerMask playerLayer;

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.1f, playerLayer); //Verifie si notre personnage est au sol
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.X)))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.X)))
        {
            transform.Translate(walkSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q) && !(Input.GetKey(KeyCode.X)))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q) && (Input.GetKey(KeyCode.X)))
        {
            transform.Translate(-walkSpeed * Time.deltaTime, 0, 0);
        }

        //avancer reculer

        if (Input.GetKey(KeyCode.Z) && (Input.GetKey(KeyCode.X)))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Z) && !(Input.GetKey(KeyCode.X)))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.X)))
        {
            transform.Translate(0, 0, -walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.X)))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //le return s'occupe lui meme de dire si c'est vrai ou faux.
        {
            // preparation du saut (necessaire)
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            //saut

            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }
    }
}
