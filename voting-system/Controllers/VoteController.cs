using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using voting_system.Dto;

namespace voting_system.Controllers
{
    [Route("api/votes")]
    [ApiController]
    public class VoteController : BaseController
    {
        public VoteController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("{id}")]
        public ActionResult<Vote> Get(int id)
        {
            var vote = _unitOfWork.Votes.Get(id);

            return vote != null ? Ok(vote) : NotFound("vote not found");
        }

        [HttpPost]
        public ActionResult Vote([FromBody] CreateVote vote)
        {
            var voter = _unitOfWork.Voters.Get(vote.VoterID);

            if(voter != null && CheckVoteValidity(vote, voter))
            {
                Vote voteEntity = vote;
                _unitOfWork.Votes.Add(voteEntity);
                _unitOfWork.Complete();

                return CreatedAtAction(nameof(Get), new { id = voteEntity.Id }, voteEntity);
            }
            else
            {
                return BadRequest();
            }
        }

        private bool CheckVoteValidity(CreateVote vote, Voter voter)
        {

            var voteObj = _unitOfWork.Votes.VoteByUserAndCategory(vote.VoterID, vote.CategoryId);
            return voter.CanVote() && voteObj == null;
        }
    }
}
