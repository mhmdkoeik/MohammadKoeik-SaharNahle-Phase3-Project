using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Models;

namespace LMS.Services
{
    public class MemberService
    {
        private ApplicationDbContext db;

        public MemberService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateMemberAccount(string firstName,
                                        string middleName,
                                        string lastName,
                                        string userId,
                                        int membershipID,
                                        DateTime? birth,
                                        string address,
                                        string phonenumber
                                        )
        {
            var accountNumber = (123456 + db.Members.Count()).ToString().PadLeft(10, '0');

            var Member = new Member { FirstName = firstName,
                                      MiddleName =middleName,
                                      LastName = lastName,
                                      DateOfBirth = birth,
                                      Address =address,
                                      PhoneNumber =phonenumber,
                                      ApplicationUserId = userId,
                                      AccountNumber =accountNumber,
                                      MembershipID=membershipID};
            db.Members.Add(Member);
            db.SaveChanges();
        }

        
    }
}