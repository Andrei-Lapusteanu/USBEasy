# USBEasy

## Summary

 The application represents a way to easily copy any file or folder to an attached flash drive

<a href="https://imgur.com/XFm4aTB"><img src="https://i.imgur.com/XFm4aTB.png" title="source: imgur.com" /></a>

# Technologies

- Written in **C#**
- Context menu functionalities implemented using **SharpContextMenu** from the **SharpShell** NuGet - [https://github.com/dwmkerr/sharpshell/tree/master/SharpShell/SharpShell/SharpContextMenu](https://github.com/dwmkerr/sharpshell/tree/master/SharpShell/SharpShell/SharpContextMenu)
- **SHFileOperation** API used to implement copying of file system objects

# Functionality
- The application removes the necessity of copy-pasting by simply highlighting the desired files, right-clicking, and selecting the appropriate option displayed in the Windows context menu

# Usage (as of now)
Building the project will generate **USBCore.dll** at path **USBEasy\bin\Release**

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5NTIzOTQ4MzcsMTQ3ODE2ODUyOV19
-->