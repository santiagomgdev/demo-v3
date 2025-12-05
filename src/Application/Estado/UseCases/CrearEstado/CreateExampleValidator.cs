using DemoV3.Contracts.Estados;
using FluentValidation;

namespace DemoV3.Application.Estados.UseCases.CrearEstado;

public class CrearEstadoValidator : AbstractValidator<CrearEstadoRequest>
{
    public CrearEstadoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("Nombre es requerido")
            .Length(3, 20).WithMessage("Nombre debe estar entre 3 y 20 carácteres");

        RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("Descripcion es requerido")
            .MaximumLength(100).WithMessage("Descripción no puede exceder los 100 carácteres");
    }
}