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
7. [Testing with the HoloLens 2 Device](#testing-with-the-hololens-2-device)
   - [Things to Modify](#things-to-modify)
   - [Connecting to Unity](#connecting-to-unity)
   - [Connecting Visual Studio to HoloLens 2](#connecting-visual-studio-to-hololens-2)
   - [Testing Videos](#testing-videos)
   
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
   - `Updated Server Script Code` (CubeBehaviour.cs) : [Link to Updated Server Code](https://drive.google.com/file/d/1T9uJGyDObPaS0JI11FGRV8JOyi0S0Dhf/view?usp=sharing)
   - `Server unity source code (MRTK3 Support)`: [Link To source Code)(https://github.com/MohammedAlshami/hololens/tree/main/Server)
   - `Client unity source code (MRTK3 Support)`: [Link To source Code)(https://github.com/MohammedAlshami/hololens/tree/main/Client)
   
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


## Testing with the HoloLens 2 Device

### Things to Modify

1. First step: Go to Window > Photon Unity Networking > Server Setup, then click on Server Settings.

   ![Server Settings](https://i.imgur.com/wA2dQl7.png)

2. Second step (do this for both client and server projects): Change to either TCP or WebSocket. If the client is WebSocket, then the server needs to be the same.

   ![Network Protocol](https://i.imgur.com/M0mjFQq.png)

### Connecting to Unity

1. Ensure developer settings and device discovery are enabled on both Windows and HoloLens 2.
2. On the HoloLens 2, make sure to unpair all devices.

   ![Windows Settings](https://stackify.com/wp-content/uploads/2017/09/what-is-windows-10-developer-mode-benefits-tools-best-practices-and-more-13705.png)
   ![HoloLens 2 Settings](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/images/using-windows-portal-img-01.jpg)

### Connecting Visual Studio to HoloLens 2

1. Ensure both the PC/laptop and HoloLens 2 are connected to the same Wi-Fi network.
2. Set the debugging mode to "Remote Machine" and click on "Debug Properties".

   ![Debug Properties](https://i.imgur.com/Pf9XWpc.png)

3. Click on "Debugging", then set the machine name to point to the HoloLens 2. If both devices are on the same Wi-Fi, the HoloLens 2 should appear automatically. If not, enter the HoloLens 2 IP address manually.
4. Make sure the authentication is set to "Universal (Unencrypted Protocol)".

   ![Remote Debugging Settings](https://i.imgur.com/cZXyoNB.png)
   ![Remote Debugging Settings](https://i.imgur.com/0KfO7ad.png)

6. Finally, click on the remote machine and run the project. This should automatically deploy the server to the HoloLens 2.
![Deploy](https://i.imgur.com/x7GzSn1.png)

### Testing Videos
#### Note: There was an issue with the speed of the internet within the lab, hence it affected the speed of the cube moving

1. [Testing Video 1](https://drive.google.com/file/d/1SwEBabpu7xe3cnhOp_nD_Ig71jQju5td/view?usp=sharing)
2. [Testing Video 2](https://drive.google.com/file/d/1w5-VYQ-mtBjAlqfawZdjkuBbDHBOOr51/view?usp=sharing)

### Testing Video (MRTK and Mixed reality Support) (UNITY)
- [MRTK Support](https://drive.google.com/file/d/1_chHqk8eMq7XklHAe1jlOo7vee1jTl28/view?usp=sharing

### Testing Video (MRTK and Mixed reality Support) (Hololens 2)
- [MRTK Hololens2 Test](https://drive.google.com/file/d/1BRa1toiRotev3TUFYTuYhwOih98k6ZOS/view?usp=sharing)
