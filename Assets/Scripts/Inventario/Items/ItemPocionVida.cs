using UnityEngine;

[CreateAssetMenu(menuName = "Items/PocionVida")]
    public class ItemPocionVida : InventarioItem
    {

        [Header("Pocion info")]
        public float HPRestauracion;

        public override bool UsarItem()
        {
            if(Inventario.Instance.Personaje.PersonajeVida.PuedeSerCurado)
            {
                Inventario.Instance.Personaje.PersonajeVida.RestaurarSalud(HPRestauracion);
                return true;
            }

            return false;
        }

    }

