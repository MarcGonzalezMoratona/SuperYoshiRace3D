using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateBulletBills : MonoBehaviour
{

    public GameObject bulletBill;
    public float runSpeed = 8f;
    GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL1") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL2")
        {
            obj = new GameObject[6];
            for (int i = 0; i < 6; ++i)
            {
                if (i % 2 == 0)
                {
                    obj[i] = (GameObject)Instantiate(bulletBill, new Vector3(-7.2f - i * 1.3f, 0.7f, 93.4f), bulletBill.transform.rotation);
                    obj[i].transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
                    obj[i].transform.Rotate(0, 90, 0);
                }
                else
                {

                    obj[i] = (GameObject)Instantiate(bulletBill, new Vector3(7.2f + (i - 1) * 1.3f, 0.7f, 93.4f), bulletBill.transform.rotation);
                    obj[i].transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
                    obj[i].transform.Rotate(0, 90, 0);
                }

                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL3") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL4") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL5")
        {
            obj = new GameObject[12];
            for (int i = 0; i < obj.Length; ++i)
            {
                if (i % 2 == 0)
                {
                    if (i < 6) obj[i] = (GameObject)Instantiate(bulletBill, new Vector3(-16.75f + 5 * i, 0.75f, 66.5f + i * 5), bulletBill.transform.rotation);
                    else if (i < 12) obj[i] = (GameObject)Instantiate(bulletBill, new Vector3(-21.75f + 5 * (i - 6), 0.75f, 66.5f + (i - 6) * 5), bulletBill.transform.rotation);
                    obj[i].transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
                }
                else
                {
                    if (i < 6) obj[i] = (GameObject)Instantiate(bulletBill, new Vector3(16.75f + 5 * (i - 1), 0.75f, 66.5f + (i - 1) * 5), bulletBill.transform.rotation);
                    else if (i < 12) obj[i] = (GameObject)Instantiate(bulletBill, new Vector3(21.75f + 5 * (i - 7), 0.75f, 66.5f + (i - 7) * 5), bulletBill.transform.rotation);
                    obj[i].transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
                    obj[i].transform.Rotate(0, 180, 0);
                }
                obj[i].transform.parent = transform;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL5")
        {

            for (int i = 0; i < obj.Length; ++i)
            {

                if (i % 2 == 0)
                {

                    if (obj[i].transform.position.x > 0)
                    {
                       
                        if (i < 6) obj[i].transform.position = new Vector3(-16.75f, 0.75f, 66.5f + i * 5);
                        else obj[i].transform.position = new Vector3(-16.75f, 0.75f, 66.5f + (i - 6) * 5);
                    }
                    obj[i].transform.Translate(transform.right * runSpeed * Time.deltaTime, Space.World);
                }
                else
                {
                    if (obj[i].transform.position.x < 0)
                    {
                        if (i < 6) obj[i].transform.position = new Vector3(16.75f, 0.75f, 66.5f + (i - 1) * 5);
                        else obj[i].transform.position = new Vector3(16.75f, 0.75f, 66.5f + (i - 7) * 5);
                    }
                    obj[i].transform.Translate(-transform.right * runSpeed * Time.deltaTime, Space.World);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL2")
        {
        for (int i = 0; i < 6; ++i)
            {
                if (obj[i].transform.position.z < 66)
                {
                    if (i % 2 == 0) obj[i].transform.position = new Vector3(-7.2f - i * 1.3f, 0.7f, 93.44f);
                    else obj[i].transform.position = new Vector3(7.2f + (i - 1) * 1.3f, 0.7f, 93.44f);
                }
                obj[i].transform.Translate(-transform.forward * (runSpeed + (0.5f * i)) * Time.deltaTime, Space.World);
            }
        }
    }
}
