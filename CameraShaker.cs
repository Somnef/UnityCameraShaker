using UnityEngine;

//Camera shaking effect class, simulates a damped oscillating effect on the object it is put on
//NOTE: In order for this to work, the gameobject's transform's local position should be at (0f, 0f, 0f), if the object is meant to move, it should rest in a parent object that moves, while the one holding this script sits at (0f, 0f, 0f)
public class CameraShaker : MonoBehaviour
{
    private float xAmplitude;                   //Amplitude of shaking on the X axis
    private float xFrequency;                   //Frequency of shaking on the X axis
    private float xDephasing;                   //Dephasing of shaking on the X axis
    private float xDamping;                     //Damping of shaking on the X Axis

    private float yAmplitude;                   //Amplitude of shaking on the Y axis
    private float yFrequency;                   //Frequency of shaking on the Y axis
    private float yDephasing;                   //Dephasing of shaking on the Y axis
    private float yDamping;                     //Damping of shaking on the Y Axis

    private float zAmplitude;                   //Amplitude of shaking on the Z axis
    private float zFrequency;                   //Frequency of shaking on the Z axis
    private float zDephasing;                   //Dephasing of shaking on the Z axis
    private float zDamping;                     //Damping of shaking on the Z Axis

    private float xRotAmplitude;                //Amplitude of shaking around the X axis
    private float xRotFrequency;                //Frequency of shaking around the X axis
    private float xRotDephasing;                //Dephasing of shaking around the X axis
    private float xRotDamping;                  //Damping of shaking around the X Axis

    private float yRotAmplitude;                //Amplitude of shaking around the Y axis
    private float yRotFrequency;                //Frequency of shaking around the Y axis
    private float yRotDephasing;                //Dephasing of shaking around the Y axis
    private float yRotDamping;                  //Damping of shaking around the Y Axis

    private float zRotAmplitude;                //Amplitude of shaking around the Z axis
    private float zRotFrequency;                //Frequency of shaking around the Z axis
    private float zRotDephasing;                //Dephasing of shaking around the Z axis
    private float zRotDamping;                  //Damping of shaking around the Z Axis

    private float cShakeTime;                   //Number of seconds the camera will be shaking

    private float cTimeToFade;                  //Number of seconds before the Damping effects takes place
    private bool fadeTimeOut;                   //Utility bool, becomes true when the counter to fade gets to zero

    private bool shake3d;                       //Utility bool, checks whether the shaking should happen on a plane or in space

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
            float xDamp = 0f;
            float yDamp = 0f;
            float zRotDamp = 0f;

            //3D shaking variables
            float zDamp = 0f;
            float xRotDamp = 0f;
            float yRotDamp = 0f;

            if(cTimeToFade <= 0f)
            {
                if (!fadeTimeOut)
                {
                    xDephasing += Mathf.Sin(Mathf.Sqrt(xFrequency * xFrequency - xDamp * xDamp) * timePassed);
                    yDephasing += Mathf.Sin(Mathf.Sqrt(yFrequency * yFrequency - yDamp * yDamp) * timePassed);
                    zRotDephasing += Mathf.Sin(Mathf.Sqrt(zRotFrequency * zRotFrequency - zRotDamp * zRotDamp) * timePassed);

                    if(shake3d)
                    {
                        zDephasing += Mathf.Sin(Mathf.Sqrt(zFrequency * zFrequency - zDamp * zDamp) * timePassed);
                        xRotDephasing += Mathf.Sin(Mathf.Sqrt(xRotFrequency * xRotFrequency - xRotDamp * xRotDamp) * timePassed);
                        yRotDephasing += Mathf.Sin(Mathf.Sqrt(yRotFrequency * yRotFrequency - yRotDamp * yRotDamp) * timePassed);
                    }

                    timePassed = 0f;
                }

                fadeTimeOut = true;

                xDamp = xDamping;
                yDamp = yDamping;
                zRotDamp = zRotDamping;

                if(shake3d)
                {
                    zDamp = zDamping;
                    xRotDamp = xRotDamping;
                    yRotDamp = yRotDamping;
                }
            }

            else
            {
                cTimeToFade -= Time.deltaTime;
            }

