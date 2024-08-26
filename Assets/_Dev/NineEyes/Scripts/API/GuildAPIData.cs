using Grandora.Heimdall;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API.Data
{
    public class GuildAPIData : NetworkDataListHolder<AuthGuildData>
    {
        public ClientEndpointTemplate AcceptRequestEndpoint;
        public ClientEndpointTemplate CancelInviteEndpoint;
        public ClientEndpointTemplate CheckGuildNameEndpoint;
        public ClientEndpointTemplate CreateGuildEndpoint;
        public ClientEndpointTemplate DailyCheckInEndpoint;
        public ClientEndpointTemplate DeclineRequestEndpoint;
        public ClientEndpointTemplate DungeonsEndpoint;
        public ClientEndpointTemplate GetGuildBuffsEndpoint;
        public ClientEndpointTemplate GetTopRankEndpoint;
        public ClientEndpointTemplate GetGuildRankEndpoint;
        public ClientEndpointTemplate GetGuildVisitEndpoint;
        public ClientEndpointTemplate GetGuildIconsEndpoint;
        public ClientEndpointTemplate InvitePlayerEndpoint;
        public ClientEndpointTemplate LeaveGuildEndpoint;
        public ClientEndpointTemplate GuildLevelEndpoint;
        public ClientEndpointTemplate GuildDataEndpoint;
        public ClientEndpointTemplate RemovePlayerEndpoint;
        public ClientEndpointTemplate SearchEndpoint;
        public ClientEndpointTemplate SearchPlayerEndpoint;
        public ClientEndpointTemplate SuggestEndpoint;
        public ClientEndpointTemplate UpdateGuildAnnounceEndpoint;
        public ClientEndpointTemplate UpdateGuildBuffEndpoint;
        public ClientEndpointTemplate UpdateGuildIconEndpoint;
        public ClientEndpointTemplate UpgradeGuildEndpoint;
        public GuildRequest GuildRequestData;

        [Button]
        public void AcceptRequest()
        {
            Debug.Log(GuildRequestData.name);
            var request = CreateRequest(AcceptRequestEndpoint, null, Result =>
            {
                Debug.Log("Result " + Result);
            });
            Debug.Log(request.endpoint);
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void CancelInvite()
        {
            var request = CreateRequest(CancelInviteEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void CheckGuildName()
        {
            var request = CreateRequest(CheckGuildNameEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void CreateGuild()
        {
            var request = CreateRequest(CreateGuildEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void DailyCheckIn()
        {
            var request = CreateRequest(DailyCheckInEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void DeclineRequest()
        {
            var request = CreateRequest(DeclineRequestEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void Dungeons()
        {
            var request = CreateRequest(DungeonsEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GetGuildBuffs()
        {
            var request = CreateRequest(GetGuildBuffsEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GetTopRank()
        {
            var request = CreateRequest(GetTopRankEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GetGuildRank()
        {
            var request = CreateRequest(GetGuildRankEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GetGuildVisit()
        {
            var request = CreateRequest(GetGuildVisitEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GetGuildIcons()
        {
            var request = CreateRequest(GetGuildIconsEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void InvitePlayer()
        {
            var request = CreateRequest(InvitePlayerEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void LeaveGuild()
        {
            var request = CreateRequest(LeaveGuildEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GuildLevel()
        {
            var request = CreateRequest(GuildLevelEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void GuildData()
        {
            var request = CreateRequest(GuildDataEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void RemovePlayer()
        {
            var request = CreateRequest(RemovePlayerEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void Search()
        {
            var request = CreateRequest(SearchEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void SearchPlayer()
        {
            var request = CreateRequest(SearchPlayerEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void Suggest()
        {
            var request = CreateRequest(SuggestEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void UpdateGuildAnnounce()
        {
            var request = CreateRequest(UpdateGuildAnnounceEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void UpdateGuildBuff()
        {
            var request = CreateRequest(UpdateGuildBuffEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void UpdateGuildIcon()
        {
            var request = CreateRequest(UpdateGuildIconEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }
        [Button]
        public void UpgradeGuild()
        {
            var request = CreateRequest(UpgradeGuildEndpoint, null, Result =>
            {
            });
            ServerConnector.Instance.Request(request);
        }

        // Template
        // [Button]
        // public void AcceptRequest()
        // {
        //     Debug.Log(SignupData.name);
        //     var request = CreateRequest(AcceptRequestEndpoint, null, Result =>
        //     {

        //         Debug.Log("Result " + Result);
        //     });
        //     Debug.Log(request.endpoint);
        //     ServerConnector.Instance.Request(request);
        // }
    }
    
}

/*{ "user":
 *  { "id":"66acbf235da819dc01648240","name":"Test22","email":"test22@test.com","userType":"PLAYER","lls":"fd60208f-47bd-4e9a-bcb3-8154703c44da"}
 *  ,"token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY2YWNiZjIzNWRhODE5ZGMwMTY0ODI0MCIsIm5hbWUiOiJUZXN0MjIiLCJlbWFpbCI6InRlc3QyMkB0ZXN0LmNvbSIsInVzZXJUeXBlIjoiUExBWUVSIiwibGxzIjoiZmQ2MDIwOGYtNDdiZC00ZTlhLWJjYjMtODE1NDcwM2M0NGRhIiwiaWF0IjoxNzIyNTk3MTU1LCJuYmYiOjE3MjI1OTY4NTUsImV4cCI6MTcyNzc4MTE1NX0.Url5lMjVmmHj7eDPhKV_Q4pCFId275ke6bqbTFGb2_Q"}
 */