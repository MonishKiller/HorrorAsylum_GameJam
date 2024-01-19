using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lights_Environment : MonoBehaviour, IObserver
{
    public float _minIntensity = 0.5f;  // Minimum light intensity during flicker
    public float _maxIntensity = 1.0f;  // Maximum light intensity during flicker
    public float _flickerSpeed = 1.0f;  // Speed of the flicker
    public float _flickerDuration = 5.0f;
    private bool _lightActive = true;
    [SerializeField] private Light lightSource;


    public bool LightActive => this._lightActive;
    public void SetLightActive(bool isActive)
    {
        _lightActive = isActive;
        RefereshLights();

    }
    private float _defaultLightIntensity;
    private float _offLightIntensity;

    private void RefereshLights()
    {
        if (_lightActive)
        {
            lightSource.intensity = _defaultLightIntensity;
        }
        else
        {
            lightSource.intensity = _offLightIntensity;
        }

    }
    private void Start()
    {
        _defaultLightIntensity = lightSource.intensity; ;
        _offLightIntensity = 0;
    }
    private IEnumerator Flicker()
    {

        while (_flickerDuration > 0.0f)
        {
            float targetIntensity = Random.Range(_minIntensity, _maxIntensity);
            float currentIntensity = lightSource.intensity;
            float t = 0;

            while (t < 1)
            {
                t += Time.deltaTime * _flickerSpeed;
                lightSource.intensity = Mathf.Lerp(currentIntensity, targetIntensity, t);

                yield return null;
            }
            Debug.Log(_flickerDuration);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));// Random delay between flickers
            _flickerDuration -= 1;
        }
        _flickerDuration = 5.0f;
        _lightActive = false;
        RefereshLights();

    }

    public void OnNotify()
    {
        StartCoroutine(Flicker());

    }
}
