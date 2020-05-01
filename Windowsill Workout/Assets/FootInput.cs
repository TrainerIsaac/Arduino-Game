using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class FootInput : MonoBehaviour
{
    public SerialPort Arduino = new SerialPort("\\\\.\\COM4", 9600);
    private int[] numbers = new int[6] { 0, 2, 4, 6, 8, 10 };

    public GameObject[] steps = new GameObject[] { };

    // Start is called before the first frame update
    void Start()
    {
        Arduino.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (Arduino.IsOpen)
        {
            try
            {
                print(Arduino.ReadLine());
                for (int i = 0; i < steps.Length; i++)
                {
                    if (Arduino.ReadLine().Contains(numbers[i].ToString()))
                    {
                        steps[i].transform.Translate(Vector3.up / 10);
                    }
                    print(numbers[i]);
                }
            }
            catch (System.Exception)
            {

            }
        }
    }
}
