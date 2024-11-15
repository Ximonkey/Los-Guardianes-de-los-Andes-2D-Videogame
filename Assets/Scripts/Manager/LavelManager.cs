using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavelManager : MonoBehaviour
{
    [SerializeField] private Personaje personaje;
    [SerializeField] private Transform puntoReaparicion;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            if (personaje.PersonajeVida.Derrotado)
        {
            personaje.transform.localPosition = puntoReaparicion.position;
            personaje.RestaurarPersonaje();
        }
        }
    }
}
