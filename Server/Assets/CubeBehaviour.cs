using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon; // Import this for Hashtable

public class CubeBehaviour : MonoBehaviourPunCallbacks
{
    public GameObject box; // Reference to the Box GameObject
    private int prevValue = 500; // Variable to store the previous received value, starting at 500
    private Vector3 initialPosition; // Store the initial position of the box

    private void Start()
    {
        // Initialize Photon and set up the room
        PhotonNetwork.ConnectUsingSettings();

        // Store the initial position of the box
        if (box != null)
        {
            initialPosition = box.transform.position;
        }
    }

    public override void OnConnectedToMaster()
    {
        // Create a room or join an existing one
        PhotonNetwork.CreateRoom("NewRoomName123", new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Server: Joined room successfully!");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Server: Player entered room.");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Server: Player left room.");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Server: Disconnected from Photon: " + cause.ToString());
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        // Check if the updated properties belong to a player in the room
        if (PhotonNetwork.CurrentRoom.Players.ContainsKey(targetPlayer.ActorNumber))
        {
            // Check if the custom property "DataCount" was updated
            if (changedProps.ContainsKey("DataCount"))
            {
                int receivedCount = (int)changedProps["DataCount"];
                Debug.Log("Server: Received Data Count from Player " + targetPlayer.ActorNumber + ": " + receivedCount);

                // Only update the box position if the received value is different from the previous one
                if (receivedCount != prevValue)
                {
                    if (box != null)
                    {
                        // Calculate the new position based on the received data
                        Vector3 newPosition = initialPosition; // Start from the initial position
                        float distance = Mathf.Abs(receivedCount - 500); // Distance from 500
                        float direction = Mathf.Sign(receivedCount - 500); // Direction (left or right)
                        newPosition.x += direction * distance * 0.001f; // Adjust the 0.001f factor based on your scene scale

                        // Set the new position of the box
                        box.transform.position = newPosition;

                        // Update the previous value
                        prevValue = receivedCount;
                    }
                    else
                    {
                        Debug.LogWarning("No Box GameObject referenced for displaying data!");
                    }
                }
            }
        }
    }
}
