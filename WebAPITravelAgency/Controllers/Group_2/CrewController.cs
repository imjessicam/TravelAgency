﻿using DAO.Group_1;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_2.Crew;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Models.Group_1;
using TravelAgency.Repositories.Group_2;

namespace WebAPITravelAgency.Controllers.Group_2
{
    [ApiController]
    [Route("Crew")]
    public class CrewController : ControllerBase
    {
        private readonly CrewRepository _crewRepository;
        private readonly CrewDao _crewDao;
        private readonly CustomerDao _customerDao;


        // 
        public CrewController(CrewRepository crewRepository, CrewDao crewDao, CustomerDao _customerDao)
        {
            _crewRepository = crewRepository;
            _crewDao = crewDao;
        }

        
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromQuery] CreateCrewModel crewMember)
        {
            return Ok(_crewDao.Create(crewMember));
        }

        // Get All

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_crewDao.GetAll());
        }

        // Get        
        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid externalId)
        {
            var foundItem = _crewDao.Find(externalId);
            return Ok(foundItem);
        }

        // Put
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateCrewModel crewToUpdate)
        {
            return Ok(_crewDao.Update(crewToUpdate));
        }

        // Delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid externalId)
        {
            _crewDao.Delete(externalId);
            return Ok();
        }
    }
}