﻿using Api.src.Cart.application.service;
using Api.src.Cart.domain.dto;
using Api.src.Cart.domain.repository;
using Api.src.Cart.domain.entity;
using backend.Data;

namespace Api.src.Cart.infraestructure.api
{
    public class CartService : CartRepository
    {
        private CreateCart _createCart;
        private UpdateCartByUserId _updateCartByUserId;
        private GetPendingCartByUserId _getPendingCartByUserId;
        public CartService(ApplicationDBContext context)
        {
            _createCart = new CreateCart(context);
            _updateCartByUserId = new UpdateCartByUserId(context);
            _getPendingCartByUserId = new GetPendingCartByUserId(context);

        }

        public async Task<CartResponse> CreateAsync(Guid idUser)
        {
            return await _createCart.Run(idUser);
        }

        public async Task<CartResponse> GetPendingCartAsync(Guid userId)
        {
            return await _getPendingCartByUserId.Run(userId);
        }

        public async Task<CartResponse> UpdateAsync(UpdateCartDto entity, Guid userId)
        {
            return await _updateCartByUserId.Run(entity, userId);
        }
    }
}
