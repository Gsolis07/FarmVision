using UnityEngine;
using UnityEngine.UI;

public class ToggleMeshRenderers : MonoBehaviour
{
    public GameObject plane1; // Assign the first Plane object in the Inspector.
    public GameObject plane2; // Assign the second Plane object in the Inspector.
    public Button button1; // Assign "button1" in the Inspector.
    public Button button2; // Assign "button2" in the Inspector.

    public Button button3; // Assign "button1" in the Inspector.
    public Button button4; // Assign "button2" in the Inspector.
    public Button button5; // Assign "button1" in the Inspector.

    public GameObject[] fieldObjects; // Assign your 8 "field" GameObjects in the Inspector.
    public int buttonClicked = 1;

    private GameObject extrusionContainer; // Reference to the ExtrusionContainer.

    //NEW VARS
    public Texture2D sourceTexture; // Assign the texture you want to extrude in the Inspector.
    public float extrusionHeight = 0.02f; // Adjust the extrusion height as needed.
    public float pixelScale = 0.006f; // Adjust the scale of the extruded cubes.
    public Vector3 offset = Vector3.zero; // Offset to apply to the extrusion positions.

    private void Start()
    {
        // Attach click event listeners to the Button objects.
        if (button1 != null)
        {
            button1.onClick.AddListener(ToggleRenderers1);
        }
        else
        {
            Debug.LogError("Button1 is not assigned.");
        }

        if (button2 != null)
        {
            button2.onClick.AddListener(ToggleRenderers2);
        }
        else
        {
            Debug.LogError("Button2 is not assigned.");
        }

        button3.onClick.AddListener(ToggleMap3);
        button4.onClick.AddListener(ToggleMap4);
        button5.onClick.AddListener(ToggleMap5);
    }

