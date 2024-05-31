using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float amplitude = 0.5f; // L'amplitude du mouvement de flottaison
    public float frequency = 1f; // La fréquence du mouvement de flottaison

    // Position de départ de l'asset
    private Vector3 startPos;

    void Start()
    {
        // Sauvegarder la position initiale de l'asset
        startPos = transform.position;
    }

    void Update()
    {
        // Calculer la nouvelle position de l'asset
        Vector3 newPos = startPos;
        newPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;

        // Appliquer la nouvelle position
        transform.position = newPos;
    }
}