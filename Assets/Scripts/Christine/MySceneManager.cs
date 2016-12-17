using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

    public const string MENU_SCENE = "Menu";
    public const string LOBBY_SCENE = "Lobby";
    public const string PLAY_SCENE = "Play";
    public const string WIN_SCENE = "Win";
    public const string RESUME_SCENE = "Resume";
    public const string SETTINGS_SCENE = "Settings";

    private Scene current;

    // Use this for initialization
    void Start () {
        current = SceneManager.GetActiveScene();

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            changeScene();
        }
    }

    public void changeScene()
    {
        string nextScene = current.name;
        //if (current.name == "Test1")
        //{
        //    nextScene = "Test2";
        //} else
        //{
        //    nextScene = "Test1";
        //}

        //SceneManager.LoadScene(nextScene, LoadSceneMode.Single); // use single mode 
        if (getButtonA())
        {
            switch (current.name)
            {
                case MENU_SCENE:
                    nextScene = LOBBY_SCENE;                    
                    break;

                case LOBBY_SCENE:
                    nextScene = PLAY_SCENE;                    
                    break;

                case PLAY_SCENE:
                    nextScene = WIN_SCENE;                    
                    break;

                case WIN_SCENE:
                    nextScene = MENU_SCENE;
                    break;
            }
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
        



    }

    private bool getStartButton()
    {
        return Input.GetKeyDown(KeyCode.JoystickButton7);
    }

    private bool getButtonA()
    {
        return Input.GetKeyDown(KeyCode.JoystickButton0);
    }
}
