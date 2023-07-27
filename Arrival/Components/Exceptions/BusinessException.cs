﻿using Entities;
using System;

namespace Exceptions
{
    public class BusinessException : Exception
    {
        public int ExceptionId;

        public string ExceptionDetails { get; set; }
        public ApplicationMessage AppMessage { get; set; }

        public BusinessException()
        {

        }

        public BusinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BusinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
        }
    }
}
