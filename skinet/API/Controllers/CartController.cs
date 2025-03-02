using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartController(ICartService cartService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
    {
        var cart = await cartService.GetCartAsync(id);

        return Ok(cart ?? new ShoppingCart{Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
    {
        await cartService.SetCartAsync(cart);
        var updatedCart = cart;

        if(updatedCart == null) return BadRequest("Problem with cart");

        return updatedCart;
    }

    [HttpDelete]
    public async Task<OkResult> DeleteCart(string id)
    {
        var result = await cartService.DeleteCartAsync(id);

        if(!result) BadRequest("Problem deleting cart");

        return Ok();
    }

}
