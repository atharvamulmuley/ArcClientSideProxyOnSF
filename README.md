# ArcClientSideProxyOnSF

### Steps to run Client side proxy
- Clone this repo with: 
`git clone https://github.com/atharvamulmuley/ArcClientSideProxyOnSF.git`
- Open GuestProxyAPI.sln in Visual Studio
- Hit Ctrl+F5 in Visual Studio to run the solution.
- Go to \<repo-root\>/GuestProxyAPI/pkg/Debug/GuestProxyAPIServicePkg and make the following changes to the ServiceManifest.xml file
  - Add the following code package below the existing code package in the file
  ```
  <CodePackage Name="Code2" Version="1.0.0">
    <EntryPoint>
      <ExeHost>
        <Program>arcK8sProxy.exe</Program>
        <!--<Arguments>-v</Arguments>-->
        <!--arguments to guest proxy executable should be specified like above-->
        <Arguments>-c "./config.yml"</Arguments>
        <!--path to config file should be specified like above. '.' above refers to the working directory defined by Codebase-->
        <WorkingFolder>CodeBase</WorkingFolder>
        <!--Working directory for the codepackage with the CodeBase option will be <repo root>\GuestProxyAPI\pkg\Debug\GuestProxyAPIServicePkg\Code2-->
        <ConsoleRedirection FileRetentionCount="5" FileMaxSizeInKb="2048"/>
      </ExeHost>
    </EntryPoint>
  </CodePackage>
  ```
  - Add `CodePackageRef="Code"` property to the Endpoint element of the file.
- Navigate to the root of the cloned repository in terminal
- Navigate to Auxillary folder:
`cd Auxillary`
- Run RemoveApplication script:
`.\RemoveApplication.ps1`
- Run Helper script:
`.\Helper.ps1`
- Run DeployApplication script:
`.\DeployApplication.ps1`
- Open Postman and make a request with the following details:
  - URL: http://localhost:8836/subscriptions/<subid\>/resourceGroups/\<rg-name\>/providers/Microsoft.Kubernetes/connectedClusters/\<cluster-name\>/register
  - Body: 
    ```
    {
        "kubeconfigs": [
          {
            "name": "credentialName1",
            "value": "credentialValue1"
          }
        ],
        "hybridConnectionConfig": {
            "relay": "relayNameSpace",
            "hybridConnectionName": "hybridConnection",
            "token": "relay sas token",
            "expiry": ExpirationTime
        }
    }
    ```
  - You should see a response of 200 OK with this body:
    ```
    {
      "kubeconfigs": [
        {
          "name": "credentialName1",
          "value": "credentialValue1"
        }
      ]
    }
    ```



