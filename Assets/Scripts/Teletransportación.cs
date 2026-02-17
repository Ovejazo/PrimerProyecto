using UnityEngine;

public class Teletransportador : MonoBehaviour
{
    [Tooltip("El punto de salida del portal de destino")]
    public Transform puntoDeSalida; 

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que cruzó la puerta es el jugador
        if (other.CompareTag("Player"))
        {
            // Desactivamos el CharacterController temporalmente si lo estás usando
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null) 
            {
                cc.enabled = false;
            }

            // Movemos al jugador a la posición y rotación del punto de salida
            other.transform.position = puntoDeSalida.position;
            other.transform.rotation = puntoDeSalida.rotation;

            // Reactivamos el CharacterController
            if (cc != null) 
            {
                cc.enabled = true;
            }
        }
    }
}