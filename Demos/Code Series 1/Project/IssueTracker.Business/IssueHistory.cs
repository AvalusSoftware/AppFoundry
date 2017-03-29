using System;
using AppFoundry.Business.Core;
using AppFoundry.Core;
using Environment = System.Environment;

namespace IssueTracker.Business
{
    public partial class IssueHistory
    {
        //required for loading records from the database
        private IssueHistory()
        {
        }

        //History records can only be created from an issue.
        internal IssueHistory(Issue issue,string changes)
        {
            if (issue == null)
            {
                throw new Exception("Issue is required.");
            }

            Issue = issue;
            CreatedByUser = BusinessApplicationManager.Instance.User;
            CreatedDate = Date.Now;
            CreatedTime = Time.Now;
            UpdateChangesString(changes);
        }

        internal void UpdateChangesString(string changesString)
        {
            if (Issue.State == State.New)
            {
                Changes = "New Issue Created" + Environment.NewLine + changesString;
            }
            else
            {
                Changes = changesString;
            }
        }
    }
}
