using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;

    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
        if (tileManager == null)
        {
            Debug.LogError("tileManager is not assigned!");
        }
    }

    private void Update()
    {
        // Update içinde herhangi bir 3D işlev varsa burada ekleyebilirsiniz.
    }

    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;
        Vector3 spawnOffset = Random.insideUnitSphere * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        // Rigidbody2D yerine Rigidbody kullandık
        if (droppedItem.rb != null)
        {
            droppedItem.rb.AddForce(spawnOffset * 0.2f, ForceMode.Impulse);
        }
    }

    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
}
