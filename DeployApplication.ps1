Connect-ServiceFabricCluster
Copy-ServiceFabricApplicationPackage .\GuestProxyAPI\pkg\Debug -ApplicationPackagePathInImageStore MyApplication
Register-ServiceFabricApplicationType -ApplicationPathInImageStore MyApplication
New-ServiceFabricApplication -ApplicationName fabric:/GuestProxyAPI -ApplicationTypeName GuestProxyAPIType -ApplicationTypeVersion 1.0.0
