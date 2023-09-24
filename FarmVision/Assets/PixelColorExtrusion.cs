using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelColorExtrusion : MonoBehaviour
{
    public Texture2D sourceTexture; // Assign the texture you want to extrude in the Inspector.
    public float extrusionHeight = 1.0f; // Adjust the extrusion height as needed.
    public float pixelScale = 0.1f; // Adjust the scale of the extruded cubes.
    public Vector3 offset = Vector3.zero; // Offset to apply to the extrusion positions.

    private void Start()
    {
        // Check if the Mesh Renderer component is enabled on the GameObject.
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null && meshRenderer.enabled)
        {
            if (sourceTexture == null)
            {
                Debug.LogError("Please assign a source texture in the Inspector.");
                return;
            }

            // Create a GameObject to hold the extrusions.
            GameObject extrusionContainer = new GameObject("ExtrusionContainer");

            for (int x = 0; x < sourceTexture.width; x += 4)
            {
                for (int y = 0; y < sourceTexture.height; y += 4)
                {
                    Color pixelColor = sourceTexture.GetPixel(x, y);

                    // Calculate the extrusion height based on pixel color (Red = high, Green = low).
                    float extrusion = (pixelColor.b + (pixelColor.g - pixelColor.r) + 0.8f) * extrusionHeight;
                    if ((pixelColor.r < 0.5f && pixelColor.b < 0.5f && pixelColor.g < 0.5f) || extrusion < 0.0f)
                    {
                        extrusion = 0.0f;
                    }

                    // Create a cube extrusion if the pixel is not fully transparent.
                    if (pixelColor.a > 0)
                    {
                        GameObject extrusionObject = CreateExtrusionCube(pixelScale, extrusion, pixelColor);
                        Material cubeMaterial = new Material(Shader.Find("UI/Default"));
                        cubeMaterial.color = pixelColor;

                        extrusionObject.GetComponent<Renderer>().material = cubeMaterial;

                        // Calculate the world space position of the extrusion cube.
                        Vector3 position = new Vector3(
                            x * pixelScale + offset.x,
                            extrusion / 2f + offset.y,
                            y * pixelScale + offset.z
                        );

                        extrusionObject.transform.position = position;

                        // Parent the extrusion cube to the container for organization.
                        extrusionObject.transform.SetParent(extrusionContainer.transform);
                    }
                }
            }
        }
    }

    private GameObject CreateExtrusionCube(float scale, float height, Color color)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "ExtrusionCube";
        cube.transform.localScale = new Vector3(scale, height, scale);
        cube.GetComponent<Renderer>().material.color = color; // Set the color of the cube's material.

        return cube;
    }
}
