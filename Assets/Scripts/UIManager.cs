using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public static UIManager um;
    PlayerCamera pc;
    private bool toggle = false;
    public bool Toggle { get => toggle; set => toggle = value; }

    private void Awake()
    {
        #region Singleton

        if (um == null)
        {
            DontDestroyOnLoad(gameObject);
            um = this;
        }
        else if (um != null)
        {
            Destroy(gameObject);
        }
        #endregion
        showMap(toggle);
        toggleMouse(toggle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            toggle = !toggle;

        showMap(toggle);
        toggleMouse(toggle);
    }

    void showMap(bool toggle)
    {
        pc = FindObjectOfType<PlayerCamera>();
        if (toggle) 
        {
            canvas.SetActive(toggle);
            toggleMouse(toggle);
        }
        else
        {
            canvas.SetActive(toggle);
            toggleMouse(toggle);
        }
    }

    public void toggleMouse(bool toggle)
    {
        if (toggle)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

}
