using NUnit.Framework;
using Shouldly;
using ExpressiveExtensions.Core;
using System.Collections.Generic;

namespace ExpressiveExtensions.UnitTest
{
    [TestFixture]
    public class StringValidationsTests
    {
        [Test]
        public void IsEmailAddress_With_GoodEmails_ShouldReturn_True()
        {
            // Arrange
            var emails = GetGoodEmails();

            // Act
            foreach (var email in emails)
            {
                var results = email.IsEmailAddress();

                // Assert
                email.ShouldNotBeNullOrWhiteSpace();
                results.ShouldBeTrue("Email fail: " + email);
            }
        }

        [Test]
        public void IsEmailAddress_With_BadEmails_ShouldReturn_False()
        {
            // Arrange
            var emails = GetBadEmails();

            // Act
            foreach (var email in emails)
            {
                var results = email.IsEmailAddress();

                // Assert
                email.ShouldNotBeNullOrWhiteSpace();
                results.ShouldBeFalse("Email fail: " + email);
            }
        }

        private static List<string> GetBadEmails()
        {
            List<string> emails = new List<string>();
            emails.Add("joe"); // should fail
            emails.Add("joe@home"); // should fail
            emails.Add("a@b.c"); // should fail because .c is only one character but must be 2-4 characters
            emails.Add("joe-bob[at]home.com"); // should fail because [at] is not valid
            emails.Add("joe@his.home.place"); // should fail because place is 5 characters but must be 2-4 characters
            emails.Add("joe.@bob.com"); // should fail because there is a dot at the end of the local-part
            emails.Add(".joe@bob.com"); // should fail because there is a dot at the beginning of the local-part
            emails.Add("john..doe@bob.com"); // should fail because there are two dots in the local-part
            emails.Add("john.doe@bob..com"); // should fail because there are two dots in the domain
            emails.Add("joe<>bob@bob.com"); // should fail because <> are not valid
            emails.Add("joe@his.home.com."); // should fail because it can't end with a period
            //emails.Add("john.doe@bob-.com"); // should fail because there is a dash at the start of a domain part
            //emails.Add("john.doe@-bob.com"); // should fail because there is a dash at the end of a domain part
            emails.Add("a@10.1.100.1a");  // Should fail because of the extra character
            emails.Add("joe<>bob@bob.com\n"); // should fail because it end with \n
            emails.Add("joe<>bob@bob.com\r"); // should fail because it ends with \r
            return emails;
        }

        private static List<string> GetGoodEmails()
        {
            List<string> emails = new List<string>();
            emails.Add("joe@home.org");
            emails.Add("joe+pepe@home.org");
            emails.Add("joe@joebob.name");
            emails.Add("joe&bob@bob.com");
            emails.Add("~joe@bob.com");
            emails.Add("joe$@bob.com");
            emails.Add("joe+bob@bob.com");
            emails.Add("o'reilly@there.com");
            emails.Add("joe@home.com");
            emails.Add("joe.bob@home.com");
            emails.Add("joe@his.home.com");
            emails.Add("a@abc.org");
            emails.Add("a@abc-xyz.org");
            emails.Add("a@192.168.0.1");
            emails.Add("a@10.1.100.1");
            return emails;
        }
    }
}
