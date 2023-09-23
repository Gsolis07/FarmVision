using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureSwitcher : MonoBehaviour
{
    public GameObject planeObject; // Reference to the plane GameObject.
    public Texture2D texture1;    // Texture to display when button 1 is clicked.
    public Texture2D texture2;    // Texture to display when button 2 is clicked.
    public Texture2D texture3;    // Texture to display when button 3 is clicked.

    // Attach the buttons to this script using the Unity Inspector.
    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
        // Attach button click event listeners.
        button1.onClick.AddListener(() => {
            ChangeTexture(texture1);
            // Populate Field operations after specific field is chosen (get JSON and create new buttons for options in modal two)
            // - After that, populate summary data above in modal when field operation was selected
            });
        button2.onClick.AddListener(() => ChangeTexture(texture2));
        button3.onClick.AddListener(() => ChangeTexture(texture3));

        // Set an initial texture (optional).
        ChangeTexture(texture1);
    }

    // Change the texture of the plane.
    void ChangeTexture(Texture2D newTexture)
    {
        Renderer planeRenderer = planeObject.GetComponent<Renderer>();
        if (planeRenderer != null)
        {
            planeRenderer.material.mainTexture = newTexture;
        }
    }
}
