using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int FloaterCount = 1;
    public float WaterDrag = 0.99f;
    public float WaterAngularDrag = 0.5f;

    private void FixedUpdate()
    {
        Rigidbody.AddForceAtPosition(Physics.gravity / FloaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier =
                Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            Rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),
                transform.position, ForceMode.Acceleration);
            Rigidbody.AddForce(displacementMultiplier * -Rigidbody.velocity * WaterDrag * Time.fixedDeltaTime,
                ForceMode.VelocityChange);
            Rigidbody.AddTorque(displacementMultiplier * -Rigidbody.angularVelocity * WaterAngularDrag * Time.fixedDeltaTime,
                ForceMode.VelocityChange);
        }
    }

}
