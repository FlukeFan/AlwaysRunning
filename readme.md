
IIS Always Running Example
==========================

An example of keeping an IIS site always running.

Build Pre-requisites
--------------------

* .NET SDK specified in global.json.

In Windows Features enable IIS -> WWW Servies -> Application Development Features -> Application Initialization

In IIS App Pool, set Start Mode == AlwaysRunning
In IIS Site, set Preload Enabled == True
