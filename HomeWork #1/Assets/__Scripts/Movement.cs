using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public CharacterController controller; // Игрок
    public float speed = 5f; // Cкорость движения
    public float turnSmoothTime = 0.1f; // Скорость поворота

    [Header("Set is Dynamically")]
    private float turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // Поворот модели
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Движение по сторонам x, y
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
