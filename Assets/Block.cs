using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //x = Breden, y = höjd
    public Vector2 Dimensioner = new Vector2(16.0f, 16.0f);

    public Vector2 NerVänstraHörn = new Vector2();
    // Start is called before the first frame update
    public static bool CheckCollision(Block aObject1, Block aObject2)
    {
        if (aObject1.NerVänstraHörn.x < aObject2.NerVänstraHörn.x + aObject2.Dimensioner.x &&

            aObject1.NerVänstraHörn.x + aObject2.NerVänstraHörn.x > aObject2.Dimensioner.x &&

            aObject1.NerVänstraHörn.y < aObject2.NerVänstraHörn.y + aObject2.Dimensioner.y &&

            aObject1.NerVänstraHörn.y + aObject2.NerVänstraHörn.y > aObject2.Dimensioner.y)
        {
            return true;

        }

        return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NerVänstraHörn = new Vector2(transform.position.x - (Dimensioner.x * 0.5f), 
            transform.position.y - (Dimensioner.y * 0.5f));

    }
}
