using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Vector3Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void Vector3TestAngle()
    {
        // 角度πに充分近い値か確認
        float pi = Vector3Utils.Angle(new Vector3(0, 0, 1), new Vector3(0, 0, -1));
        Assert.IsTrue((MathF.PI - pi) < 0.001);
    }
}
