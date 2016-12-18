using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {

    private GameObject owner;
    public GameObject Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    private Animator anim;
    private AnimatorStateInfo currentBaseState;


    public float radius = 3;    // radius to check for the explosion

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (owner != null)
        {
            CheckForOtherPlayers();
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
                owner = other.gameObject;
                owner.GetComponent<Player>().PickUpBall(gameObject);
                Debug.Log("Picked up ball " + owner);
                anim.SetBool("fly", false);

            }

        }
    }

    public void GetThrown()
    {
        owner = null;
        anim.SetBool("fly", true);
    }

    private void CheckForOtherPlayers()
    {
        // check if any players of same faction are near
        
        // TODO
    }

}
