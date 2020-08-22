using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private float xAmplitude;                   //Amplitude of shaking on the X axis
    private float xFrequency;                   //Frequency of shaking on the X axis
    private float xDephasing;                   //Dephasing of shaking on the X axis
    private float xDamping;                     //Damping of shaking on the X Axis

    private float yAmplitude;                   //Amplitude of shaking on the Y axis
    private float yFrequency;                   //Frequency of shaking on the Y axis
    private float yDephasing;                   //Dephasing of shaking on the X axis
    private float yDamping;                     //Damping of shaking on the Y Axis

    private float zRotAmplitude;                //Amplitude of shaking around the Z axis
    private float zRotFrequency;                //Frequency of shaking around the Z axis
    private float zRotDephasing;                //Dephasing of shaking around the Z axis
    private float zRotDamping;                  //Damping of shaking around the Z Axis

    private float cShakeTime;                   //Number of seconds the camera will be shaking

    private float cTimeToFade;                  //Number of seconds before the Damping effects takes place
    private bool fadeTimeOut;                   //Utility bool, becomes true when the counter to fade gets to zero

    private float timePassed;                   //Utility float, used to vary the values on the sin functions

    public static CameraShaker Instance;        //Instance of the script

    private void Awake()
    {
        if(!Instance)
            Instance = this;
    }

    private void Update()
    {
        if (cShakeTime > 0f)
        {
            float xRed = 0f;
            float yRed = 0f;
            float zRotRed = 0f;

            if(cTimeToFade <= 0f)
            {
                if (!fadeTimeOut)
                    timePassed = 0f;

                fadeTimeOut = true;

                xRed = xDamping;
                yRed = yDamping;
                zRotRed = zRotDamping;
            }

            else
            {
                cTimeToFade -= Time.deltaTime;
            }

            float xShaking = xAmplitude * Mathf.Exp(-1f * xRed * timePassed) * Mathf.Sin(Mathf.Sqrt(xFrequency * xFrequency - xRed * xRed) * timePassed + xDephasing);
            float yShaking = yAmplitude * Mathf.Exp(-1f * yRed * timePassed) * Mathf.Sin(Mathf.Sqrt(yFrequency * yFrequency - yRed * yRed) * timePassed + yDephasing);
            float zRotShaking = zRotAmplitude * Mathf.Exp(-1f * zRotRed * timePassed) * Mathf.Sin(Mathf.Sqrt(zRotFrequency * zRotFrequency - zRotRed * zRotRed) * timePassed + zRotDephasing);

            transform.localPosition = new Vector3(xShaking, yShaking);
            transform.localRotation = Quaternion.Euler(0f, 0f, zRotShaking);

            cShakeTime -= Time.deltaTime;

            timePassed += Time.deltaTime;
        }

        else
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);

            xAmplitude = 0f;
            xFrequency = 0f;
            xDephasing = 0f;
            xDamping = 0f;

            yAmplitude = 0f;
            yFrequency = 0f;
            yDephasing = 0f;
            yDamping = 0f;

            zRotAmplitude = 0f;
            zRotFrequency = 0f;
            zRotDephasing = 0f;
            zRotDamping = 0f;

            cShakeTime = 0f;

            cTimeToFade = 0f;
            fadeTimeOut = false;

            timePassed = 0f;
        }   
    }

    public static void Shake(float xAmp, float xFreq, float xDeph, float xRed, float yAmp, float yFreq, float yDeph, float yRed, float zRotAmp, float zRotFreq, float zRotDeph, float zRotRed, float shakeTime, float timeToFade)
    {
        Instance.xAmplitude = xAmp;
        Instance.xDephasing = xDeph;
        Instance.xFrequency = xFreq;
        Instance.xDamping = xRed;

        Instance.yAmplitude = yAmp;
        Instance.yFrequency = yFreq;
        Instance.yDephasing = yDeph;
        Instance.yDamping = yRed;

        Instance.zRotAmplitude = zRotAmp;
        Instance.zRotFrequency = zRotFreq;
        Instance.zRotDephasing = zRotDeph;
        Instance.zRotDamping = zRotRed;

        Instance.cShakeTime = shakeTime;

        Instance.cTimeToFade = Mathf.Clamp(timeToFade, 0f, Instance.cShakeTime);
        Instance.fadeTimeOut = false;

        Instance.timePassed = 0f;
    }
}
