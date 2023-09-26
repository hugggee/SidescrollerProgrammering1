using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    void Start()
    {
        
    }


    public float MovementSpeedPerSecond = 10.0f; // gå
    public float GravityPerSecond = 140.0f; // falla
    public float GroundLevel = 0.0f; // grunden
    // Update is called once per frame
    void Update()
    {
        // Gravitation
        Vector3 gravityPosition = transform.position;
        gravityPosition.y -= GravityPerSecond * Time.deltaTime;
        if(gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
        transform.position = gravityPosition;


        if (Input.GetKey(KeyCode.W)) // up
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.S)) // ner
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.A)) // vänster
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        if (Input.GetKey(KeyCode.D)) // höger
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }

    }
}
