using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    // referens till objektet
    public Rigidbody2D minkropp = null;

    public CharacterState JumpingState = CharacterState.Airborne;

    // gravitation
    public float GravityPerSecond = 160.0f; // jag ramlar hj�lpp


    // hoppa
    public float JumpSpeedFactor = 3.0f; // Hur snabbare �r hoppet
    public float JumpMaxHeight = 150.0f;
    public float JumpHeightDelta = 0.0f;

    // fart
    public float MovementSpeedPerSecond = 10.0f; // farten





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
    }

    void FixedUpdate()
    {
        Vector3 characterVelocity = minkropp.velocity;
        characterVelocity.x = 0.0f;

        if (JumpingState == CharacterState.Jumping)
        {
            float jumpMovement = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = jumpMovement;

            JumpHeightDelta += jumpMovement * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;

            }
        }

        // v�nster
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        // h�ger    
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        minkropp.velocity = characterVelocity;

    }
}