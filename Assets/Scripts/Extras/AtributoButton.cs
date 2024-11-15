using UnityEngine;
using UnityEngine.UI;

public class AtributoButton : MonoBehaviour
{
    public delegate void AgregarAtributoDelegate(Personaje.TipoAtributo tipo);
    public static event AgregarAtributoDelegate EventoAgregarAtributo;

    [SerializeField] private Personaje personaje;
    [SerializeField] private Personaje.TipoAtributo tipoAtributo;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("Button no está asignado en AtributoButton.");
            return;
        }

        if (personaje == null)
        {
            Debug.LogError("Personaje no está asignado en AtributoButton.");
            return;
        }

        button.onClick.AddListener(AgregarAtributo);
    }

    private void AgregarAtributo()
    {
        EventoAgregarAtributo?.Invoke(tipoAtributo);
    }
}
