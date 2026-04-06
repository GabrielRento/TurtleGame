using UnityEngine;
using TMPro;

public class Bush : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public static int count = 0;
    public int maxCount = 1;

    public TextMeshProUGUI counterText;

    void Start()
    {
        counterText.text = "Bush: " + count + "/" + maxCount;
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (count < maxCount)
            {
                count++;
                counterText.text = "Bush: " + count + "/" + maxCount;
            }

            Destroy(gameObject);
        }
    }
}