using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ForceSlider : MonoBehaviour
{
    public Slider forceSlider;
    
    float minValue = 0f;
    float maxValue = 1f;
    float speed = 2f;

    bool isIncreasing = true;
    bool isRunning = true;

    bool animate = true;
    IEnumerator coroutine;

    public static float currentValue;

    public delegate void onForceSet();

    public static onForceSet onforceset;

    private void Start()
    {
        coroutine = AnimateForceBar();
        StartCoroutine(coroutine);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRunning = !isRunning;

            if(isRunning)
            {
                StartCoroutine(coroutine);
            }
            else
            {
                StopCoroutine(coroutine);
            }

            currentValue = forceSlider.value;
            Strikeforce.magnitude = currentValue;
            onforceset?.Invoke();
            Debug.Log("Current Value = " + currentValue);
            gameObject.SetActive(false);
            
        }
    }

    private IEnumerator AnimateForceBar()
    {
        while(animate)
        {
            if (isIncreasing)
            {
                forceSlider.value += Time.deltaTime * speed;

                if (forceSlider.value >= maxValue)
                    isIncreasing = false;
            }
            else
            {
                forceSlider.value -= Time.deltaTime * speed;

                if (forceSlider.value <= minValue)
                    isIncreasing = true;
            }
            yield return null;
        }
    }
}
