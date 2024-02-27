using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            if (Time.timeScale == 1)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;
            }

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
    

