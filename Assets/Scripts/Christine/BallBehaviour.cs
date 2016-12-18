using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {

    private GameObject owner;
    public GameObject Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    public float radius = 3;    // radius to check for the explosion

    // Use this for initialization
    void Start()
    {

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
        } else
        {
            // pick up ball
            GameObject oth = other.gameObject;
            if (oth.GetType == Player.GetType)
            {
                owner = other.gameObject;
                owner.GetComponent<Player>().PickUpBall(gameObject);
                Debug.Log("Picked up ball " + owner);
            }
            
        }
    }

    void OnTriggerExit()
    {
        owner = null;
    }

    private void CheckForOtherPlayers()
    {
        // check if any players of same faction are near
        
        // TODO
    }

}