    private void ToggleRenderers1()
    {
        // Find and store the reference to the ExtrusionContainer.
        extrusionContainer = GameObject.Find("ExtrusionContainer");

        buttonClicked = 1;

        if (plane1 != null)
        {
            plane1.GetComponent<MeshRenderer>().enabled = true;
        }

        if (plane2 != null)
        {
            plane2.GetComponent<MeshRenderer>().enabled = false;
        }

        // Delete the ExtrusionContainer GameObject if it exists.
        if (extrusionContainer != null)
        {
            Destroy(extrusionContainer);
        }

        // Toggle off the mesh renderers of the "field" GameObjects.
        foreach (GameObject fieldObject in fieldObjects)
        {
            if (fieldObject != null)
            {
                fieldObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void ToggleRenderers2()
    {
        // Find and store the reference to the ExtrusionContainer.
        extrusionContainer = GameObject.Find("ExtrusionContainer");

        buttonClicked = 6;

        if (plane1 != null)
        {
            plane1.GetComponent<MeshRenderer>().enabled = false;
        }

        if (plane2 != null)
        {
            plane2.GetComponent<MeshRenderer>().enabled = true;
        }

        // Delete the ExtrusionContainer GameObject if it exists.
        if (extrusionContainer != null)
        {
            Destroy(extrusionContainer);
        }

        // Toggle off the mesh renderers of the "field" GameObjects.
        foreach (GameObject fieldObject in fieldObjects)
        {
            if (fieldObject != null)
            {
                fieldObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    
    private void ToggleMap3()
    {
        // Find and store the reference to the ExtrusionContainer.
        extrusionContainer = GameObject.Find("ExtrusionContainer");
        // Delete the ExtrusionContainer GameObject if it exists.
        if (extrusionContainer != null)
        {
            Destroy(extrusionContainer);
        }

        // Toggle off the mesh renderers of the "field" GameObjects.
        foreach (GameObject fieldObject in fieldObjects)
        {
            if (fieldObject != null)
            {
                fieldObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // Turn on correct PNG
        if (buttonClicked == 1) {
            sourceTexture = fieldObjects[0].GetComponent<Renderer>().material.mainTexture as Texture2D;
            fieldObjects[0].GetComponent<MeshRenderer>().enabled = true;
            offset = fieldObjects[0].GetComponent<Transform>().localPosition;
            performExtrusions(0);
        } else {
            sourceTexture = fieldObjects[3].GetComponent<Renderer>().material.mainTexture as Texture2D;
            fieldObjects[3].GetComponent<MeshRenderer>().enabled = true;
            offset = fieldObjects[3].GetComponent<Transform>().localPosition;
            performExtrusions(3);
        }
    }

    private void ToggleMap4()
    {
        // Find and store the reference to the ExtrusionContainer.
        extrusionContainer = GameObject.Find("ExtrusionContainer");
        // Delete the ExtrusionContainer GameObject if it exists.
        if (extrusionContainer != null)
        {
            Destroy(extrusionContainer);
        }

        // Toggle off the mesh renderers of the "field" GameObjects.
        foreach (GameObject fieldObject in fieldObjects)
        {
            if (fieldObject != null)
            {
                fieldObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // Turn on correct PNG
        if (buttonClicked == 1) { 
            sourceTexture = fieldObjects[1].GetComponent<Renderer>().material.mainTexture as Texture2D;
            fieldObjects[1].GetComponent<MeshRenderer>().enabled = true;
            offset = fieldObjects[1].GetComponent<Transform>().localPosition;
            performExtrusions(1);
        } else {
            sourceTexture = fieldObjects[4].GetComponent<Renderer>().material.mainTexture as Texture2D;
            fieldObjects[4].GetComponent<MeshRenderer>().enabled = true;
            offset = fieldObjects[4].GetComponent<Transform>().localPosition;
            performExtrusions(4);
        }
    }

    private void ToggleMap5()
    {
        // Find and store the reference to the ExtrusionContainer.
        extrusionContainer = GameObject.Find("ExtrusionContainer");
        // Delete the ExtrusionContainer GameObject if it exists.
        if (extrusionContainer != null)
        {
            Destroy(extrusionContainer);
        }

        // Toggle off the mesh renderers of the "field" GameObjects.
        foreach (GameObject fieldObject in fieldObjects)
        {
            if (fieldObject != null)
            {
                fieldObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // Turn on correct PNG
        if (buttonClicked == 1) { 
            sourceTexture = fieldObjects[2].GetComponent<Renderer>().material.mainTexture as Texture2D;
            fieldObjects[2].GetComponent<MeshRenderer>().enabled = true;
            offset = fieldObjects[2].GetComponent<Transform>().localPosition;
            performExtrusions(2);
        } else {
            sourceTexture = fieldObjects[5].GetComponent<Renderer>().material.mainTexture as Texture2D;
            fieldObjects[5].GetComponent<MeshRenderer>().enabled = true;
            offset = fieldObjects[5].GetComponent<Transform>().localPosition;
            performExtrusions(5);
        }
    }

    private void performExtrusions(int index)
    {
        MeshRenderer meshRenderer = fieldObjects[index].GetComponent<MeshRenderer>();
        // Check if the Mesh Renderer component is enabled on the GameObject.
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
                    float extrusion = (pixelColor.b + (pixelColor.g - pixelColor.r) + 0.8f) * 0.2f;
                    if ((pixelColor.r < 0.5f && pixelColor.b < 0.5f && pixelColor.g < 0.5f) || extrusion < 0.0f)
                    {
                        extrusion = 0.0f;
                    }

                    // Create a cube extrusion if the pixel is not fully transparent.
                    if (pixelColor.a > 0)
                    {
                        GameObject extrusionObject = CreateExtrusionCube(0.006f, extrusion, pixelColor);
                        Material cubeMaterial = new Material(Shader.Find("UI/Default"));
                        cubeMaterial.color = pixelColor;

                        extrusionObject.GetComponent<Renderer>().material = cubeMaterial;

                        // Calculate the world space position of the extrusion cube.
                        // Field 1
                        Vector3 position;
                        if (index < 3) {
                            position = new Vector3(
                                x * 0.006f + 30.5f,
                                extrusion / 2f + 2.3f,
                                y * 0.006f + -1.55f
                            );
                        } else { // Field 6
                            position = new Vector3(
                                x * 0.006f + 30.63f,
                                extrusion / 2f + 2.3f,
                                y * 0.006f + -1.55f
                            );
                        }
                        

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
