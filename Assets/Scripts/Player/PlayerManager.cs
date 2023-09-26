using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    PlayerLocomotionManager PlayerLocomotionManager;

    protected override void Awake()
    {
        base.Awake();

        PlayerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }
    protected override void Update()
    {
        base.Update();

        if (!IsOwner)
            return;

        PlayerLocomotionManager.HandleMovement();
    }
}
