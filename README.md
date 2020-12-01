# ArcClientSideProxyOnSF

### Steps to run Client side proxy
- Clone this repo with: 
`git clone https://github.com/atharvamulmuley/ArcClientSideProxyOnSF.git`
- Open GuestProxyAPI.sln in Visual Studio
- Hit Ctrl+F5 in Visual Studio to run the solution.
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



