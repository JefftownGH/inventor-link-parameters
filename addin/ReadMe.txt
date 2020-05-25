================================================
         Plugin of the Month, October 2011
================================================
------------------------
Inventor LinkParameters
------------------------

Description
-----------
The LinkParameters add-in is a tool that has been developed to allow
Inventor users to easily create dependencies between parameters of
the various parts and sub-assemblies in the context of the top-level
assembly they reside.

Through functionality provided by the tool, users are able to select
visually a parameter from a source component and affect its value to 
a specific parameter in a target component. 

The add-in mechanism is based on the iLogic functionality introduced
in Inventor 2011. It will automatically generate the iLogic code
required to link the values of the parameters, without the need for
the user to write any iLogic instructions.


System Requirements
-------------------
Due to the functionalities of the API used by the plug-in the 
minimal Inventor version supported is 2011.

An installer package which works for both 32-bit and 64-bit systems
is provided.

The source code has been provided as a Visual Studio 2008 project
containing C# code (not required to run the plug-in).

Installation
------------
Run the LinkParameters.msi installer. Follow the instructions
provided by the installer: you will only need to select the
installation folder for the add-in. There is no particular
restriction concerning the location of this installation folder.

On 32-bit platforms, building the source project inside Visual Studio
should cause the plug-in to be registered, providing the application
has been "enabled for COM Interop" via the project settings.

On 64-bit platforms, the plug-in cannot be registered by Visual
Studio 2008 because it is a 32-bit application. Registration must
either be performed via the installer or a batch file/command prompt.

Using (for example):

RegAsm.exe /codebase "C:\My Path\Autodesk.ADN.LinkParameters.dll"

Example batch files for registering and unregistering the DLL can be
found in the "Source\addin" sub-folder. 

Usage
-----
Once loaded, an additional button will be inserted in the slideout
menu of the iLogic panel, in the Manage Tab of the Assembly Ribbon.
That means this functionality is only usable from within an assembly.
 
When you run the LinkParameters command a new modeless form should be
displayed, allowing you to select source and target components, then
creating links between parameters by drag-n-dropping parameters
from the source to the target list view.

Uninstallation
--------------
You can unload the plug-in without uninstalling it by unchecking the
"Load" checkbox associated with the plug-in in the Inventor Add-In
dialog.

Unchecking "Load on Startup" cause the plug-in not to be loaded in
future sessions of Inventor.

To remove the plug-in completely, uninstall the application via your
system's Control Panel.


Further Reading
---------------
The "LinkParameters Addin - Quick Start.docx" guide in the "Doc"
folder provides further details about the use of this plugin.

Feedback
--------
Email us at support@coolorange.com with feedback or requests for
enhancements.

Release History
---------------

1.0 Original release


(C) Copyright 2014 by coolOrange s.r.l
