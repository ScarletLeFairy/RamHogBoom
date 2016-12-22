using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {

    private GameObject previousOwner;
    public GameObject PreviousOwner
    {
        get { return previousOwner; }
        set { previousOwner = value; }
    }

    private GameObject owner;
    public GameObject Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    private Animator anim;
    private Rigidbody rigbod;


    public float radius = 3;    // radius to check for the explosion

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigbod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (owner != null)
        {
            CheckForOtherPlayers();
        }
        
    }

    public void Explode()
    {
        anim.SetTrigger("explode"); // TODO time explosion or change speed of the animation
        SFXContainer.ExplosionSFX.PlayNextSFXAtGameObject(gameObject);
        ParticleSpawner.Instance.SpawnParticleSystem(gameObject.transform, 0);
        CameraMovement shake = Camera.main.GetComponent<CameraMovement>();
        if (shake != null)
        {
            shake.ShakeCamera(0.1f, 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (owner != null)
        {
            // already picked by another player
            CheckForOtherPlayers();
        }
        else
        {
            // pick up ball
            GameObject oth = other.gameObject;
            if (oth.GetComponent<Player>() != null)
            {
                rigbod.mass = 0;
                previousOwner = null;
                owner = other.gameObject;
                owner.GetComponent<Player>().PickUpBall(gameObject);
                Debug.Log("Picked up ball " + owner);
                anim.SetBool("fly", false);

            }

        }
    }

    public void GetThrown()
    {
        rigbod.mass = 1;
        previousOwner = owner;
        owner = null;        
        anim.SetBool("fly", true);
    }

    private void CheckForOtherPlayers()
    {
        // check if any players of same faction are near

        // TODO

        if (Vector3.Distance(transform.position, player.transform.position)
                       < Vector3.Distance(transform.position, closestPlayer.transform.position))
        {
        }

}
