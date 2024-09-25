﻿using Api.src.Cart.domain.dto;
using Api.src.Cart.domain.entity;
using backend.Data;
using backend.src.User.domain.dto;
using Microsoft.EntityFrameworkCore;

namespace Api.src.Cart.application.mappers
{
    public static class CartMapper
    {
        public static CreateCartResponseDto ToCreateCartResponseDto(this CartEntity cart)
        {
            return new CreateCartResponseDto
            {
                UserId = cart.User.Id,
                ShippingCost = cart.ShippingCost,
            };
        }
        public static async Task<CartEntity> ToCartModelForCreate(this CreateCartDto cart, ApplicationDBContext context)
        {
            return new CartEntity
            {
                Coupon = await context.Coupon.FirstOrDefaultAsync(c => c.Code.Equals(cart.CouponCode)),
            };
        }
    }
}
