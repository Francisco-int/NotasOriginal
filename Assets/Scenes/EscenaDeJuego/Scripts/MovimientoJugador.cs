using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
   [SerializeField] float velocidad = 5f;
    float horizontal;
    float vertical;
    float mouseX;
    float mouseY;
    [SerializeField] float sensibilidadX = 100f;
    [SerializeField] float sensibilidadY = 100f;
    float xRotation = 0f;
   [SerializeField] Camera camara;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        mouseY = Input.GetAxis("Mouse Y") * sensibilidadY * Time.deltaTime;
        mouseX = Input.GetAxis("Mouse X") * sensibilidadX * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, 0f, vertical) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        camara.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.transform.Rotate(Vector3.up * mouseX);
    }
}
