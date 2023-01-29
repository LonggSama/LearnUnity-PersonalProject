using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float gravityModifier;
    [SerializeField] private float flyForce;

    private Rigidbody playerRb;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        fly();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }

    //Fly by click the SpaceBar
    void fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
        }
    }
}
