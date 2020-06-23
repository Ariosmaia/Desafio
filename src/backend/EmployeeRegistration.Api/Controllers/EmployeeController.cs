using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeRegistration.Application.Interfaces;
using EmployeeRegistration.Application.ViewModels;
using EmployeeRegistration.Domain.Core.Notifications;
using EmployeeRegistration.Domain.Employees.Repository;
using EmployeeRegistration.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Api.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IMapper _mapper;

        public EmployeeController(INotificationHandler<DomainNotification> notifications,
                                 IEmployeeAppService employeeAppService,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, mediator)
        {
            _employeeAppService = employeeAppService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("employees")]
        [AllowAnonymous]
        public ActionResult Get(
            [FromQuery] FilterViewModel filter = null,
            [FromQuery] OrderByViewModel order = null,
            [FromQuery] PaginationViewModel pagination = null)
        {
            return Ok(_employeeAppService.GetAll(filter, order, pagination));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("employees/{id:guid}")]
        public EmployeeViewModel Get(Guid id)
        {
            return _employeeAppService.GetById(id);
        }

        [HttpPost]
        [Route("employees")]
        public IActionResult Post([FromBody]EmployeeViewModel employeeViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            _employeeAppService.Add(employeeViewModel);
            return Response(employeeViewModel);
        }

        [HttpPut]
        [Route("employees")]
        public IActionResult Put([FromBody]EmployeeViewModel employeeViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            _employeeAppService.Update(employeeViewModel);

            return Response(employeeViewModel);
        }

        [HttpDelete]
        [Route("employees/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _employeeAppService.Remove(id);
            return Response();
        }


        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}