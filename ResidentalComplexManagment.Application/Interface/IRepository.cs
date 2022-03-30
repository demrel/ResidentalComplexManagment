using Ardalis.Specification;
using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot { }


