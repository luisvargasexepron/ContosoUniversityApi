using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using LinqKit.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppContext = ContosoUniversityApi.Data.AppContext;

namespace ContosoUniversityApi.Controllers;

public abstract class AODataControllerBase<TEntity> : ControllerBase where TEntity : class
{
    protected readonly AppContext _context;
    protected readonly string _entityName;
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly Expression<Func<TEntity, int>> _getEntityIdExp;
    protected readonly Func<TEntity, int> _getEntityId;

    protected IQueryable<TEntity> _entityByIdQuery(int id) =>
        _dbSet.Where(e => _getEntityIdExp.Compile()(e) == id).AsExpandable();

    protected bool _existsById(int id) => _entityByIdQuery(id).Any();

    protected AODataControllerBase(
        AppContext context,
        string entityName,
        Expression<Func<TEntity, int>> getEntityIdExp)
    {
        _context = context;
        _entityName = entityName;
        _dbSet = context.Set<TEntity>();
        _getEntityIdExp = getEntityIdExp;
        _getEntityId = getEntityIdExp.Compile();
    }

    // GET: api/{Entity}
    [HttpGet]
    [CustomEnableQuery]
    public IQueryable<TEntity> GetMany()
    {
        return _dbSet;
    }

    // GET: api/{Entity}/5
    [HttpGet("{id}")]
    [CustomEnableQueryOne]
    public ActionResult<IQueryable<TEntity>> GetById(int id)
    {
        if (!_existsById(id))
        {
            return NotFound();
        }

        return Ok(_entityByIdQuery(id));
    }

    // PUT: api/{Entity}/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [CustomEnableQueryOne]
    public ActionResult<IQueryable<TEntity>> PutOne(int id, TEntity entity)
    {
        if (id != _getEntityId(entity))
        {
            return BadRequest("The Id specified in path is different from the body Id");
        }

        if (!_existsById(id))
        {
            return NotFound($"{_entityName} with Id '{id}' not found");
        }

        _context.Entry(entity).State = EntityState.Modified;

        _context.SaveChanges();

        return Ok(_entityByIdQuery(id).AsNoTracking());
    }

    // POST: api/{Entity}
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [CustomEnableQueryOne]
    public ActionResult<IQueryable<TEntity>> PostOne(TEntity entity)
    {
        if (_getEntityId(entity) != 0 && _existsById(_getEntityId(entity)))
        {
            return Conflict($"{_entityName} with specified Id already Exists");
        }

        _dbSet.Add(entity);
        _context.SaveChanges();

        var entityQuery = _entityByIdQuery(_getEntityId(entity)).AsNoTracking();
        return CreatedAtAction($"Get{_entityName}ById", new {id = _getEntityId(entity)}, entityQuery);
    }

    // DELETE: api/{Entity}/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        if (!_existsById(id))
        {
            return NotFound();
        }

        var entity = Activator.CreateInstance<TEntity>();
        if (_getEntityIdExp.Body is MemberExpression memberExpression)
        {
            var property = memberExpression.Member as PropertyInfo;
            property?.SetValue(entity, id);
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}