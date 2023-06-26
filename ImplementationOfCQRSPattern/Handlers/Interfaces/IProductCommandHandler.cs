using ImplementationOfCQRSPattern.Commands;

namespace ImplementationOfCQRSPattern.Handlers.Interfaces;

public interface IProductCommandHandler
{
    Task Handle(CreateProductCommand command);
    Task Handle(UpdateProductCommand command);
}