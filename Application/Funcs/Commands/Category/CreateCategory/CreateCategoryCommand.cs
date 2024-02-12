using MediatR;

namespace Roadmap.Application.Funcs.Commands.Category.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}