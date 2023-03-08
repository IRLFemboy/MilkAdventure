using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables

    public Rigidbody2D rig;
    public BoxCollider2D box;
    public Animator ani;
    
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;

    public GameObject pickup;
    public Item selectedItem;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float input = Input.GetAxis("Horizontal");
        transform.Translate(input * moveSpeed * Time.deltaTime * Vector2.right);
        if (input < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Bounce(Vector2.up, jumpForce);
            isGrounded = false;
        }
        // Pick Up Item
        if (Input.GetKeyDown(KeyCode.F) && pickup != null && ItemManager.Instance.Items.Count < ItemManager.Instance.itemLimit)
        {
            ItemManager.Instance.AddItem(pickup.GetComponent<ItemPickup>().item);
            Destroy(pickup);
        }
        else if (Input.GetKeyDown(KeyCode.F) && pickup != null && ItemManager.Instance.Items.Count >= ItemManager.Instance.itemLimit)
        {
            // EXTREMELY LOUD INCORRECT BUZZER SOUND
        }
        // Drop Item
        if (Input.GetKeyDown(KeyCode.R) && selectedItem != null)
        {
            Instantiate(selectedItem.entity, gameObject.transform);
            ItemManager.Instance.RemoveItem(selectedItem);
        }
        // Switch selected item
        if (Input.GetKeyDown(KeyCode.Alpha1) && ItemManager.Instance.Items.Count >= 1)
        {
            selectedItem = ItemManager.Instance.Items[0];
        }
        for (int i = 0; i < 10; ++i)
        {
            if (Input.GetKeyDown("" + i))
            {
                selectedItem = ItemManager.Instance.Items[i - 1];
            }
        }
    }
    public void Bounce(Vector2 direction, float power)
    {
        rig.AddForce(direction * power, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for ground connection to reset jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
