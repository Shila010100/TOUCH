using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ArduinoConnector : MonoBehaviour
{
    SerialPort arduinoPort;
    public string portName = "\\\\.\\COM5";
    public int baudRate = 11520;
    private Thread readThread;
    private bool reading;

    void Start()
    {
        arduinoPort = new SerialPort(portName, baudRate);
        try
        {
            arduinoPort.Open();
            StartReading();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error opening serial port: " + ex.Message);
        }
    }

    void OnDisable()
    {
        StopReading();
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            arduinoPort.Close();
        }
    }

    public void Vibrate(string data)
    {
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            data += "\n";
            try
            {
                arduinoPort.Write(data);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Failed to send data: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("Serial port not open");
        }
    }

    private void StartReading()
    {
        if (!reading)
        {
            reading = true;
            readThread = new Thread(ReadFromPort);
            readThread.Start();
        }
    }

    private void StopReading()
    {
        if (reading)
        {
            reading = false;
            readThread.Join(); // wait for the thread to finish
            readThread = null;
        }
    }

    private void ReadFromPort()
    {
        while (reading)
        {
            if (arduinoPort.IsOpen)
            {
                try
                {
                    string message = arduinoPort.ReadLine();
                    Debug.Log("Received: " + message);
                    // Process the message as needed
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Error reading from serial port: " + ex.Message);
                }
            }
            else
            {
                Debug.LogWarning("Serial port not open");
            }
        }
    }
}