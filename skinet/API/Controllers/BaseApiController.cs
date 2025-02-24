using System;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]  // Improving the developer experience for building APIs

[Route("api/[controller]")]  // Defining the route for the API Endpoints
public class BaseApiController: ControllerBase
{

    protected async Task<ActionResult> CreatePageResult<T>(IGenericRepository<T> repo , 
        ISpecification<T> spec , int pageIndex , int pageSize) where T: BaseEntity
        {
            var items = await repo.ListAsync(spec);
            var count = await repo.CountAsync(spec);
            var pagination = new Pagination<T>(pageIndex, pageSize, count, items);

            return Ok(pagination);
        }

}
