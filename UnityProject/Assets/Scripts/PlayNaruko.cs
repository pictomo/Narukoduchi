using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayNaruko : MonoBehaviour
{
    float time = 0f;
    bool isGame = false;
    int count = 0;
    public GameObject[] Instruments;
    List<GameObject> objects = new List<GameObject>(); // 生成した楽器を格納する配列 未実装
    public GameObject startButton;
    public TMP_Text text;
    public GameObject pressN;
    public GameObject resultCanvas;
    public GameObject resultText;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGame)
        {
            time += Time.deltaTime;
            if (time >= 10f)
            {
                isGame = false;
                startButton.gameObject.SetActive(true);
                pressN.gameObject.SetActive(false);
                // text = GameObject.Find("Result").GetComponent<TMP_Text>();
                // text.text = "Result: " + count;

                resultCanvas.SetActive(true);
                resultText.GetComponent<TMP_Text>().text = count.ToString();
            }
            if (Input.GetKeyDown(KeyCode.N) || Input.GetMouseButtonDown(0))
            {
                count++;
                text.text = "Count: " + count;
                audioSource.Play();
                GameObject obj = Instantiate(Instruments[Random.Range(0, 5)], new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-6f, 1f)), Quaternion.identity * new Quaternion(0, 180, 0, 0));
                Debug.Log("hoge");
                if (obj)
                {
                    objects.Add(obj);
                }

                transform.rotation = Quaternion.Euler(20, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.N) || Input.GetMouseButtonUp(0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void OnStart()
    {
        objects.ForEach(Destroy);
        startButton.gameObject.SetActive(false);
        pressN.gameObject.SetActive(true);
        count = 0;
        text.text = "Count: " + count;
        time = 0;
        isGame = true;
    }

    public void OnResultExit()
    {
        resultCanvas.SetActive(false);
        resultText.GetComponent<TMP_Text>().text = "0";
    }
}
