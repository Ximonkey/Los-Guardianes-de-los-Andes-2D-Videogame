using Cinemachine;
using UnityEngine;

public class ZonaConfiner : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera zonaEstaticaCamera;
    [SerializeField] private CinemachineVirtualCamera camaraDeSeguimiento;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            zonaEstaticaCamera.Priority = 10;
            camaraDeSeguimiento.Priority = 5;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            zonaEstaticaCamera.Priority = 5;
            camaraDeSeguimiento.Priority = 10;
        }
    }
}