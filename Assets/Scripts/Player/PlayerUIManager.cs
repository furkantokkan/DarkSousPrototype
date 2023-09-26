using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;
    [Header("Network Join")]
    [SerializeField] private bool startGameAsClient;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (startGameAsClient)
        {
            startGameAsClient = false;
            //we must shut down host if we want to join as a client
            NetworkManager.Singleton.Shutdown();
            // restart as a client
            NetworkManager.Singleton.StartClient();
        }
    }
}
