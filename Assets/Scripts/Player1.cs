using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1 : MonoBehaviour {

    public AudioClip whineSound;
    public AudioClip coinSound;

    public float runSpeed = 7f;
    public float turnSpeed = 180f;
    public float jumpHeight = 5f;
    public Rigidbody rb;
    bool isRunning;
    bool isGrounded;
    bool godMode;
    bool restart;
    static public bool winner;
    Vector3 lastCheckpointPosition;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
     };

    private void OnTriggerEnter(Collider col) {
        if ((col.gameObject.tag == "Enemy" || (col.gameObject.tag == "Water") || (col.gameObject.tag == "Hammer")) && !godMode) restart = true;
        if (col.gameObject.tag == "Odyssey") winner = true;
        if (col.gameObject.tag == "Coin")
        {
            runSpeed = runSpeed + 0.1f;
            Destroy(col.gameObject);
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 0.15f);
        }
        if(col.gameObject.tag == "Hammer") Destroy(col.gameObject);
        if (col.gameObject.tag == "Bullet" && !godMode) restart = true;
        if(col.gameObject.tag == "Checkpoint") lastCheckpointPosition = col.gameObject.transform.position + new Vector3(2f,-2f,0f);
    }

    private void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Ground" || col.gameObject.tag == "Odyssey") isGrounded = true;
    }

    public float getPlayerZ() {
        return transform.position.z;
    }

    static public bool isWinner() {
        return winner;
    }

    static public void setIsWinner(bool isWinner)
    {
        winner = isWinner;
    }

    // Start is called before the first frame update
    void Start() {
        isRunning = false;
        isGrounded = true;
        godMode = false;
        restart = false;
        winner = false;
        lastCheckpointPosition = new Vector3(-3f, -0.3f, 4f);
    }

    // Update is called once per frame
    void Update(){
        if (SceneManager.GetActiveScene().name == "LEVEL5") jumpHeight = 7f;
        else jumpHeight = 5f;

        for (int i = 1; i <= 5; ++i) {
            if (Input.GetKeyDown(keyCodes[i - 1]))
                SceneManager.LoadScene("LEVEL" + i);
        }

        if (Input.GetKeyDown(KeyCode.G)) godMode = !godMode;
        if (restart) {
            transform.position = lastCheckpointPosition;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            AudioSource.PlayClipAtPoint(whineSound, transform.position);
            restart = false;
        }

        isRunning = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        gameObject.GetComponent<Animator>().SetBool("IsRunning", isRunning);
        gameObject.GetComponent<Animator>().SetBool("IsJumping", !isGrounded);

        if(!isRunning) rb.angularVelocity = Vector3.zero;

            foreach (Camera c in Camera.allCameras) {
            if (c.gameObject.name == "Player1MainCamera") {
                c.transform.position = transform.position + new Vector3(0f, 3f, -4f);
                if (Input.GetKey(KeyCode.Q)) c.depth = -1;
                else c.depth = 1;
            }
            else if (c.gameObject.name == "Player1SecondCamera") c.transform.position = transform.position + new Vector3(0f, 4f, 5f);
        }

        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, 1f, 0f) * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.W)) transform.Translate(transform.forward * runSpeed * Time.deltaTime, Space.World);
        else if (Input.GetKey(KeyCode.S)) transform.Translate(-transform.forward * runSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A)) transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
        else if (Input.GetKey(KeyCode.D)) transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
    }
}