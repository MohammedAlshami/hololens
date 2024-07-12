# Arduino and HoloLens 2 Integration Project

This project demonstrates how to connect an Arduino to the HoloLens 2 and enable the HoloLens 2 to read data from the Arduino using serial communication. The implementation uses Photon Unity Networking (PUN) to facilitate communication between devices.

## Table of Contents

1. [Project Overview](#project-overview)
2. [Prerequisites](#prerequisites)
3. [Code Structure](#code-structure)
4. [Setup Instructions](#setup-instructions)
   - [Arduino Setup](#arduino-setup)
   - [Server Setup (HoloLens 2)](#server-setup-hololens-2)
   - [Client Setup](#client-setup)
5. [Building and Running](#building-and-running)
   - [Building the Server (HoloLens 2 Emulator)](#building-the-server-hololens-2-emulator)
   - [Running the Client](#running-the-client)
6. [Testing](#testing)
   - [Unity Test](#unity-test)
   - [Emulator Test](#emulator-test)

## Project Overview

This project consists of three main components:

1. Arduino code for reading sensor data
2. Server code running on the HoloLens 2 (or emulator)
3. Client code running on a PC connected to the Arduino

The system works as follows:

1. The HoloLens 2 application creates a server with a random room number.
2. The client connects to the Arduino and then joins the same room on the Photon server.
3. The client reads data from the Arduino and sends it to the server.
4. The server receives the data and moves a 3D cube accordingly:
   - If the value is above 500, the cube moves right.
   - If the value is below 500, the cube moves left.

## Prerequisites

- HoloLens 2 Emulator (10.0.22621.1258) - [Download](https://go.microsoft.com/fwlink/?linkid=2257515)
- Unity Editor (with Windows support)
- Arduino CH340 driver - [Download](https://drive.google.com/file/d/1qF5cVEHgOYuMWaA_hq_R49UCT7_Sooj5/view?usp=sharing)
- Photon Unity Networking (PUN) asset - [Download](https://assetstore.unity.com/packages/tools/network/pun-2-free-119922)
- Arduino board and necessary components

## Code Structure

- `Arduino Code`: [Link to Arduino code](https://drive.google.com/file/d/1zawt65GzisGZAlWLqjIttzCb23vy6qb2/view?usp=sharing)
- `Server Code (PhotonServerManager.cs)`: [Link to Server code](https://drive.google.com/file/d/1naT-U28XloHYPvl4oHaiR8Nswx1Deacf/view?usp=sharing)
- `Client Code (PhotonClientManager.cs)`: [Link to Client code](https://drive.google.com/file/d/1ENKikszKdC9mPtBI8hjzedcRtE-fVatR/view?usp=sharing)

## Setup Instructions

### Arduino Setup

1. Create an Arduino sketch that reads from the slider connected to pin A2 with a baud rate of 9600.
2. Use the provided Arduino code or create your own.
3. Compile and upload the code to your Arduino board.

### Server Setup (HoloLens 2)

[Watch the setup video](https://drive.google.com/file/d/18oBPxg71Nv5FKyz8UlLCTyNWOBpMK47n/view?usp=sharing)

1. Create a new 3D Unity project.
2. Import the Photon PUN asset.
3. Create a PUN project on the Photon website and obtain the API key.
4. Initialize PUN in Unity using the PUN Wizard and your API key.
5. Create an empty GameObject named "Server" and a 3D cube.
6. Attach the `PhotonServerManager.cs` script to the Server GameObject.
7. Drag and drop the 3D cube into the cube slot in the PhotonServerManager component.

### Client Setup

[Watch the setup video](https://drive.google.com/file/d/1Y79avq9rmC3utLyFwsX697tffTUT4Q-L/view?usp=sharing)

1. Create a new Unity project.
2. Import the Photon PUN asset and connect to the same Photon project using the API key.
3. Add the `PhotonClientManager.cs` script to your scene.

## Building and Running

### Building the Server (HoloLens 2 Emulator)

[Watch the build video](https://drive.google.com/file/d/1y8Xok49hFmU_uBBtROTqaQvv_2DJb5Mk/view?usp=sharing)

1. Open the server-side Unity project.
2. Go to Build Settings and switch the platform to Universal Windows Platform.
3. Add your scene to the build.
4. Build the project and create a folder for your build.
5. Run the built application with administrator privileges, selecting the HoloLens 2 Emulator as the target device.

### Running the Client

1. Open the client-side Unity project.
2. Ensure the Arduino is connected to your PC.
3. Run the project in the Unity Editor.

## Testing

### Unity Test

[Watch the Unity test video](https://drive.google.com/file/d/1hMXkMLuzdah-MTfdPguAEf0Rg1HSwxyS/view?usp=sharing)

### Emulator Test

[Watch the Emulator test video (running both client and server)](https://drive.google.com/file/d/1ECXmhbKXfEOcrCjIEAX_ou0G_5m2m7mr/view)
