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
            // Etkileşime geçilecek nesneye ulaş
            Debug.Log("Etkileşim: " + hit.collider.name);
            // Burada nesne ile etkileşim kodunu ekleyebilirsin
        }
    }
}
