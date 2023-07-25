using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateHammer : MonoBehaviour
{
    public GameObject hammer;
    public float speed;
    public float timeBetweenThrows;
    public AudioClip throwSound;
    GameObject obj;

    float timeToNextThrow = 0.7f;
    float turnSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenThrows = 3.15f;
        if (SceneManager.GetActiveScene().name == "LEVEL2") speed = Random.Range(3f, 6f);
        else if (SceneManager.GetActiveScene().name == "LEVEL3") speed = Random.Range(3f, 6f);
        else if (SceneManager.GetActiveScene().name == "LEVEL5") speed = Random.Range(3f, 5f);
        obj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL2") speed = Random.Range(3f, 6f);
        else if (SceneManager.GetActiveScene().name == "LEVEL3") speed = Random.Range(3f, 6f);
        else if (SceneManager.GetActiveScene().name == "LEVEL5") speed = Random.Range(3f, 5f);
        timeToNextThrow -= Time.deltaTime;
        if (timeToNextThrow <= 0f)
        {
            timeToNextThrow = timeBetweenThrows;
            obj = Instantiate(hammer, transform.position + new Vector3(0f, 0.5f, -0.25f), transform.rotation);
            //obj.transform.localScale -= new Vector3(0.8f, 10.0f, 0.8f);
            obj.transform.Rotate(0, 90, 0);
            Quaternion rot = transform.rotation;
            if (rot[3] > 0) obj.GetComponent<Rigidbody>().velocity = new Vector3(speed, speed * 2f, 0f);
            else if (rot[3] < 0) obj.GetComponent<Rigidbody>().velocity = new Vector3(-speed, speed * 2f, 0f);
            else if (rot[3] == 0) obj.GetComponent<Rigidbody>().velocity = new Vector3(0f, speed * 2f, -speed);
            AudioSource.PlayClipAtPoint(throwSound, transform.position);
        }
        if (obj)
        {
            obj.transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
            if (obj.transform.position.y < -5) Destroy(obj);
        }
    }
}
