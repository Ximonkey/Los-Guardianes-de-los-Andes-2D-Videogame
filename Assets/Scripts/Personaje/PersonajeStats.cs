using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class PersonajeStats : ScriptableObject
{
    [Header("Stats")]
    public float Daño = 5f;
    public float Defensa = 2f;
    public float Velocidad = 5f;
    public float Nivel;
    public float ExpActual;
    public float ExpRequeridaSiguienteNivel;
    [Range(0f, 100f)] public float PorcentajeCritico;
    [Range(0f, 100f)] public float PorcentajeBloqueo;

    [Header("Atributos")]
    public int Fuerza;
    public int Inteligencia;
    public int Destreza;

    [HideInInspector] public int PuntosDisponibles;

    //
    public int CalcularCostoHabilidad()
    {
        return (int)((Nivel / 5) * 2);
    }
    //

    public void AñadirBonusPorAtributoFuerza(){
        Daño += 1.5f;
        PorcentajeCritico += 0.05f;
    }

    public void AñadirBonusPorAtributoInteligencia(){
        Defensa += 1f;   
    }

    public void AñadirBonusPorAtributoDestreza(){
        Velocidad += 1f;
        PorcentajeBloqueo += 0.03f;    
    }

    public void AñadirBonusPorArma(Arma arma)
    {
        Daño += arma.Daño;
        PorcentajeCritico += arma.ChanceCritico;
        PorcentajeBloqueo += arma.ChanceBloqueo;
    }

    public void RemoverBonusPorArma(Arma arma)
    {
        Daño -= arma.Daño;
        PorcentajeCritico -= arma.ChanceCritico;
        PorcentajeBloqueo -= arma.ChanceBloqueo;
    }

    public void ResetearValores(){
        Daño = 5f;
        Defensa = 2f;
        Velocidad = 5f;
        Nivel = 1;
        ExpActual = 0f;
        ExpRequeridaSiguienteNivel = 0f;
        PorcentajeBloqueo = 0f;
        PorcentajeCritico = 0f;

        Fuerza = 0;
        Destreza = 0;
        Inteligencia = 0;

        PuntosDisponibles = 0;

    }
}
