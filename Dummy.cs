using UnityEngine;

public class Dummy : MonoBehaviour
{
    [Header("X Axis shaking")]
    [SerializeField] private float xAmplitude = .5f;
    [SerializeField] private float xFrequency = 30f;
    [SerializeField] private float xDephasing = 0f; 
    [SerializeField] private float xDamping = 5f;

    [Header("Y Axis shaking")]
    [SerializeField] private float yAmplitude = .4f;
    [SerializeField] private float yFrequency = 27f;
    [SerializeField] private float yDephasing = .523f;
    [SerializeField] private float yDamping = 4.5f;

    [Header("Z Axis rotation shaking")]
    [SerializeField] private float zRotAmplitude = 7f;
    [SerializeField] private float zRotFrequency = 80f;
    [SerializeField] private float zRotDephasing = .628f;
    [SerializeField] private float zRotDamping = 7f;

    [Header("Time properties")]
    [SerializeField] private float shakeTime = .5f;
    [SerializeField] private float timeToFade = .2f;

    public void Shake()
    {
        CameraShaker.Shake(xAmplitude, xFrequency, xDephasing, xDamping, 
                           yAmplitude, yFrequency, yDephasing, yDamping, 
                           zRotAmplitude, zRotFrequency, zRotDephasing, zRotDamping, 
                           shakeTime, timeToFade);
    }
}
