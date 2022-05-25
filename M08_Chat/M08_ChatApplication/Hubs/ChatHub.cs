using M08_ChatApplication.Entite;
using Microsoft.AspNetCore.SignalR;

namespace M08_ChatApplication.Hubs
{
    public class ChatHub : Hub
    {

        // ** champs ** //
        private static Dictionary<string, string> _connexionSalon = new Dictionary<string, string>();
        private static Dictionary<string, List<Message>> _discussion = new Dictionary<string, List<Message>>();

        // ** Propriétés ** //

        // ** Constructeurs ** //

        // ** Méthodes ** //
        public async Task EnvoyerMessage(Message p_message)
        {
            string connexionId = this.Context.ConnectionId;

            if (_connexionSalon.ContainsKey(connexionId))
            {
                string nomSalon = _connexionSalon[connexionId];
                _discussion[nomSalon].Add(p_message);

                await Clients.Group(nomSalon).SendAsync("AfficherMessageMoi", p_message);
            }
            //await Clients.Others.SendAsync("AfficherMessageAutres", p_message);
            //await Clients.Caller.SendAsync("AfficherMessageMoi", p_message);
        }

        public async Task CreerRejoindre(string p_nomSalon)
        {
            string connexionId = this.Context.ConnectionId;

            if (!_connexionSalon.ContainsKey(connexionId))
            {
                _connexionSalon.Add(connexionId, null);
            }

            if (!string.IsNullOrWhiteSpace(_connexionSalon[connexionId]))
            {
                await Groups.RemoveFromGroupAsync(connexionId, _connexionSalon[connexionId]);
                _connexionSalon[connexionId] = null;
            }

            if (!_discussion.ContainsKey(p_nomSalon))
            {
                _discussion.Add(p_nomSalon, new List<Message>());
                await Clients.All.SendAsync("MAJSalonDisponible", _discussion.Keys);
            }

            await Groups.AddToGroupAsync(connexionId, p_nomSalon);
            _connexionSalon[connexionId] = p_nomSalon;
            await Clients.Caller.SendAsync("DemarrageChat", _discussion[p_nomSalon]);
        }

        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("MAJSalonDisponible", _discussion.Keys);
            await base.OnConnectedAsync();
        }

    }
}
