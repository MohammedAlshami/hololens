using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon; // Import this for Hashtable
using System.IO.Ports; // Import this for SerialPort

public class PhotonClientManager : MonoBehaviourPunCallbacks
{
    private int dataCount = 0;
    private SerialPort serialPort;
    public string COM = "COM3";

    private void Start()
    {
        // Initialize Photon and connect to the server
        Debug.Log("Connecting to Photon...");
        PhotonNetwork.ConnectUsingSettings();

        // Open the serial port
        serialPort = new SerialPort(COM, 9600); // Change "COM3" to your Arduino's port
        serialPort.Open();
    }

    private void OnDestroy()
    {
        // Close the serial port when the GameObject is destroyed
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }

    public override void OnConnectedToMaster()
    {
        // Join the room
        Debug.Log("Connected to Master. Joining Room...");
        PhotonNetwork.JoinRoom("NewRoomName123"); // Ensure the room name matches the server script
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room successfully!");

        // Start sending data to the server
        InvokeRepeating("SendDataToServer", 0f, 0.01f);
    }

    void SendDataToServer()
    {
        // Increment the data count
        // dataCount++; // Remove this line as we will update dataCount in Update() method

        // Send the updated data count to the server via a custom property
        Hashtable customProps = new Hashtable();
        customProps.Add("DataCount", dataCount);
        PhotonNetwork.LocalPlayer.SetCustomProperties(customProps);
        Debug.Log("Sent Data Count: " + dataCount);
    }

    private void Update()
    {
        // Check if we are connected to a room
        if (PhotonNetwork.InRoom)
        {
            // Read data from the serial port
            if (serialPort.IsOpen && serialPort.BytesToRead > 0)
            {
                string serialData = serialPort.ReadLine();
                int receivedData;
                if (int.TryParse(serialData, out receivedData))
                {
                    // Update dataCount with the received data
                    dataCount = receivedData;
                    Debug.Log("Received Data from Arduino: " + dataCount);
                }
                else
                {
                    Debug.LogWarning("Failed to parse data from Arduino: " + serialData);
                }
            }

            // Send data to the server by setting a custom property on the local player
            Hashtable customProps = new Hashtable();
            customProps.Add("DataCount", dataCount);
            PhotonNetwork.LocalPlayer.SetCustomProperties(customProps);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        // Check if the updated properties belong to the local player
        if (targetPlayer == PhotonNetwork.LocalPlayer)
        {
            // Check if the custom property "DataCount" was updated
            if (changedProps.ContainsKey("DataCount"))
            {
                int receivedCount = (int)changedProps["DataCount"];
                Debug.Log("Received Data Count: " + receivedCount);
            }
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to join room: " + message);
        serialPort.Close();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected from Photon: " + cause.ToString());
        serialPort.Close();
    }
}