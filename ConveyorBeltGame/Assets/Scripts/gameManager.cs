using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public bool gameStarted;


    [SerializeField] private List<GameObject> productPre;
    private List<GameObject> products;

    public GameObject targetProduct;
    public GameObject handForTarget;

    [SerializeField] private GameObject prodParent;

    public bool spawn;
    public GameObject spawnPoint;
    private float toNewSpawn, toSpawnDelay;

    public int conwSpeed;

    public int needToCollect, prodID, tasksLeft;
    private bool newTask;
    public List<string> prodLabels;


    public copyPosition handTarget_scr;
    public Animator AC_character;

    public Animation gameEnd;


    [SerializeField] private taskLabels taskLabels_scr;
    void Start()
    {
        conwSpeed = 4;
        toSpawnDelay = 0.7f;
        toNewSpawn = toSpawnDelay;

        tasksLeft = 5;

        gameStarted = false;
        newTask = false;

        prodLabels = new List<string> {"apples", "bananas", "oranges"};
    }

    // Update is called once per frame
    void Update()
    {
        if (newTask == true && gameStarted == true)
        {
            createNewTask();
        }

        //AC_character.SetInteger("state", 0);
        if (toNewSpawn < 0 && gameStarted == true)
        {
            GameObject product_ = Instantiate(productPre[Random.Range(0, productPre.Count)],
                new Vector3(spawnPoint.transform.position[0], spawnPoint.transform.position[1], Random.Range(spawnPoint.transform.position[2] - 2, spawnPoint.transform.position[2] + 2)),
                new Quaternion(0,0,0,0),
                prodParent.transform);

            toNewSpawn = toSpawnDelay;
            spawn = false;

            //handTarget_scr.objToCopy = product_;
        }
        else
        {
            toNewSpawn -= Time.deltaTime;
        }
    }

    private void createNewTask()
    {
        newTask = false;

        needToCollect = Random.Range(1, 5);
        prodID = Random.Range(0, productPre.Count);

        tLUpdate();

    }

    private void GameEnd()
    {
        AC_character.SetInteger("state", 2);
        //handTarget_scr.objToCopy = handForTarget;
        gameEnd.Play();
    }

    public void tLUpdate()
    {
        if (needToCollect < 1 && tasksLeft > 0)
        {
            createNewTask();
            tasksLeft -= 1;
        }
        else if (tasksLeft <= 0 && needToCollect <= 0)
        {
            GameEnd();
        }

        taskLabels_scr.canvasUpdate(prodLabels[prodID], needToCollect, tasksLeft);
    }

    public void startGame()
    {
        gameStarted = true;
        newTask = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
            //other.attachedRigidbody.AddForce(Vector3.left * 3);
            other.attachedRigidbody.velocity = Vector3.left * conwSpeed;

        if (other.CompareTag("hand") && targetProduct != null)
        {
            if (targetProduct != null)
            {
                AC_character.SetInteger("state", 1);
                targetProduct.GetComponent<copyPosition>().objToCopy = handForTarget;
                targetProduct.GetComponent<Rigidbody>().velocity = Vector3.zero;

                handTarget_scr.objToCopy = handForTarget;
            }
        }
    }

    public void raloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void closeApp()
    {
        Application.Quit();
    }
}
