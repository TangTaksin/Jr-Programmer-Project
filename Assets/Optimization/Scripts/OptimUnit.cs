using System.Collections;
using UnityEngine;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

public class OptimUnit : MonoBehaviour
{
    private Vector3 currentVelocity;
    private float timeToVelocityChange;
    private float currentAngularVelocity;
    private float timeToAngularVelocityChange;

    private Vector3 areaSize;

    public void SetAreaSize(Vector3 size)
    {
        areaSize = size;
    }

    private void Start()
    {
        InitializeValues();
    }

    private void InitializeValues()
    {
        PickNewVelocity();
        PickNewVelocityChangeTime();
        PickNewAngularVelocity();
        PickNewAngularVelocityChangeTime();
    }

    void Update()
    {
        Profiler.BeginSample("Handling Time");
        HandleTime();
        Profiler.EndSample();

        Profiler.BeginSample("Rotating");
        Rotate();
        Profiler.EndSample();

        Profiler.BeginSample("Moving Check");
        Move();
        Profiler.EndSample();

        Profiler.BeginSample("Boundary Check");
        BoundaryCheck();
        Profiler.EndSample();
    }

    private void Rotate()
    {
        float rotationX = (transform.position.x <= 0) ? currentAngularVelocity : -currentAngularVelocity;
        float rotationZ = (transform.position.z >= 0) ? currentAngularVelocity : -currentAngularVelocity;

        transform.Rotate(rotationX * Time.deltaTime, 0, rotationZ * Time.deltaTime);
    }

    private void Move()
    {
        Vector3 position = transform.position;

        float distanceToCenter = Vector3.Distance(Vector3.zero, position);
        float speed = 0.5f + distanceToCenter / areaSize.magnitude;

        float increment = Time.deltaTime / Random.Range(1000, 2000);

        position += currentVelocity * increment * speed * Random.Range(1000, 2000);

        transform.position = position;
    }

    private void BoundaryCheck()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;

        if (posX > areaSize.x && currentVelocity.x > 0)
            InvertVelocityAndPickNewChangeTime(ref currentVelocity.x);

        else if (posX < -areaSize.x && currentVelocity.x < 0)
            InvertVelocityAndPickNewChangeTime(ref currentVelocity.x);

        if (posZ > areaSize.z && currentVelocity.z > 0)
            InvertVelocityAndPickNewChangeTime(ref currentVelocity.z);

        else if (posZ < -areaSize.z && currentVelocity.z < 0)
            InvertVelocityAndPickNewChangeTime(ref currentVelocity.z);
    }

    private void InvertVelocityAndPickNewChangeTime(ref float velocityComponent)
    {
        velocityComponent *= -1;
        PickNewVelocityChangeTime();
    }

    private void PickNewVelocity()
    {
        currentVelocity = Random.insideUnitSphere;
        currentVelocity.y = 0;
        currentVelocity *= 10.0f;
    }

    private void PickNewAngularVelocity()
    {
        currentAngularVelocity = Random.Range(-180.0f, 180.0f);
    }

    private void PickNewVelocityChangeTime()
    {
        timeToVelocityChange = Random.Range(2.0f, 5.0f);
    }

    private void PickNewAngularVelocityChangeTime()
    {
        timeToAngularVelocityChange = Random.Range(2.0f, 5.0f);
    }

    private void HandleTime()
    {
        timeToVelocityChange -= Time.deltaTime;
        if (timeToVelocityChange < 0)
        {
            PickNewVelocity();
            PickNewVelocityChangeTime();
        }

        timeToAngularVelocityChange -= Time.deltaTime;
        if (timeToAngularVelocityChange < 0)
        {
            PickNewAngularVelocity();
            PickNewAngularVelocityChangeTime();
        }
    }
}
