using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingShotgun: MonoBehaviour
{
    public Transform centerObject; // El objeto alrededor del cual se orbitar�
    public float orbitSpeed = 5f; // Velocidad de �rbita
    public float rotationSpeed = 10f; // Velocidad de rotaci�n al mirar al mouse

    void Update()
    {
        // Movimiento de �rbita alrededor del objeto central
        OrbitAroundCenter();

        // Rotaci�n para mirar hacia el mouse
        RotateToMousePosition();
    }

    void OrbitAroundCenter()
    {
        // Obtener la direcci�n desde el objeto central al objeto actual
        Vector2 directionToCenter = (Vector2)transform.position - (Vector2)centerObject.position;

        // Rotar el objeto alrededor del objeto central en 2D
        transform.RotateAround(centerObject.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }

    void RotateToMousePosition()
    {
        // Obtener la posici�n del mouse en el mundo
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la rotaci�n hacia la posici�n del mouse en 2D
        Vector2 directionToMouse = mousePosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        Quaternion rotationToMouse = Quaternion.AngleAxis(angle, Vector3.forward);

        // Aplicar rotaci�n suave hacia la posici�n del mouse
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToMouse, rotationSpeed * Time.deltaTime);
    }
}
