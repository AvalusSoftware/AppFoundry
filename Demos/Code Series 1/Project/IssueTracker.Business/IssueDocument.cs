using System;

namespace IssueTracker.Business
{
    public partial class IssueDocument
    {
        //required for loading records from the database
        private IssueDocument()
        {
        }

        //IssueDocument records can only be created from an issue.
        public IssueDocument(Issue issue)
        {
            if (issue == null)
            {
                throw new Exception("Issue is required.");
            }

            Issue = issue;
        }

    }
}
