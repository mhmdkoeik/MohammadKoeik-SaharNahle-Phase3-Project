using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LMS.Models;

namespace LMS.Controllers.Api
{
    public class MembersController : ApiController
    {
        // GET api/<controller>
        private ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/books
        public IEnumerable<Member> GetMember(string query)
        {
            var MembersQuery = _context.Members;

            return MembersQuery.ToList();
        }

        // GET api/books/1
        public IHttpActionResult GetMember(int id)
        {
            var member = _context.Members.SingleOrDefault(c => c.ID == id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST api/books/create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult CreateMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var members = member;
            _context.Members.Add(members);
            _context.SaveChanges();

            members.ID = member.ID;
            return Created(new Uri(Request.RequestUri + "/" + members.ID), member);
        }

        // PUT api/books/update/1
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateMember(int id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var memberInDb = _context.Members.SingleOrDefault(c => c.ID == id);

            if (memberInDb == null)
            {
                return NotFound();
            }

            member = memberInDb;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/books/1
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteMember(int id)
        {
            var memberInDb = _context.Members.SingleOrDefault(c => c.ID == id);

            if (memberInDb == null)
            {
                return NotFound();
            }

            _context.Members.Remove(memberInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}