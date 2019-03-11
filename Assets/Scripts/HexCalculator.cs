using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCalculator
{
    public Vector3 PositionFromIndex(int i, Vector3 center, float distance, int[] prog)
    {
        int XCoordinateFromIndex(int index, int[] _prog, int _group)
        {
            // x is 0
            if (index == 0)
            {
                return 0;
            }
            var prevLast = _prog[_group - 1];
            var half = 1 + (_prog[_group] + prevLast) / 2;
            if (index == half)
            {
                return 0;
            }
            if (index == prevLast + 1)
            {
                return 0;
            }
            // x is not 0
            var target = _group;
            var diffLength = _group - 1;
            for (int j = 0; j < diffLength; j++)
            {
                if(index == prevLast + 2 + j)
                {
                    target -= diffLength - j;
                }
                if (index == half - diffLength + j)
                {
                    target -= j + 1;
                }
                if (index == half + 1 + j)
                {
                    target -= diffLength - j;
                }
                if (index == _prog[_group] - j)
                {
                    target -= diffLength - j;
                }
            }
            if (half < index)
            {
                target *= -1;
            }
            return target;
        }

        int YCoordinateFromIndex(int index, int[] _prog, int _group)
        {
            if (index == 0) return 0;
            var yMax = _group * 2;
            var prevLast = _prog[_group - 1];
            var half = 1 + (_prog[_group] + prevLast) / 2;
            if (index == prevLast + 1) return yMax;
            if (index == half) return -yMax;
            var searchLength = half - prevLast - 2;
            if (index < half)
            {
                for (int j = 0; j < searchLength; j++)
                {
                    if (index == prevLast + 2 + j)
                    {
                        var target = yMax - (j + 1);
                        if (index > prevLast + 1 + _group)
                        {
                            target -= Mathf.Min(_group, index - (prevLast + 1 + _group));
                        }
                        return target;
                    }
                }
            }
            for (int j = 0; j < searchLength; j++)
            {
                if (index == half + 1 + j)
                {
                    var target = -yMax + (j + 1);
                    if (index > half + _group)
                    {
                        target += Mathf.Min(_group, index - (half + _group));
                    }
                    return target;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        if (i == 0) return center;
        var unitX = distance / 2 * Mathf.Sqrt(3);
        var unitY = distance / 2;

        // x計算
        var group = RingGroupFromIndex(i, prog);
        var x = XCoordinateFromIndex(i, prog, group) * unitX;
        var y = YCoordinateFromIndex(i, prog, group) * unitY;
        return new Vector3(x, y, 0);
    }

    public float GetDegreeFromIndex(int i)
    {
        return 0;
    }

    /// <summary>
    /// indexからRingの何週目にあるかを返す．
    /// </summary>
    public int RingGroupFromIndex(int i, int[] progression)
    {
        for (int j = 0; j < progression.Length; j++)
        {
            if (progression[j] >= i)
            {
                return j;
            }
        }
        throw new ArgumentOutOfRangeException();
    }

    /// <summary>
    /// a_n = a + nb 型の数列
    /// </summary>
    public int[] CalcProgression(int a, int b, int length)
    {
        var result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = a + b * i * (i + 1) / 2;
        }
        return result;
    }
}
