using System;
using System.Collections.Generic;
using System.Reflection;
using AppFoundry.Core;
using AppFoundry.Business.Core;
using IssueTracker.Business;
using IssueTracker.Business.Enums;

namespace ConsoleApp
{
    class Program
    {
        private static readonly string _IssueOneDescription = Guid.NewGuid().ToString();
        private static readonly string _IssueTwoDescription = Guid.NewGuid().ToString();
        private static readonly string _NewDescription = Guid.NewGuid().ToString();

        static void Main(string[] args)
        {
            //TODO change server name to your local machine!!

            //Initialize the system. This manager is thread and session safe. 
            //It only needs to be initialized once when the application is started. In session based scenarios subsequent sessions will be handled automatically.
            //It takes in a database connection object as well as any assemblies that have generated code.
            InitializationErrors initializationErrors = BusinessApplicationManager.Initialize(new DatabaseConnectionInfo("C3\\SQLExpress", "IssueTrackerDev")
                                                                                              ,Assembly.GetAssembly(typeof(Issue)));

            //If you have any errors check that the script('Update IssueTracker Module(for Code Series 1).sql' in the 'scripts' folder) has been run on the issuetrackerdev database.
            //If you are starting from scratch(without doing Design Series 1) see readme.txt in 'scripts' folder to catch up.
            Debug.Assert(initializationErrors.Count == 0);


            #region Creating Objects
            {
                //Create a new issue
                var issueOne = new Issue();
                Debug.Assert(issueOne.State == State.New); //objects have a state to indicate if they are 'New', 'Unchanged', 'Updated', or 'Deleted'.
                Debug.Assert(true, "Break here");

                //Try to save the issue
                ValidationErrors errors = BusinessApplicationManager.Instance.SaveChanges();

                //Since we haven't filled in all the required fields this should result in some errors. Nothing is saved to the database
                Debug.Assert(errors.Count != 0);

                //Recurse through all the errors
                foreach (BusinessObjectValidationErrors businessObjectErrors in errors)
                {
                    BusinessObject objectWithErrors = businessObjectErrors.BusinessObject;

                    foreach (BusinessObjectValidationError businessObjectError in businessObjectErrors)
                    {
                        Property errorProperty = businessObjectError.Property; //this can be null if the error is for the object as a whole and not for a particular property.
                        string errorMessage = businessObjectError.Message;
                        Debug.Assert(true, "Break here");
                    }
                }

                //Fill in the required fields. See Issue constructor for more examples.
                issueOne.Description = _IssueOneDescription;
                issueOne.Type = IssueTypeEnums.ChangeRequest; //generated enumerations make setting values for enumerable types(such as lookups) simpler.

                //If you look at the constructor for issue you'll see that it also creates a task. This requires an assigned user and description
                Task task = issueOne.Tasks[0];
                task.AssignedUser = BusinessApplicationManager.Instance.User; //the current user is stored in the business application manager.
                task.Description = "Description";

                //try saving again. This time it should work
                errors = BusinessApplicationManager.Instance.SaveChanges();
                Debug.Assert(errors.Count == 0);
                Debug.Assert(issueOne.State == State.Unchanged);
                Debug.Assert(task.State == State.Unchanged);
                Debug.Assert(true, "Break here");

                //Create another issue for next examples
                var issueTwo = new Issue { Description = _IssueTwoDescription, StepsToReproduce = "1)Starting from main menu one..." };
                var taskTwo = issueTwo.Tasks[0];
                taskTwo.AssignedUser = BusinessApplicationManager.Instance.User;
                taskTwo.Description = _IssueTwoDescription;

                errors = BusinessApplicationManager.Instance.SaveChanges();
                Debug.Assert(errors.Count == 0);
            }
            #endregion

            #region Reading Objects
            {
                //Load all issues
                List<Issue> issues = Issue.Load();

                //Load all issues created today
                List<Issue> issuesCreatedToday = Issue.Load(Issue.PropertyCreatedDate == Date.Now);

                //Same as above with filter expression created explicitly
                Filter issuesCreatedTodayFilter = Issue.PropertyCreatedDate == Date.Now;
                issuesCreatedToday = Issue.Load(issuesCreatedTodayFilter);

                //Filter operators
                Filter equalToFilter = Issue.PropertyCreatedDate == Date.Now;
                Filter notEqualFilter = Issue.PropertyCreatedDate != DBNull.Value;
                Filter greaterThanFilter = Issue.PropertyCreatedDate > Date.Now;
                Filter greaterThanEqualFilter = Issue.PropertyCreatedDate >= Date.Now;
                Filter lessThanFilter = Issue.PropertyCreatedDate < Date.Now;
                Filter lessThanEqualFilter = Issue.PropertyCreatedDate <= Date.Now;
                Filter likeFilter = Issue.PropertyDescription % "%crashes%";
                Filter notLikeFilter = Issue.PropertyDescription ^ "%crashes%";

                //Create a couple filters
                Filter createdToday = Issue.PropertyCreatedDate == Date.Now;
                Filter descriptionContainsSomeText = Issue.PropertyDescription % "%crashes%";

                //AND two filters
                Filter createdTodayAndDescriptionContainsSomeText = createdToday & descriptionContainsSomeText;
                //Same as
                Filter createdTodayAndDescriptionContainsSomeText2 = Issue.PropertyCreatedDate == Date.Now
                                                                   & Issue.PropertyDescription % "%crashes%";

                //OR two filters
                Filter createdTodayOrDescriptionContainsSomeText = createdToday | descriptionContainsSomeText;
                //Same as
                Filter createdTodayOrDescriptionContainsSomeText2 = Issue.PropertyCreatedDate == Date.Now
                                                                  | Issue.PropertyDescription % "%crashes%";

                //Order of precedence can be specified using brackets
                Filter createTodayAndDescriptionLikeOneOrTheOther = Issue.PropertyCreatedDate == Date.Now
                                                                   & (Issue.PropertyDescription % "%crashes%"
                                                                     | Issue.PropertyDescription % "%locks up%");


                //RELATIONAL FILTERS

                //Joining from Issue.Type to lookup code.
                //
                //               Lookup.Code == "ChangeRequest"
                //                  ^
                //                  |
                //Issue.TypeID->IssueType

                //Load all issues that are change requests.
                List<Issue> changeRequestIssues = Issue.Load(Issue.PropertyTypeID[IssueType.PropertyCode] == IssueTypeEnums.CODE_CHANGEREQUEST);

                //Relation filters work the same as other filters act the same as other filter expressions.
                List<Issue> changeRequestOrBugIssues = Issue.Load(Issue.PropertyTypeID[IssueType.PropertyCode] == IssueTypeEnums.CODE_CHANGEREQUEST
                                                                | Issue.PropertyTypeID[IssueType.PropertyCode] == IssueTypeEnums.CODE_BUG);


                //Filters can also be applied to objects already in memory using the matches method for a business object.
                bool isTypeOther = changeRequestOrBugIssues[0].Matches(Issue.PropertyTypeID[IssueType.PropertyCode] == IssueTypeEnums.CODE_OTHER);
                Debug.Assert(!isTypeOther);


                //FILTERS AND INHERITANCE

                //Inheritance of lookups:
                //        --IssueStatus
                //       /
                // Lookup---IssueType
                //       \     
                //        --TaskStatus

                //Load all lookups
                List<Lookup> allLookups = Lookup.Load();
                Debug.Assert(true, "Break here");

                //Load just the issue statuses
                List<IssueStatus> allIssueStatuses = IssueStatus.Load();
                Debug.Assert(true, "Break here");

                //Load based on a super type property(load issue status based on code(a lookup property))
                IssueStatus openIssueStatus = IssueStatus.Load(Lookup.PropertyCode == IssueStatusEnums.CODE_OPEN)[0];
                Debug.Assert(true, "Break here");

                //Load based on a sub type property(only load lookups that are issue statuses or task statuses)
                List<Lookup> looksThatAreStatuses = Lookup.Load(IssueStatus.PropertyIssueStatusID != DBNull.Value
                                                               | TaskStatus.PropertyTaskStatusID != DBNull.Value);
                Debug.Assert(true, "Break here");

                //SORTING

                //The Load method can also specify sort parameters. In this case it loads all issues created today sorted by description.
                Issue.Load(Issue.PropertyCreatedDate == Date.Now, new SortParameter(Issue.PropertyDescription, SortDirection.Ascending));

                //COUNTING

                //The Count method performs a count using a filter. This is more efficient than loading the objects and then counting them.
                Debug.Assert(Issue.Count(Issue.PropertyDescription == _IssueOneDescription | Issue.PropertyDescription == _IssueTwoDescription) == 2);

                //PAGING

                //Load first 100 issues. If no sort parameters are specified it will use ID.
                QueryResult queryResult = Issue.CreateQuery().Load(null, 0, 100);
                foreach (Issue issue in queryResult)
                {
                    //do something                    
                }

                //Load 100 issues at a time and perform some action until there are no more issues to load.If no sort parameters are specified it will use ID.
                Issue.CreateQuery().LoadAllPages(null, 100, pageQueryResult =>
                {
                    foreach (Issue issue in pageQueryResult)
                    {
                        //do something for each issue in this page
                    }
                });

            }
            #endregion

            #region Updating Objects
            {
                //Load issueOne created earlier
                Issue issueOne = Issue.Load(Issue.PropertyDescription == _IssueOneDescription)[0];
                Issue issueOneDuplicate = Issue.Load(Issue.PropertyDescription == _IssueOneDescription)[0];

                //Loading duplicate objects never duplicates the data and the objects are considered equivalent even if they are different references
                Debug.Assert(issueOne == issueOneDuplicate);
                Debug.Assert(true, "Break here");

                //Update description for issueOne.
                issueOne.Description = _NewDescription;
                Debug.Assert(issueOne.State == State.Updated);

                //IssueOne and IssueOneDuplicate share the same underlying data even though they were loaded seperately. Data is not duplicated in memory.
                Debug.Assert(issueOne.Description == _NewDescription);
                Debug.Assert(issueOneDuplicate.Description == _NewDescription);
                Debug.Assert(true, "Break here");

                //loading objects reconciles changes between the database and in memory
                //Since we've updated issueOne to a new description it no longer loads using the original filter expression.
                Debug.Assert(Issue.Load(Issue.PropertyDescription == _IssueOneDescription).Count == 0);
                Debug.Assert(true, "Break here");

                //It can now be loaded using the new description even though nothing has been persisted to the database.
                //This can be seen as similar to a long running transaction in sql server. However, this is all in memory and no database locking occurs.
                Debug.Assert(Issue.Load(Issue.PropertyDescription == _NewDescription).Count == 1);
                Debug.Assert(true, "Break here");

                //Properties can also be set generically
                issueOne[Issue.PropertyDescription] = _NewDescription;

                try
                {
                    //accessibility, nullability, incorrect data type, and any additional rules added in EventBeforeUpdated can cause updates to throw exceptions
                    //CreatedDate has no public setter so updating it generically is the only way to try updating it.
                    issueOne[Issue.PropertyCreatedDate] = Date.Now;
                }
                catch (Exception exception)
                {
                    //This will throw a validation exception(due to accessibility)
                    Debug.Assert(exception is ValidationException);
                    string message = exception.Message;
                }

                //TrySetValue is useful in cases where you want to set a value without throwing exceptions(e.g. in mapping code).
                BusinessObjectValidationErrors validationErrors = issueOne.TrySetValue(Issue.PropertyCreatedDate, Date.Now);
                Debug.Assert(validationErrors.Count != 0);


                //Once an object is updated it can be saved as before
                ValidationErrors errors = BusinessApplicationManager.Instance.SaveChanges();
                Debug.Assert(errors.Count == 0);

            }
            #endregion

            #region Deleting Objects
            {
                //Load issueTwo created earlier.
                Issue issueTwo = Issue.Load(Issue.PropertyDescription == _IssueTwoDescription)[0];

                //Delete it
                issueTwo.Delete();
                Debug.Assert(issueTwo.State == State.Deleted);

                //Save the changes
                ValidationErrors errors = BusinessApplicationManager.Instance.SaveChanges();
                Debug.Assert(errors.Count == 0);

                //Objects that have successfully been deleted have a status of Gone. 
                //These objects can be longer be updated and will be garbage collected when they go out of scope.
                Debug.Assert(issueTwo.State == State.Gone);
                Debug.Assert(true, "Break here");

                //IssueTwo had two related objects; a task and a history object. 
                //Normally deleting it, without first deleting those objects, would throw a validation exception.
                //However, the Issue class overrides the method EventBeforeDeleted and signals it's intention to handle these related object types explicitly.
                //It then deletes them in the method EventDeleted. This pattern allows delevelopers to handle deletion of related types programatically.

                try
                {
                    //Issue status has related issues(that it doesn't explicitly handle) so it can't be deleted.
                    IssueStatus.Load()[0].Delete();
                }
                catch (Exception exception)
                {
                    //This will throw a validation exception
                    Debug.Assert(exception is ValidationException);
                    string message = exception.Message;
                    Debug.Assert(true, "Break here");
                }


                //TryDelete is useful in cases where you want to try to delete and object without throwing exceptions(e.g. user interface code)
                BusinessObjectValidationErrors validationErrors = IssueStatus.Load()[0].TryDelete();
                Debug.Assert(validationErrors.Count != 0);
                Debug.Assert(true, "Break here");

            }
            #endregion

        }
    }
}
