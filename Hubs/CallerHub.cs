using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaksiDuragi.API.Dtos;

namespace TaksiDuragi.API.Hubs
{
    public class CallerHub : Hub
    {
        public Task RegisterUserByReceiver(string deviceSerialNumber)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, deviceSerialNumber);
        }

        public Task SendCallerInfo(CallerInfo callerInfo)
        {

            return Clients.Groups(callerInfo.DeviceSerialNumber).SendAsync("ReceiveCallerInfo", callerInfo);
        }
    }
}
