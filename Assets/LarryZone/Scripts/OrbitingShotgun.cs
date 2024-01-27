using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingShotgun: MonoBehaviour
{
    public Transform centerObject; // El objeto alrededor del cual se orbitará
    public float orbitSpeed = 5f; // Velocidad de órbita
    public float rotationSpeed = 10f; // Velocidad de rotación al mirar al mouse

    void Update()
    {
        // Movimiento de órbita alrededor del objeto central
        OrbitAroundCenter();

        // Rotación para mirar hacia el mouse
        RotateToMousePosition();
    }

    void OrbitAroundCenter()
    {
        // Obtener la dirección desde el objeto central al objeto actual
        Vector2 directionToCenter = (Vector2)transform.position - (Vector2)centerObject.position;

        // Rotar el objeto alrededor del objeto central en 2D
        transform.RotateAround(centerObject.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }

    void RotateToMousePosition()
    {
        // Obtener la posición del mouse en el mundo
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la rotación hacia la posición del mouse en 2D
        Vector2 directionToMouse = mousePosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        Quaternion rotationToMouse = Quaternion.AngleAxis(angle, Vector3.forward);

        // Aplicar rotación suave hacia la posición del mouse
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToMouse, rotationSpeed * Time.deltaTime);
    }
}
