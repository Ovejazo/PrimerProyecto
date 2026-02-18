using UnityEngine;

public class InteracciónObjeto : MonoBehaviour
{
    LayerMask Mask;
    public float distancia = 4f;

    void Start()
    {
        Mask = LayerMask.GetMask("RaycastDetect");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, Mask))
        {
            if (hit.collider.tag == "ObjetivoInteractivo")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<ObjetivoInteractivo>().ActivarObjetivo();
                }
            }
        }
    }
}
