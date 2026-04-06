using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    public TextMeshProUGUI defeatText;
    public TextMeshProUGUI winText;

    private float yRotation;
    private bool finished = false;

    void Start()
    {
    defeatText.gameObject.SetActive(false);
    winText.gameObject.SetActive(false);

    Grass.count = 0;
    Lettuce.count = 0;
    Bush.count = 0;
    }

    void Update()
    {
        HandleMovement();
        CheckWinCondition();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        yRotation += horizontal * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        float rad = yRotation * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Sin(rad), 0f, Mathf.Cos(rad));

        transform.position += direction * vertical * speed * Time.deltaTime;
    }

    void CheckWinCondition()
    {
        if (finished) return;

        if (Grass.count >= 1 &&
            Lettuce.count >= 1 &&
            Bush.count >= 1)
        {
            finished = true;
            winText.gameObject.SetActive(true);
            StartCoroutine(RestartScene());
        }
    }

        void CheckDefeatCondition(Collider other)
    {
        finished = true;
        Destroy(other.gameObject);
        defeatText.gameObject.SetActive(true);
        StartCoroutine(RestartScene());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mushroom") && !finished)
        {
            CheckDefeatCondition(other);
        }
    }
    
    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}