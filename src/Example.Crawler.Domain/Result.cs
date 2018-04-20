using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Crawler.Domain
{
    public enum ResultStatusCode
    {
        OK,
        Error,
        NotFound,
        BadRequest
    }
    public class Result<T>
    {
        public ResultStatusCode Status { get; set; }
        public object Value { get; set; }
        public object ValueAsSuccess { get; set; }

        public Result(ResultStatusCode status, object value)
        {
            Status = status;
            Value = value;
            ValueAsSuccess = (T)value;
        }
    }
}
