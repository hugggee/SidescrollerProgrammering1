using System.Runtime.InteropServices;
using UnityEngine;


public class PhysicsCharacterController : MonoBehaviour
{
    public Rigidbody2D MinKropp = null;
    public CharacterState JumpingState = CharacterState.Airborne; // är karaktären på marken eller i luften?

    public float MovementSpeedPerSecond = 140.0f; // gå
    public float GravityPerSecond = 160.0f; // falla

    //hoppa
    public float JumpSpeedFactor = 3.0f; // Hur mycket snabbare hoppet är
    public float JumpMaxHeight = 150;
    private float JumpHeightDelta = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 characterVelocity = MinKropp.velocity;
        characterVelocity.x = 0.0f;
        characterVelocity.y = 0.0f;
        //up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;

        }
        if (JumpingState == CharacterState.Jumping)
        {
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y += totalJumpMovementThisFrame;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }


        if (Input.GetKey(KeyCode.A)) // vänster
        {

            characterVelocity.x -= MovementSpeedPerSecond;
            MinKropp.velocity = characterVelocity;
        }
        if (Input.GetKey(KeyCode.D)) // höger
        {

            characterVelocity.x += MovementSpeedPerSecond;
            MinKropp.velocity = characterVelocity;
        }
        MinKropp.velocity = characterVelocity;
    }
}