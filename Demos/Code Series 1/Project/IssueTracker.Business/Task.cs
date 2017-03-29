using System;
using AppFoundry.Core;
using IssueTracker.Business.Enums;

namespace IssueTracker.Business
{
    public partial class Task
    {
        //required for loading records from the database
        private Task()
        {
        }

        //Tasks can only be created from an issue.
        public Task(Issue issue)
        {
            //example of a non-recoverable error. In the website this causes the system to log the error and shutdown for the current session.
            if (issue == null)
            {
                throw new Exception("Issue is required.");
            }

            //example of a recoverable error. In the website this will show any errors to the user.
            //If there are any errors here it will rollback the system to a point before the object was created and throw a ValidationException 
            //The system remains in a valid state. This is useful for input or user errors that result from creating objects.
            //(try this out by creating a task on a closed issue)
            CheckInstantiationErrors(errors =>
            {
                if (issue.Status == IssueStatusEnums.Closed)
                {
                    errors.AddError(PropertyIssueID, "Cannot add tasks to an issue with a status of '" + IssueStatusEnums.Closed.Name + "'.");
                }
            });

            Issue = issue;
            CreatedDate = Date.Now;
            Status = TaskStatusEnums.New;
        }

        /// <summary>
        /// Property accessibility can be set dynamically. This allows overriding of the defaults created at design time
        /// </summary>
        protected override void EventGetPropertyAccessibility(PropertyAccessibilityArgs args)
        {
            //Make all fields readonly if the issue is closed.
            if (Issue.Status == IssueStatusEnums.Closed)
            {
                args.Accessibility=PropertyAccessibility.PublicReadOnly;
            }
        }
    }
}
