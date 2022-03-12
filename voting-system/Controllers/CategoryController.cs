using Core;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using voting_system.Dto;

namespace voting_system.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            return Ok(_unitOfWork.Categories.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _unitOfWork.Categories.Get(id);
            return category != null ? Ok(category) : NotFound("Category not found");
        }
        
        [HttpPost("create")]
        public ActionResult<Category> Create([FromBody] CreateCategory category)
        {
            Category categoryEntity = category;
            _unitOfWork.Categories.Add(categoryEntity);
            _unitOfWork.Complete();

            return CreatedAtAction(nameof(Get), new {id = categoryEntity.Id}, categoryEntity);
        }
    }
}
