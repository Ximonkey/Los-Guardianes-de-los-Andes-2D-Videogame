using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Paneles")]
    [SerializeField] private PanelManager panelManager;
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelTienda;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelInspectorQuests;
    [SerializeField] private GameObject panelPersonajeQuests;

    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI nivelTMP;
    [SerializeField] private TextMeshProUGUI monedasTMP;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDañoTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    [SerializeField] private TextMeshProUGUI atributoFuerzaTMP;
    [SerializeField] private TextMeshProUGUI atributoInteligenciaTMP;
    [SerializeField] private TextMeshProUGUI atributoDestrezaTMP;
    [SerializeField] private TextMeshProUGUI atributosDisponiblesTMP;

    private float vidaActual;
    private float vidaMax;
    private float manaActual;
    private float manaMax;
    private float expActualTemp;
    private float expRequeridaNuevoNivel;

    void Start()
    {
       
    }

    private void Update()
    {
        ActualizarUIPersonaje();
        ActualizarPanelStats();
    }

    private void ActualizarUIPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, 
            vidaActual / vidaMax, 10f * Time.deltaTime);
        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, 
            manaActual / manaMax, 10f * Time.deltaTime);
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, 
            expActualTemp / expRequeridaNuevoNivel, 10f * Time.deltaTime);

        vidaTMP.text = $"{vidaActual}/{vidaMax}";
        manaTMP.text = $"{manaActual}/{manaMax}"; 
        expTMP.text = $"{((expActualTemp / expRequeridaNuevoNivel) * 100):F2}%";  
        nivelTMP.text = $"Nivel {stats.Nivel}";
        monedasTMP.text = MonedasManager.Instance.MonedasTotales.ToString();
    }

    public void ActualizarPanelStats()
    {
        if (!panelStats.activeSelf)
        {
            return;
        }

        statDañoTMP.text = stats.Daño.ToString();
        statDefensaTMP.text = stats.Defensa.ToString();
        statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
        statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
        statVelocidadTMP.text = stats.Velocidad.ToString();
        statNivelTMP.text = stats.Nivel.ToString();
        statExpTMP.text = expActualTemp.ToString();
        statExpRequeridaTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();
    
        int costoHabilidad = stats.CalcularCostoHabilidad();
        atributoFuerzaTMP.text = costoHabilidad.ToString();
        atributoInteligenciaTMP.text = costoHabilidad.ToString();
        atributoDestrezaTMP.text = costoHabilidad.ToString();
        atributosDisponiblesTMP.text = $"Puntos Disponibles: {stats.PuntosDisponibles}";
    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
    
    public void ActualizarManaPersonaje(float pManaActual, float pManaMax)
    {
        manaActual = pManaActual;
        manaMax = pManaMax;
    }

    public void ActualizarExpPersonaje(float pExpActualTemp, float pExpRequerida)
    {
        expActualTemp = pExpActualTemp;
        expRequeridaNuevoNivel = pExpRequerida;
    }

    #region Paneles

    public void AbrirCerrarPanelStats()
    {
        panelManager.TogglePanel(panelStats);
    }

    public void AbrirCerrarPanelTienda()
    {
        panelManager.TogglePanel(panelTienda);
    }

    public void AbrirCerrarPanelInventario()
    {
        panelManager.TogglePanel(panelInventario);
    }

    public void AbrirCerrarPanelInspectorQuests()
    {
        panelManager.TogglePanel(panelInspectorQuests);
    }

    public void AbrirCerrarPanelPersonajeQuests()
    {
        panelManager.TogglePanel(panelPersonajeQuests);
    }

    public void AbrirPanelInteraccion(InteraccionExtraNPC tipoInteraccion)
    {
        switch(tipoInteraccion)
        {
            case InteraccionExtraNPC.Quests:
                AbrirCerrarPanelInspectorQuests();
                break;
            case InteraccionExtraNPC.Tienda:
                AbrirCerrarPanelTienda();
                break;
            case InteraccionExtraNPC.Crafting:
                break;
        }
    }

    #endregion
}
