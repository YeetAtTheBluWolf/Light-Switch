# Wireguard-Non-Priviliged-User-Interface

It allows a windows user to manage wireguard connections without explicit administrator privileges.

# Project Status: Version 1.2

### future features include:

1. Allow the user to change the location of where the program finds the WG Configs.
2. I want to add a status bar.

### [Building and executing]
You'll need to run Visual Studio in administrator.
You'll need to install "Microsoft Visual Studio Installer Projects 2022" to build and run the installer.

### [Warnings] 
This program needs to run in administrator to be able to detect files in config directory and to be able to start/stop the tunnel.
When click the buttons it will open a powershell program, and to check if it ran right type "wg show".
Since you're going to be running this with administrator privileges, check the file hash when installing.

### [Issues]
I am open to any suggestions and fixes.

### [Branch and Versioning]
Their is a seperate branch called beta for new features and bug fixes.
The main branch is for Long term support releases.