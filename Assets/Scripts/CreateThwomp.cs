using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateThwomp : MonoBehaviour
{
    public GameObject thwomp;
    GameObject[] obj;
    public float fallSpeed = 4f;
    int[] direction;
    public AudioClip soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        direction = new int[6];

        if (SceneManager.GetActiveScene().name == "LEVEL1")
        {
            obj = new GameObject[2];
            for (int i = 0; i < 2; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(thwomp, new Vector3(-2.2f, 3f, 75f), thwomp.transform.rotation);
                else obj[i] = (GameObject)Instantiate(thwomp, new Vector3(2.2f, 3f, 75f), thwomp.transform.rotation);
                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL2")
        {
            obj = new GameObject[4];
            for (int i = 0; i < 4; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(thwomp, new Vector3(-7.0f, 5.0f, 21.0f + i * 12.5f), thwomp.transform.rotation);
                else obj[i] = (GameObject)Instantiate(thwomp, new Vector3(7.0f, 5.0f, 21.0f + (i - 1) * 12.5f), thwomp.transform.rotation);
                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL3") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL4")
        {
            obj = new GameObject[6];
            for (int i = 0; i < 6; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(thwomp, new Vector3(-1.5f - 2 * i, 3f, 80f), thwomp.transform.rotation);
                else obj[i] = (GameObject)Instantiate(thwomp, new Vector3(2 * i, 0f, 80f), thwomp.transform.rotation);
                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL5") { }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < obj.Length; ++i)
        {
            if (direction[i] == 0)
            {
                if (obj[i].transform.position.y > 0) obj[i].transform.Translate(-transform.up * fallSpeed * Time.deltaTime, Space.World);
                else
                {
                    //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                    direction[i] = 1;
                }
            }
            else
            {
                if (obj[i].transform.position.y < 3) obj[i].transform.Translate(transform.up * fallSpeed / 2 * Time.deltaTime, Space.World);
                else direction[i] = 0;
            }
        }
    }
}
