using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using WebSocketSharp;
using System.Text;

namespace Conduit
{
    /**
     * Class responsible for monitoring League and automatically connecting to Rift when needed.
     * This class is also responsible for requesting/storing JWTs from rift and ensuring that they
     * remain valid. All actual messaging is left to Hub/MobileConnectionHandler.
     */
    class ConnectionManager
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private App app;
        private LeagueConnection league;

        public ConnectionManager(App app)
        {
            this.app = app;
            this.league = new LeagueConnection();

            // Hook up league events.
            league.OnConnected += () =>
            {
                DebugLogger.Global.WriteMessage($"ConnectionManager is connected to League of Legends.");
                Connect();
            };
            league.OnDisconnected += () =>
            {
                DebugLogger.Global.WriteMessage($"ConnectionManager is disconnected from League of Legends.");
                Close();
            };
        }

        /**
         * Connects to the hub. Errors if there is already a hub connection.
         * Will cancel a pending reconnection if there is one. This method is
         * not guaranteed to connect on first try.
         */
        public async void Connect()
        {
            if (!league.IsConnected) return;
            //await Task.Delay(2000);

            //选择英雄
            // PRATISE 2, FIRE 11
            //PATCH
            /// lol - champ - select / v1 / session / actions / 11
            //{ "championId":15}

            //选择召唤师技能
            //PATCH
            /// lol - champ - select / v1 / session / my - selection
            //{ "spell1Id":4,"spell2Id":1}

            //确定
            //GET
            /// lol - platform - config / v1 / namespaces / LcuSocial / DefaultGameQueues


            while (true)
            {
                var result = league.Request("POST", "/lol-matchmaking/v1/ready-check/accept", "");
                //var result1 = league.Request("PATCH", "/lol-champ-select/v1/session/actions/11", "{\"championId\":24}");
                //var result1 = league.Request("GET", "/lol-champ-select/v1/pickable-champion-ids", "");
                //var result11 = league.Request("GET", "/lol-summoner/v1/summoners/2255279182488480", "");
                //var result111 = league.Request("PATCH", "/lol-champ-select/v1/session/actions/2", "{\"championId\":24}");
                //var result2 = league.Request("PATCH", "/lol-champ-select/v1/session/my-selection", "{\"spell1Id\":1,\"spell2Id\":4}");
                await Task.Delay(1500);
            }
        }

        /**
         * Closes all connections _without_ queueing a reconnect.
         */
        public void Close()
        {
            DebugLogger.Global.WriteMessage("Disconnecting from rift.");

            league.ClearAllListeners();
        }

    }
}
