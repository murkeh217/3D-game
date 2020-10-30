using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text highscore;


    //starts game
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SphereCollider>() != null)
        {
            SphereController sphereController = other.gameObject.GetComponent<SphereController>();
            SceneManager.LoadScene(0);
        }
    }
    void Awake()
    {
        highscore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore",0).ToString();
    }

  

}
