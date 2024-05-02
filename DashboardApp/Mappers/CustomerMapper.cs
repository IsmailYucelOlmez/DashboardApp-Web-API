using DashboardApp.DTO.Customer;
using DashboardApp.DTO.User;
using DashboardApp.Models;

namespace DashboardApp.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto
            {
                ID = customerModel.Id,
                CName = customerModel.Cname,
                Cmail = customerModel.Cmail,
                CPhone = customerModel.Cphone,
                CBudget = customerModel.Cbudget,
                CImage = customerModel.Cimage,
                CStatu = customerModel.Cstatu,
                CLocation= customerModel.Clocation

            };
        }

        public static Customer ToCustomerFromCreateDto(this CreateCustomerRequestDto customerDto)
        {
            return new Customer
            {
                Cname = customerDto.CName,
                Cmail = customerDto.Cmail,
                Cphone = customerDto.CPhone,
                Cbudget = customerDto.CBudget,
                Cimage = customerDto.CImage,
                Cstatu = customerDto.CStatu,
                Clocation = customerDto.CLocation

            };
        }
    }
}
