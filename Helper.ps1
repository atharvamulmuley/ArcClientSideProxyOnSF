Remove-Item .\GuestProxyAPI\pkg\Debug\GuestProxyAPIServicePkg\ServiceManifest.xml
Copy-Item .\ServiceManifest.xml -Destination .\GuestProxyAPI\pkg\Debug\GuestProxyAPIServicePkg
New-Item -Path .\GuestProxyAPI\pkg\Debug\GuestProxyAPIServicePkg -Name "Code2" -ItemType "directory"
Copy-Item .\arcK8sProxy.exe -Destination .\GuestProxyAPI\pkg\Debug\GuestProxyAPIServicePkg\Code2
Copy-Item .\config.yml -Destination .\GuestProxyAPI\pkg\Debug\GuestProxyAPIServicePkg\Code2
