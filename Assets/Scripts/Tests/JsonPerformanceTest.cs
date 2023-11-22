using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.PerformanceTesting;

public class JsonPerformanceTest
{
    public static readonly int MEASUREMENT_COUNT = 10;
    public static readonly int ITERATIONS_PER_MEASUREMENT = 10;
    public static readonly string FILENAME = "test-vector.json";
    
    // A Test behaves as an ordinary method
    [Test]
    [Performance]
    public void TestNewtonsoftJson()
    {
        Vector3Data data = new (1.1f, 2.2f, 3.3f);

        
        Measure.Method(() =>
        {
            NewtonsoftJsonUtils.SaveJson(data, FILENAME);
            data = NewtonsoftJsonUtils.LoadJson<Vector3Data>(FILENAME);
        })
        .MeasurementCount(MEASUREMENT_COUNT)
        .IterationsPerMeasurement(ITERATIONS_PER_MEASUREMENT)
        .Run();
    }
}
