using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Camera playerCamera; // Oyuncunun kamerası
    public float maxDistance = 100f; // Maksimum atış mesafesi
    public LayerMask interactableLayer; // Etkileşimde bulunulacak katman

    private void Update()
    {
        // Fare tıklaması ile etkileşime gir
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer))
        {
            // Etkileşimli nesneye ulaşılabilir
            Debug.Log("Etkileşim: " + hit.collider.name);

            // Item bileşeni olup olmadığını kontrol et
            Item item = hit.collider.GetComponent<Item>();

            if (item != null)
            {
                // Item varsa, oyuncuya ver
                Player player = FindObjectOfType<Player>(); // Oyuncuyu buluyoruz

                if (player != null)
                {
                    // Item'ı envantere ekleyip objeyi yok ediyoruz
                    player.inventoryManager.Add("backpack", item);
                    Destroy(hit.collider.gameObject); // Item'ı topladığımızda item objesini yok et
                }
            }
        }
    }
}
