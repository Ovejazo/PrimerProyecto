using UnityEngine;
using UnityEngine.InputSystem; // <--- Necesario para el nuevo sistema

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5.0f;

    void Update()
    {
        // El nuevo sistema no usa "Horizontal/Vertical" por defecto sin configuración previa.
        // Aquí leemos el teclado directamente.
        
        float x = 0;
        float z = 0;

        // Verificar si existe un teclado conectado para evitar errores
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) z = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) z = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1;
        }

        Vector3 direccion = new Vector3(x, 0, z).normalized; // .normalized evita que moverse en diagonal sea más rápido

        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }
}