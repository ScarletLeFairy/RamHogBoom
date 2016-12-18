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
        CheckForOtherPlayers();


    }

    void OnTriggerEnter(Collider other)
    {
        if (owner != null)
        {
            // already picked by another player
        } else
        {
            // pick up ball
            Debug.Log("Picked up ball");
            owner = other.gameObject;            
            owner.GetComponent<PlayerControllerAdv>().PickUpBall(gameObject);
        }


        //if (ball != null)
        //{
        //    // already picked up the ball 
        //    Debug.Log("");
        //}
        //else
        //{
        //    Type type = other.transform.root.gameObject.GetType();
        //    if (oth == SceneDirector.Ball)
        //    {
        //        ball = SceneDirector.Ball; // wenn trigger von Ball dann Ball aufheben   
        //        ball.GetComponent<BallBehaviour>().Owner = gameObject;
        //    }
        //    else
        //    {
        //        // other object, maybe another player

        //    }
        //}
    }

    void OnTriggerExit()
    {
        owner = null;
    }

    private void CheckForOtherPlayers()
    {
        // check if any players of same faction are near
        

    }

}
