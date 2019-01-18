using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BusinessLogic.FilesHandler.Configurations
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.OperationId.ToLower() == "uploadfilestask")
            {
                foreach (IParameter par in operation.Parameters)
                {
                    if (par.Name.Equals("file"))
                    {
                        operation.Parameters.Remove(par);
                        break;
                    }
                }

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "file",
                    In = "formData",
                    Description = "Upload File",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
}
