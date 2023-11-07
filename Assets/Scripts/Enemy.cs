using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    // för gubben
    public Rigidbody2D myRigidBody = null;

    public float FartPerSekund = 10.0f;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gubbeHastighet = myRigidBody.velocity;

        gubbeHastighet.x = 0;

        gubbeHastighet += FartPerSekund * transform.right.normalized;

        myRigidBody.velocity = gubbeHastighet;
    }
}
