// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material[] materials = new Material[25];
    private int currentMaterialIndex = 0;

    void Start()
    {
        // Set the initial material
        SetMaterial(materials[currentMaterialIndex]);
    }

    void Update()
    {

    }

    public void ToggleMaterial()
{
    // Choose a random material index
    currentMaterialIndex = Random.Range(0, materials.Length);

    // Set the new material
    SetMaterial(materials[currentMaterialIndex]);
}

    void SetMaterial(Material newMaterial)
    {
        // Set the material of the object
        GetComponent<Renderer>().material = newMaterial;
    }
}
