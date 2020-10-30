using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    public float speed;
    public Text countText;

    private int count;
    private Rigidbody rb;
    private string lastColor;
    private int streak;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        
    }
    void FixedUpdate()
    {
        //spheres movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            other.gameObject.SetActive(false);
            count = count + 20;
            SetCountText();
            

            if (lastColor == "Blue")
            {
                count = count + 20 * 2;
                streak++;
                SetCountText();
            }
            else
            {
                count += 0;
            }

            lastColor = "Blue";

        }
        if (other.gameObject.tag == "Red")
        {
            other.gameObject.SetActive(false);
            count = count + 15;
            SetCountText();
            

            if (lastColor == "Red")
            {
                count = count + 15 * 2;
                streak++;
                SetCountText();
            }
            else
            {
                count += 0;
            }

            lastColor = "Red";
        }
    }

    void SetCountText() 
    {
        countText.text = "Score: " + count.ToString() + " Streaks: " + streak.ToString();
        
    }

    private void Awake()
    {
        if (count > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", count);
        }
    }

}
