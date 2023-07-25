using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateKoopaTroopa : MonoBehaviour
{
    public GameObject koopaTroopa;
    public float runSpeed = 3f;
    public float turnSpeed = 90f;
    GameObject[] obj;
    bool[] changeDirection;
    int[] direction;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL1")
        {
            obj = new GameObject[4];
            direction = new int[4];
            changeDirection = new bool[4];
            for (int i = 0; i < obj.Length; ++i)
            {
                changeDirection[i] = false;
                direction[i] = 0;
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(koopaTroopa, new Vector3(-4f + i, 0.5f, 70f - i * 5), koopaTroopa.transform.rotation);
                else obj[i] = (GameObject)Instantiate(koopaTroopa, new Vector3(4f - (i - 1), 0.5f, 70f - (i - 1) * 5), koopaTroopa.transform.rotation);
                obj[i].transform.parent = transform;
                transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("IsFloating", true);
            }
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL1")
        {
            for (int i = 0; i < obj.Length; ++i)
            {
                if (changeDirection[i])
                {
                    if (direction[i] == 0)
                    {
                        if (obj[i].transform.rotation.eulerAngles.y >= 180) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                        else
                        {
                            changeDirection[i] = false;
                            direction[i] = 1;
                        }
                    }
                    else
                    {
                        if (obj[i].transform.rotation.eulerAngles.y < 180) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                        else
                        {
                            changeDirection[i] = false;
                            direction[i] = 0;
                        }
                    }
                }
                else
                {
                    if (direction[i] == 0)
                    {
                        if (obj[i].transform.position.z > 32f) obj[i].transform.Translate(-transform.forward * runSpeed * Time.deltaTime, Space.World);
                        else changeDirection[i] = true;
                    }
                    else if (direction[i] == 1)
                    {
                        if (obj[i].transform.position.z < 70f) obj[i].transform.Translate(transform.forward * runSpeed * Time.deltaTime, Space.World);
                        else changeDirection[i] = true;
                    }
                }
            }
        }

    }
}
