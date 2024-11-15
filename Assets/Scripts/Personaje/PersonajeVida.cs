using System;
using System.Collections;
using UnityEngine;

public class PersonajeVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;
    public bool Derrotado { get; private set; }
    public bool PuedeSerCurado => Salud < saludMax;

    private BoxCollider2D _boxCollider2D;
    [SerializeField] private GameObject deathScreenPanel; // Panel de pantalla de muerte
    [SerializeField] private Transform marcadorResurreccion; // Marcador de resurrección

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(false); // Asegúrate de que el panel esté desactivado al inicio
        }
    }

    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }

    private void Update()
    {
        // Métodos de prueba para recibir daño y restaurar salud
        if (Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if (Derrotado || !PuedeSerCurado)
        {
            return;
        }

        Salud += cantidad;
        if (Salud > saludMax)
        {
            Salud = saludMax;
        }

        ActualizarBarraVida(Salud, saludMax);
    }

    protected override void PersonajeDerrotado()
    {
        _boxCollider2D.enabled = false;
        Derrotado = true;
        EventoPersonajeDerrotado?.Invoke();

        // Iniciar la corrutina para mostrar la pantalla de muerte después de 3 segundos
        StartCoroutine(MostrarPantallaDeMuerte());
    }

    private IEnumerator MostrarPantallaDeMuerte()
    {
        yield return new WaitForSeconds(1.5f); // Espera 3 segundos
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(true); // Muestra el panel de muerte
        }
    }

    public void RestaurarPersonaje()
    {
        _boxCollider2D.enabled = true;
        Derrotado = false;
        Salud = saludInicial;
        ActualizarBarraVida(Salud, saludInicial);

        // Mover el personaje a la posición del marcador de resurrección
        if (marcadorResurreccion != null)
        {
            transform.position = marcadorResurreccion.position;
        }

        // Asegúrate de que la animación de derrotado se desactive
        GetComponent<PersonajeAnimaciones>().RevivirPersonaje();

        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(false); // Oculta el panel de muerte al revivir
        }
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}
