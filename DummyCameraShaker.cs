using UnityEngine;

public class DummyCameraShaker : MonoBehaviour
{
    [Header("X Axis shaking")]
    [SerializeField] private float xAmplitude;
    [SerializeField] private float xFrequency;
    [SerializeField] private float xDephasing; 
    [SerializeField] private float xDamping;

    [Header("Y Axis shaking")]
    [SerializeField] private float yAmplitude;
    [SerializeField] private float yFrequency;
    [SerializeField] private float yDephasing;
    [SerializeField] private float yDamping;

    [Header("Z Axis shaking")]
    [SerializeField] private float zAmplitude;
    [SerializeField] private float zFrequency;
    [SerializeField] private float zDephasing;
    [SerializeField] private float zDamping;

    [Header("X Axis rotation shaking")]
    [SerializeField] private float xRotAmplitude;
    [SerializeField] private float xRotFrequency;
    [SerializeField] private float xRotDephasing;
    [SerializeField] private float xRotDamping;

    [Header("Y Axis rotation shaking")]
    [SerializeField] private float yRotAmplitude;
    [SerializeField] private float yRotFrequency;
    [SerializeField] private float yRotDephasing;
    [SerializeField] private float yRotDamping;

    [Header("Z Axis rotation shaking")]
    [SerializeField] private float zRotAmplitude;
    [SerializeField] private float zRotFrequency;
    [SerializeField] private float zRotDephasing;
    [SerializeField] private float zRotDamping;

    [Header("Time properties")]
    [SerializeField] private float shakeTime;
    [SerializeField] private float timeToFade;

    public void Shake()
    {
        if (zAmplitude == 0 && xRotAmplitude == 0 && yRotAmplitude == 0)
        {
            CameraShaker.Shake(xAmplitude, xFrequency, xDephasing, xDamping,
                               yAmplitude, yFrequency, yDephasing, yDamping,
                               zRotAmplitude, zRotFrequency, zRotDephasing, zRotDamping,
                               shakeTime, timeToFade);
        }

        else
        {
            CameraShaker.Shake(xAmplitude, xFrequency, xDephasing, xDamping,
                               yAmplitude, yFrequency, yDephasing, yDamping,
                               zAmplitude, zFrequency, zDephasing, zDamping,
                               xRotAmplitude, xRotFrequency, xRotDephasing, xRotDamping,
                               yRotAmplitude, yRotFrequency, yRotDephasing, yRotDamping,
                               zRotAmplitude, zRotFrequency, zRotDephasing, zRotDamping,
                               shakeTime, timeToFade);
        }
    }
}
