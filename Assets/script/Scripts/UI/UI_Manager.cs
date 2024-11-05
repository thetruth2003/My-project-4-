using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();
    public List<Inventory_UI> inventoryUIs;
    public GameObject inventoryUI; // Envanter UI nesnesi
    public bool isInventoryOpen = false; // Envanterin açık olup olmadığını kontrol etmek için bir bayrak

    public GameObject inventoryPanel;

    public static Slot_UI draggedSlot;
    public static Image draggedIcon;

    public static bool dragSingle;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        ToggleInventoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventoryUI();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }
    }

    public void ToggleInventoryUI()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                RefreshInventoryUI("backpack");
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }
    }

    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }

    public void RefreshAll()
    {
        foreach (KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName)
        {
            keyValuePair.Value.Refresh();
        }
    }

    public Inventory_UI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }

        return null;
    }

    private void Initialize()
    {
        foreach (Inventory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }


    // Envanteri açma fonksiyonu
    public void OpenInventory()
    {
        inventoryUI.SetActive(true); // Envanter UI'sini göster
        isInventoryOpen = true; // Bayrağı güncelle
    }

    // Envanteri kapama fonksiyonu
    public void CloseInventory()
    {
        inventoryUI.SetActive(false); // Envanter UI'sini gizle
        isInventoryOpen = false; // Bayrağı güncelle
    }

    // Envanterin açık olup olmadığını kontrol etme fonksiyonu
    public bool IsInventoryOpen()
    {
        return isInventoryOpen;
    }

    // Diğer UI yönetimi ile ilgili fonksiyonlarınızı buraya ekleyebilirsiniz.
}
