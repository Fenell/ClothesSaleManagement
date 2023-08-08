﻿namespace ClothesSaleManagement.WebApp.Models
{
    public class Response<T>
    {
        public bool IsSuscess { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data{ get; set; }
    }
}
