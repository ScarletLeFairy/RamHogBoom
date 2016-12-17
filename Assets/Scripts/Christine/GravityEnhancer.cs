using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityEnhancer : MonoBehaviour
{

    struct Push
    {
        public Vector3 direction;
        public float force;
        public float time;
    }

    List<Push> forces = new List<Push>();

    private Rigidbody _rigidbody;
    public Rigidbody rb
    {
        get
        {
            if (!GetComponent<Rigidbody>())
            {
                _rigidbody = gameObject.AddComponent<Rigidbody>();
            }
            else
            {
                _rigidbody = gameObject.GetComponent<Rigidbody>();
            }

            _rigidbody.useGravity = false;
            _rigidbody.mass = mass;

            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            return _rigidbody;
        }
    }

    public bool gravity = false;
    Vector3 direction = new Vector3(0, -1, 0);

    public float mass = 1;


    float _gravity = 9.81f;

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        forces = new List<Push>();
    }

    public void AddForce(Vector3 direction, float force, float time)
    {
        Push push = new Push
        {
            direction = direction,
            force = force,
            time = Time.time + time
        };
        forces.Add(push);
    }

    void FixedUpdate()
    {

        List<Push> remove = new List<Push>();
        foreach (Push push in forces)
        {
            // Debug.Log (Time.time + " " + push.time);
            if (Time.time <= push.time)
            {
                //Debug.Log ("Execute");
                rb.AddForce(push.direction.x * push.force * _gravity, push.direction.y * push.force * _gravity, push.direction.z * push.force * _gravity);
            }
            else
            {
                //Debug.Log ("Done");
                remove.Add(push);
            }
        }

        foreach (Push push in remove)
        {
            forces.Remove(push);
        }

        if (gravity)
        {
            rb.AddForce(_gravity * direction.x, _gravity * direction.y, _gravity * direction.z, ForceMode.Acceleration);
            //rigidbody.AddForce( 0, -_gravity , 0, ForceMode.Acceleration);
        }
    }

}
