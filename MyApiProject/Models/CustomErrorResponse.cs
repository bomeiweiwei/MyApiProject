using System;
namespace MyApiProject.Models
{
    public class CustomErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public CustomErrorResponse(string message, int statusCode = StatusCodes.Status401Unauthorized)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}

