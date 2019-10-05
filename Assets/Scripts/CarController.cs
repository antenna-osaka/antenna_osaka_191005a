using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float Speed;
    public float angularVelocity = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        float forceZ = Input.GetAxis("Vertical") * Speed* rigidbody.mass;
        
        float localSpeedZ = (Quaternion.Inverse(this.transform.rotation) * rigidbody.velocity).z;
        float angularY = Input.GetAxis("Horizontal") * angularVelocity * localSpeedZ;
        rigidbody.AddRelativeForce(new Vector3(0.0f, 0.0f, forceZ));
        rigidbody.angularVelocity = new Vector3(rigidbody.angularVelocity.x,angularY, rigidbody.angularVelocity.z);


    }
}
