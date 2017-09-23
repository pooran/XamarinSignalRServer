using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using XamarinSignalR;

namespace XamarinSignalRServer.Hubs
{
    public class GroupHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        public async Task JoinGroupAsync(string groupName)
        {
            await Groups.Add(Context.ConnectionId, groupName);
            Clients.Group(groupName).addChatMessage(Context.User.Identity.Name + " joined.");
        }
        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }

        public void SendMessage(MessageModel messageModel)
        {
            Clients.Group(messageModel.GroupId).GetCall(messageModel);
        }
    }
}