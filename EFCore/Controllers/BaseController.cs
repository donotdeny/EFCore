using EFCore.Domain.Entities;
using EFCore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IBaseRepository<TEntity> _repo;
        protected const string _messageResponse = "An error occurred while processing your request.";

        protected BaseController(IServiceProvider serviceProvider, IBaseRepository<TEntity> repo)
        {
            _serviceProvider = serviceProvider;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<TEntity> entities = _repo.GetAll();
                return Ok(entities);
            }
            catch (Exception)
            {
                return StatusCode(500, _messageResponse);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            TEntity entity = _repo.FindOne(entity => entity.Id == id, new Domain.Options.FindOptions() 
                { IsAsNoTracking = true, IsIgnoreAutoIncludes = true }
            );
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }

                _repo.Add(entity);
                await _repo.SaveChange();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, _messageResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }

                _repo.Update(entity);
                await _repo.SaveChange();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, _messageResponse);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }

                _repo.Delete(entity);
                await _repo.SaveChange();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, _messageResponse);
            }
        }

        [HttpDelete("many")]
        public async Task<IActionResult> DeleteMany([FromBody] List<Guid> listId)
        {
            try
            {
                _repo.DeleteMany(entity => listId.Any(id => entity.Id == id));
                await _repo.SaveChange();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, _messageResponse);
            }
        }
    }
}
