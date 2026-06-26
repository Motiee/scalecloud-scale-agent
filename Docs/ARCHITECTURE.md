# Scale Agent Architecture

## Goal

Architecture Version: 1.0

Read two RS232 weighing indicators simultaneously.

Parse more than 18 communication protocols.

Publish live weights over WebSocket.

Run as a Windows Tray application.

Support Windows 7 and newer.

---

## Main Components

Program
    ↓
TrayApplication
    ↓
ScaleManager
    ├── ScaleChannel #1
    │       ↓
    │   SerialReader
    │       ↓
    │   ScaleProtocol
    │
    └── ScaleChannel #2
            ↓
        SerialReader
            ↓
        ScaleProtocol

ScaleManager
        ↓
WebSocketHost
        ↓
React Frontend