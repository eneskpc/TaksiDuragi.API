using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaksiDuragi.API.Data;
using TaksiDuragi.API.Dtos;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Hubs
{
    public class CallerHub : Hub
    {
        private readonly ICallerRepository _callerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public CallerHub(ICallerRepository callerRepository, ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _callerRepository = callerRepository;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public Task RegisterUserByReceiver(string deviceSerialNumber)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, deviceSerialNumber);
        }

        public async Task SendCallerInfo(CallerInfo callerInfo)
        {
            UserDevice userDevice = await _userRepository.GetUserDevice(callerInfo.DeviceSerialNumber);
            Customer customer = null;

            if (userDevice != null)
            {
                customer = await _customerRepository.GetCustomer(c => c.UserId == userDevice.UserId && c.PhoneNumber == callerInfo.CallerNumber && c.IsDeleted == false);
            }

            Caller caller = new Caller
            {
                CallDateTime = callerInfo.CallDateTime,
                CallerNumber = callerInfo.CallerNumber,
                CreationDate = DateTime.Now,
                DeviceSerialNumber = callerInfo.DeviceSerialNumber,
                IsDeleted = false,
                LineNumber = callerInfo.LineNumber,
                UserId = userDevice == null ? 0 : userDevice.UserId,
                CustomerId = customer == null ? 0 : customer.Id
            };

            caller = await _callerRepository.Add(caller);

            callerInfo.CallerNameSurname = customer?.NameSurname;
            callerInfo.CallerAddress = customer?.Address;
            callerInfo.Id = caller.Id;

            await Clients.Groups(callerInfo.DeviceSerialNumber).SendAsync("ReceiveCallerInfo", callerInfo);
        }
    }
}
