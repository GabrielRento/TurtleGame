using UnityEngine;
using TMPro;

public class Lettuce : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public static int count = 0;
    public int maxCount = 1;

    public TextMeshProUGUI counterText;

    void Start()
    {
        counterText.text = "Lettuce: " + count + "/" + maxCount;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (count < maxCount)
            {
                count++;
                counterText.text = "Lettuce: " + count + "/" + maxCount;
            }

            Destroy(gameObject);
        }
    }
}