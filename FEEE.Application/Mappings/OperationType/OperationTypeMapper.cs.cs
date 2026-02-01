using FEEE.Application.DTOs.OperationType;
using FEEE.Domain.Entities;
using OperationTypeModel = FEEE.Domain.Entities.OperationTypeModel;

namespace FEEE.Application.Mappings.OperationTypes;
public static class OperationTypeMapper
{
    public static OperationTypeModel ToModel(CreateOperationTypeRequest request)
    {
        return new OperationTypeModel
        {
            Name = request.Name
        };
    }

    public static void UpdateModel(OperationTypeModel model, UpdateOperationTypeRequest request)
    {
        model.Name = request.Name;
    }

    public static OperationTypeResponse ToResponse(OperationTypeModel model)
    {
        return new OperationTypeResponse
        {
            OperationTypeId = model.OperationTypeId,
            Name = model.Name
        };
    }
}
