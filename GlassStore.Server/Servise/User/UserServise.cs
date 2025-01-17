﻿using GlassStore.Server.Domain.Models.User;
using GlassStore.Server.DAL.Interfaces;
using GlassStore.Server.Servise.Helpers;
using GlassStore.Server.Domain.Models.Auth;
using AutoMapper;
using System.Linq;



namespace GlassStore.Server.Servise.User
{
    public class UserServise
    {
        private readonly iUserRepository _userRepository;
        private readonly HttpService httpService;
        private readonly IMapper mapper;
        private readonly Accounts user;

        public UserServise(iUserRepository userRepository, HttpService httpService, IMapper mapper)
        {
            _userRepository = userRepository;
            this.httpService = httpService;
            this.mapper = mapper;
        }
        public async Task<UserInfo> GetUser()
        {
            Accounts account = await httpService.GetCurrentUser();
            return mapper.Map<UserInfo>(account);
        }

        public async Task<bool> AddOrder(Orders order)
        {
            try
            {
                order.OrderDate = DateTime.Now;
                order.TotalPrice = (double)order.Glasses.Sum(x => x.Price);
                Accounts user = await httpService.GetCurrentUser();
                if (user.Orders == null)
                {
                    user.Orders = new List<Orders>();
                }
                user.Orders.Add(order);
                await _userRepository.UpdateAsync(user.Id, user);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        //public async Task<List<T>> GetField<T>()
        //{
        //    Accounts user = await httpService.GetCurrentUser();
        //    var propertyInfo = user.GetType(T);
        //    return user.GetType(propertyInfo) as List<T>;

        //    var propertyInfo = user.GetType().GetProperty(Field);
        //    return user.GetType(propertyInfo) as List<T>;
        //}

        public async Task<List<Orders>> GetOrders()
        {
            Accounts user = await httpService.GetCurrentUser();
            return user.Orders;
        }

        public async Task<Basket> GetBasket()
        {
            Accounts user = await httpService.GetCurrentUser();
            return user.Basket;
        }
    }
}
