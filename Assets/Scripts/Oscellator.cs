using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscellator : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    float movementFactor;
    void Start()
    {
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MoveEntity();
    }

    private void MoveEntity()
    {
        if (period <= Mathf.Epsilon) { return; } // float nicht immer 0 0 deswegen kleinste float einheit und gut ist

        float cycles = Time.time / period; // Über Zeit immer wachsend

        const float tau = Mathf.PI * 2; // Konstante 6.238
        float rawSinWave = Mathf.Sin(cycles * tau); // Value between -1 and 1 depending on time - sinuskurve

        movementFactor = (rawSinWave + 1f) / 2f; // 0bis2 durch2 = 0bis1 - recalculated so its cleaner


        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;


    }
}
