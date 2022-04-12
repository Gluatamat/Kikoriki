using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button startHostButton;
    [SerializeField]
    private Button startClientButton;

    private void Awake()
    {
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*startHostButton.onClick.AddListener(() =>
        { 
            if (NetworkManager.Singleton.StartHost())
            {
                Debug.Log($"Server started...");
            }
            else
            {
                Debug.Log($"Server could not be started...");
            }
        });

        startClientButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Debug.Log($"Client started...");
            }
            else
            {
                Debug.Log($"Client could not be started...");
            }
        });*/

        startHostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log($"Server started...");

        });

        startClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log($"Client started...");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
