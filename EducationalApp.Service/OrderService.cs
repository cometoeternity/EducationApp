using AutoMapper;
using EducationalApp.Common.DTO;
using EducationalApp.Model.Entities;
using EducationalApp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationalApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public OrderDTO Create(OrderDTO dto)
        {
            var order = _mapper.Map<Order>(dto);
            try
            {
                _unitOfWork.OrderRepository.Insert(order);
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return dto;
        }

        
        public void Delete(Guid id)
        {
            _unitOfWork.OrderRepository.Delete(id);
        }


        public IEnumerable<OrderDTO> GetAll()
        {

            var orders = _unitOfWork.OrderRepository.GetAll().OrderByDescending(d => d.CreatedAt).AsEnumerable();
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

        public IEnumerable<OrderDTO> GetByCity(string city)
        {
            var orders = _unitOfWork.OrderRepository.GetMany(s => s.State.Contains(city)).AsEnumerable();
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

        public IEnumerable<OrderDTO> GetByCountry(string country)
        {
            var orders = _unitOfWork.OrderRepository.GetMany(s => s.State.Contains(country)).AsEnumerable();
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

        public OrderDTO GetById(Guid id)
        {
            var order = _unitOfWork.OrderRepository.GetById(id);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public IEnumerable<OrderDTO> GetByState(string state)
        {
            var orders = _unitOfWork.OrderRepository.GetMany(s => s.State.Contains(state)).AsEnumerable();
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

        public IEnumerable<OrderDTO> GetByZip(int zip)
        {
            var orders = _unitOfWork.OrderRepository.GetMany(s => s.State.Contains(zip.ToString())).AsEnumerable();
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

        public void Update(OrderDTO dto)
        {
            var order = _mapper.Map<Order>(dto);
            _unitOfWork.OrderRepository.Update(order);
        }

    }
}