            float xShaking = xAmplitude * Mathf.Exp(-1f * xDamp * timePassed) * Mathf.Sin(Mathf.Sqrt(xFrequency * xFrequency - xDamp * xDamp) * timePassed + xDephasing);
            float yShaking = yAmplitude * Mathf.Exp(-1f * yDamp * timePassed) * Mathf.Sin(Mathf.Sqrt(yFrequency * yFrequency - yDamp * yDamp) * timePassed + yDephasing);
            float zRotShaking = zRotAmplitude * Mathf.Exp(-1f * zRotDamp * timePassed) * Mathf.Sin(Mathf.Sqrt(zRotFrequency * zRotFrequency - zRotDamp * zRotDamp) * timePassed + zRotDephasing);

            float zShaking = 0f;
            float xRotShaking = 0f;
            float yRotShaking = 0f;

            if(shake3d)
            {
                zShaking = zAmplitude * Mathf.Exp(-1f * zDamp * timePassed) * Mathf.Sin(Mathf.Sqrt(zFrequency * zFrequency - zDamp * zDamp) * timePassed + zDephasing);
                xRotShaking = xRotAmplitude * Mathf.Exp(-1f * xRotDamp * timePassed) * Mathf.Sin(Mathf.Sqrt(xRotFrequency * xRotFrequency - xRotDamp * xRotDamp) * timePassed + xRotDephasing);
                yRotShaking = yRotAmplitude * Mathf.Exp(-1f * yRotDamp * timePassed) * Mathf.Sin(Mathf.Sqrt(yRotFrequency * yRotFrequency - yRotDamp * yRotDamp) * timePassed + yRotDephasing);
            }

            transform.localPosition = new Vector3(xShaking, yShaking, zShaking);
            transform.localRotation = Quaternion.Euler(xRotShaking, yRotShaking, zRotShaking);

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

            zAmplitude = 0f;
            zFrequency = 0f;
            zDephasing = 0f;
            zDamping = 0f;

            xRotAmplitude = 0f;
            xRotFrequency = 0f;
            xRotDephasing = 0f;
            xRotDamping = 0f;

            yRotAmplitude = 0f;
            yRotFrequency = 0f;
            yRotDephasing = 0f;
            yRotDamping = 0f;

            zRotAmplitude = 0f;
            zRotFrequency = 0f;
            zRotDephasing = 0f;
            zRotDamping = 0f;

            cShakeTime = 0f;

            cTimeToFade = 0f;
            fadeTimeOut = false;

            shake3d = false;

            timePassed = 0f;
        }   
    }

    //Initializes all the necessary values for the 2D shaking, it should start automatically whenever the cShakeTime variable is set to above 0
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

        Instance.shake3d = false;
    }

    //Initializes all the necessary values for the 3D shaking, it should start automatically whenever the cShakeTime variable is set to above 0
    public static void Shake(float xAmp, float xFreq, float xDeph, float xRed, float yAmp, float yFreq, float yDeph, float yRed, float zAmp, float zFreq, float zDeph, float zRed, float xRotAmp, float xRotFreq, float xRotDeph, float xRotRed, float yRotAmp, float yRotFreq, float yRotDeph, float yRotRed, float zRotAmp, float zRotFreq, float zRotDeph, float zRotRed, float shakeTime, float timeToFade)
    {
        Instance.xAmplitude = xAmp;
        Instance.xDephasing = xDeph;
        Instance.xFrequency = xFreq;
        Instance.xDamping = xRed;

        Instance.yAmplitude = yAmp;
        Instance.yFrequency = yFreq;
        Instance.yDephasing = yDeph;
        Instance.yDamping = yRed;

        Instance.zAmplitude = zAmp;
        Instance.zFrequency = zFreq;
        Instance.zDephasing = zDeph;
        Instance.zDamping = zRed;

        Instance.xRotAmplitude = xRotAmp;
        Instance.xRotFrequency = xRotFreq;
        Instance.xRotDephasing = xRotDeph;
        Instance.xRotDamping = xRotRed;

        Instance.yRotAmplitude = yRotAmp;
        Instance.yRotFrequency = yRotFreq;
        Instance.yRotDephasing = yRotDeph;
        Instance.yRotDamping = yRotRed;

        Instance.zRotAmplitude = zRotAmp;
        Instance.zRotFrequency = zRotFreq;
        Instance.zRotDephasing = zRotDeph;
        Instance.zRotDamping = zRotRed;

        Instance.cShakeTime = shakeTime;

        Instance.cTimeToFade = Mathf.Clamp(timeToFade, 0f, Instance.cShakeTime);
        Instance.fadeTimeOut = false;

        Instance.timePassed = 0f;

        Instance.shake3d = true;
    }
}
