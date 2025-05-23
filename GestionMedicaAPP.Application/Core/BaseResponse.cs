﻿namespace GestionMedicaAPP.Application.Core
{
    public abstract class BaseResponse
    {
        protected BaseResponse()
        {
            this.IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
