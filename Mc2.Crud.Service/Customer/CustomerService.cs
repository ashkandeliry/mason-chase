using Mc2.Crud.Core.Domain;
using Mc2.Crud.Core.Entities;
using Mc2.Crud.Models;
using Mc2.Crud.Models.Generics;
using Mc2.Crud.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Crud.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GenericOutputResult<TblCustomer>> Add(TblCustomer Resource)
        {
            try
            {
                //Check Email Format is Correct
                if (!ValidationService.validateEmail(Resource.Email))
                    throw new Exception("Email is Not Correct");
                //Check Email is exist
                var EmailCheckOnDb = await _unitOfWork.customerRepository.SingleOrDefaultAsync(predicate: x => x.Email == Resource.Email);
                if (EmailCheckOnDb != null)
                    throw new Exception("Email id registered already");

                //Check User
                var FindUser = await _unitOfWork.customerRepository.SingleOrDefaultAsync(predicate: x => x.DateOfBirth == Resource.DateOfBirth && x.Firstname == Resource.Firstname && x.Lastname == Resource.Lastname);
                if (FindUser != null)
                    throw new Exception("User is registered already");

                //Check Phone Number
                var NormalizedPhoneNo = ValidationService.CheckPhoneNo(Resource.PhoneNumber, "UK");
                if (!NormalizedPhoneNo.Status)
                    throw new Exception("Incorrent Phone Number");
                Resource.PhoneNumber = NormalizedPhoneNo.DataResult;


                _unitOfWork.customerRepository.Add(Resource);
                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                return new GenericOutputResult<TblCustomer> { DataResult = Resource, Status = true };
            }
            catch (Exception ex)
            {
                return new GenericOutputResult<TblCustomer> { Status = false };
            }
        }

        public async Task<GenericOutputResult<bool>> Delete(int id)
        {
            try
            {
                var res = await _unitOfWork.customerRepository.GetByIdAsync(id).ConfigureAwait(false);
                _unitOfWork.customerRepository.Remove(res);
                await _unitOfWork.CompleteAsync().ConfigureAwait(false);
                return new GenericOutputResult<bool> { Status = true };
            }
            catch (Exception ex)
            {
                return new GenericOutputResult<bool> { Status = false };
            }
        }

        public async Task<GenericOutputResult<IEnumerable<TblCustomer>>> GetAll()
        {
            try
            {
                var res = await _unitOfWork.customerRepository.GetAllAsync().ConfigureAwait(false);
                return new GenericOutputResult<IEnumerable<TblCustomer>> { Status = true, DataResult = res };
            }
            catch (Exception ex)
            {
                return new GenericOutputResult<IEnumerable<TblCustomer>> { Status = false };
            }
        }

        public async Task<GenericOutputResult<TblCustomer>> GetCustommer(int id)
        {
            try
            {
                var res = await _unitOfWork.customerRepository.GetByIdAsync(id).ConfigureAwait(false);
                return new GenericOutputResult<TblCustomer> { Status = true, DataResult = res };
            }
            catch (Exception ex)
            {
                return new GenericOutputResult<TblCustomer> { Status = false };
            }
        }

        public async Task<GenericOutputResult<QueryResult<TblCustomer>>> GetPaged(QueryObjectParams queryResult)
        {
            try
            {
                var Result = await _unitOfWork.customerRepository.GetPageAsync(queryResult).ConfigureAwait(false);
                return new GenericOutputResult<QueryResult<TblCustomer>> { Status = true, DataResult = Result };
            }
            catch (Exception ex)
            {
                return new GenericOutputResult<QueryResult<TblCustomer>> { Status = false };
            }
        }
    }
}
