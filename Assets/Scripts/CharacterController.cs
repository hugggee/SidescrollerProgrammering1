using System.Runtime.InteropServices;
using UnityEngine;

public enum CharacterState // uppr�knade lista av karakt�r tillst�nd
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total

}

public class CharacterController : MonoBehaviour
{

    public CharacterState JumpingState = CharacterState.Airborne; // �r karakt�ren p� marken eller i luften?



    public float MovementSpeedPerSecond = 140.0f; // g�
    public float GravityPerSecond = 160.0f; // falla
    public float GroundLevel = 0.0f; // grunden

    //hoppa
    public float JumpSpeedFactor = 3.0f; // Hur mycket snabbare hoppet �r
    public float JumpMaxHeight = 150;
    private float JumpHeightDelta = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
        }


        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded) // up
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;

        }
        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }

        if (Input.GetKey(KeyCode.S)) // ner
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.A)) // v�nster
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.D)) // h�ger
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        {
            // Gravitation
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravityPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
        }
    }
}