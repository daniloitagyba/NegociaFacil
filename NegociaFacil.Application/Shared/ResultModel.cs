using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Shared
{
    public class ResultModel<T>
    {
        public bool Success => Failures == null || Failures.Count == 0;

        public T Data { get; set; }

        public IList<string> Failures { get; set; } = new List<string>();

        public ResultModel()
        {
        }

        public ResultModel(T data, IDictionary<string, string[]> failures)
        {
            Data = data;
            Failures = failures.SelectMany(x => x.Value).ToList();
        }

        public ResultModel(T data, IList<string> failures)
        {
            Data = data;
            Failures = failures;
        }

        public ResultModel(T data, string failure)
        {
            Data = data;
            if (!String.IsNullOrEmpty(failure))
                Failures = new List<string>() { failure };
        }

        public ResultModel(T data)
        {
            Data = data;
            Failures = new List<string>();
        }

        public ResultModel<T> AddFailures(List<string> failures)
        {
            if (failures != null)
            {
                failures.AddRange(Failures);
                Failures = failures;
            }
            return this;
        }

        public ResultModel<T> AddFailure(string fault)
        {
            Failures.Add(fault);

            return this;
        }

        public static ResultModel<T> SuccessResult(T data)
        {
            return new ResultModel<T>(data);
        }

        public static ResultModel<T> FailureResult(T data, IEnumerable<string> failures)
        {
            return new ResultModel<T>(data, failures.ToList());
        }

        public static ResultModel<T> FailureResult(T data, string failure)
        {
            return new ResultModel<T>(data, failure);
        }
    }
}
