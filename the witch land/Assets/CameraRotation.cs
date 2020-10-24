using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private Vector3 rotation;
    [SerializeField]
    private Vector3 cameraRotation;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void PerformMovement() //si l'on met juste void ou private void c pareil
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);

    }

    void Update()
    {
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;

        Rotate(_rotation);

        //on va calculer la rotation de la camera en un vecteur 3d
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        RotateCamera(_cameraRotation);
        PerformRotation();


    }


}
