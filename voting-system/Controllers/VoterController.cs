using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using voting_system.Dto;

namespace voting_system.Controllers
{
    [Route("api/voters")]
    [ApiController]
    public class VoterController : BaseController
    {
        public VoterController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public ActionResult<List<Voter>> GetAll()
        {
            return Ok(_unitOfWork.Voters.GetAll());
        }

        [HttpPut("update-age/{id}")]
        public ActionResult UpdateAge(int id, [FromQuery] int age)
        {
            var voter = _unitOfWork.Voters.Get(id);
            if(voter != null)
            {
                voter.Age = age;
                _unitOfWork.Voters.Update(voter);
                _unitOfWork.Complete();

                return Ok("Updated");
            }
            else
            {
                return NotFound("Not found");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Voter> Get(int id)
        {
            var voter = _unitOfWork.Voters.Get(id);

            return voter != null ? Ok(voter) : NotFound("voter not found");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.Voters.Remove(new Voter { Id = id });
                _unitOfWork.Complete();

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public ActionResult<Voter> Create([FromBody] CreateVoter voter)
        {
            Voter voterEntity = voter;
            _unitOfWork.Voters.Add(voterEntity);
            _unitOfWork.Complete();

            return CreatedAtAction(nameof(Get), new { id = voterEntity.Id }, voterEntity);
        }
    }
}
