using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;

    PlayerControls playerControls;

    [SerializeField] Vector2 movement = new Vector2();
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;

    private bool isWorking = false;
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
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneChange;

        isWorking = false;
    }

    private void Update()
    {
        if (isWorking == false)
        {
            return;
        }
        HandleMovementInput();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
        }

        playerControls.PlayerMovement.Movement.performed += x => movement = x.ReadValue<Vector2>();

        playerControls.Enable();
    }
    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void HandleMovementInput()
    {
        horizontalInput = movement.x;
        verticalInput = movement.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

        if (moveAmount <= 0.5f && moveAmount > 0)
        {
            moveAmount = 0.5f;
        }
        else if (moveAmount > 0.5 && moveAmount <= 1)
        {
            moveAmount = 1;
        }
    }

    private void OnSceneChange(Scene oldScene, Scene newScene)
    {
        Debug.Log(newScene.buildIndex);
        if (newScene.buildIndex == WorldSaveGameManager.instance.WorldSceneIndex)
        {
            isWorking = true;
        }
        else
        {
            isWorking = false;
        }
    }
}
