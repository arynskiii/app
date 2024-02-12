using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.Category.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateCategoryHandler(IAppDbContext dbContext) => _dbContext = dbContext;


    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Category
        {
            Title = request.Title,
            Description = request.Description
        };
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}