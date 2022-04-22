using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [System.Serializable]
    class LampFadeConfig
    {
        [SerializeField] public float lerpSpeed = 1f;
        [SerializeField] public Color fromColor = Color.red;
        [SerializeField] public Color toColor = Color.blue;
    }

    MeshRenderer _renderer;

    [SerializeField] LampFadeConfig config = new LampFadeConfig();


    [System.Serializable]
    class Speed
    {
        public float speed;
        public string animParam;
    }

    [SerializeField] Speed walkSpeed = new Speed();
    [SerializeField] Speed runSpeed = new Speed();

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _renderer.material.color = Color.Lerp(config.fromColor, config.toColor, Mathf.PingPong(Time.time, config.lerpSpeed));
    }
}
