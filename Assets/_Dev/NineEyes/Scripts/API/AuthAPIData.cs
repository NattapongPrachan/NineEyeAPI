using Grandora.Heimdall;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API.Data
{
    public class AuthAPIData : NetworkDataListHolder<AuthSignupData>
    {
        public ClientEndpointTemplate SignupEndpoint;
        public ClientEndpointTemplate SigninClientEndpoint;
        public SignupData SignupData;
        [Button]
        public void Signup()
        {
            Debug.Log(SignupData.name);
            var request = CreateRequest(SignupEndpoint, null, Result =>
            {

                Debug.Log("Result " + Result);
            });
            Debug.Log(request.endpoint);
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void Signin()
        {
            var request = CreateRequest(SigninClientEndpoint, null, Result =>
            {
            });
            Debug.Log(request.endpoint);
            ServerConnector.Instance.Request(request);
        }
    }
    
}

/*{ "user":
 *  { "id":"66acbf235da819dc01648240","name":"Test22","email":"test22@test.com","userType":"PLAYER","lls":"fd60208f-47bd-4e9a-bcb3-8154703c44da"}
 *  ,"token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY2YWNiZjIzNWRhODE5ZGMwMTY0ODI0MCIsIm5hbWUiOiJUZXN0MjIiLCJlbWFpbCI6InRlc3QyMkB0ZXN0LmNvbSIsInVzZXJUeXBlIjoiUExBWUVSIiwibGxzIjoiZmQ2MDIwOGYtNDdiZC00ZTlhLWJjYjMtODE1NDcwM2M0NGRhIiwiaWF0IjoxNzIyNTk3MTU1LCJuYmYiOjE3MjI1OTY4NTUsImV4cCI6MTcyNzc4MTE1NX0.Url5lMjVmmHj7eDPhKV_Q4pCFId275ke6bqbTFGb2_Q"}
 */