using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    private Dictionary<GameObject, bool> panelStates = new Dictionary<GameObject, bool>();

    public void TogglePanel(GameObject panel)
    {
        if (panel == null) return;

        bool isActive = panel.activeSelf;
        panel.SetActive(!isActive);

        foreach (var key in panelStates.Keys)
        {
            if (key != panel && key.activeSelf)
            {
                key.SetActive(false);
            }
        }

        if (isActive)
        {
            panelStates.Remove(panel);
        }
        else
        {
            panelStates[panel] = true;
        }

        UIManager.Instance.ActualizarPanelStats();
    }
}
