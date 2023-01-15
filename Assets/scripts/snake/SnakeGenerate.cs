using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerate : MonoBehaviour
{
    [SerializeField] private Segment _segmentTempate;
    public List<Segment> Generate(int count)
    {
        List<Segment> Tail = new List<Segment>();

        for(int i = 0; i < count; i++)
        {
            Tail.Add(Instantiate(_segmentTempate));
        }

        return Tail;
    }
}
