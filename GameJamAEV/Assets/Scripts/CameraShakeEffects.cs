using UnityEngine;
using System.Collections;

//Usar este componente para hacer un efecto shake 
public class CameraShakeEffects : MonoBehaviour
{


    public float shakeTime = 2f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 initialPosition;

   
    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraRandomly());

    }


    public void CancelShake()
    {
        //timeShaking = -1;
        StopCoroutine(ShakeCameraRandomly());
        transform.position = initialPosition;

        Destroy(this);

    }

    IEnumerator ShakeCameraRandomly()
    {
        float timeShaking = shakeTime;
        initialPosition = transform.position;

        //Debug.Log ("Entra en shakins corrutina");

        while (timeShaking > 0)
        {
            //Debug.Log ("Entra en shakins corrutina");
            transform.localPosition = Random.insideUnitSphere * shakeAmount;
            timeShaking -= Time.deltaTime * decreaseFactor;
            yield return 1;
        }
        transform.position = initialPosition;
    }
}