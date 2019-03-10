using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    private int count;
    private int live;
    public Text countText;
    public Text winText;
    public Text liveText;
    public GameObject view;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        live = 3;
        winText.text = "";
        SetCountText();
        SetLiveText();

    }

   

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            live = live - 1;
            SetLiveText();

        }
    }
      

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 4)
        {
            live = 3;
            transform.position = new Vector2(24f, -3f);
            view.transform.position = new Vector3(29f, 0, -10f);
        }
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }

    void SetLiveText()
    {
        liveText.text = "Lives: " + live.ToString();
        if (live <= 0)
        {
            winText.text = "You Lose!";
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
