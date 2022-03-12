using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using voting_system.Dto;

namespace voting_system.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : BaseController
    {
        public CandidateController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public ActionResult<List<Candidate>> GetAll()
        {
            return Ok(_unitOfWork.Candidates.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(int id)
        {
            var candidate = _unitOfWork.Candidates.Get(id);
            return candidate != null ? Ok(candidate) : NotFound("Candidate not found");
        }

        [HttpPost("create")]
        public ActionResult<Candidate> Create([FromBody] CreateCandidate candidate)
        {
            Candidate candidateEntity = candidate;
            try
            {
                _unitOfWork.Candidates.Add(candidateEntity);
                _unitOfWork.Complete();
                return CreatedAtAction(nameof(Get), new { id = candidateEntity.Id }, candidateEntity);
            }
            catch (Exception)
            {
                return BadRequest("please provide the proper input data");
            }
        }

        [HttpGet("vote-count/{id}")]
        public async Task<ActionResult<int>> VoteCount(int id)
        {
            var voteCount = await _unitOfWork.Candidates.VoteCount(id);
            return voteCount != null ? Ok(voteCount) : NotFound("Candidate not found");
        }
    }
}
