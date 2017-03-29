using System.Collections.Generic;
using AppFoundry.Business.Core;
using AppFoundry.Core;
using IssueTracker.Business.Enums;

namespace IssueTracker.Business
{
    public partial class Issue
    {
        public Issue()
        {
            //The default constructor is also used when loading objects from the database so we need to make sure this is a new object.
            if (State == State.New)
            {
                //Set some defaults. 
                //These are no longer nullable so they must be filled in at the time the object is created and can no longer be cleared.
                //This allows the generated accessors to use the non-nullable types requiring less checking in the code.
                //Some of these are also no longer settable publicly(such as CreateByUser and CreatedDate)
                CreatedByUser = BusinessApplicationManager.Instance.User;
                CreatedDate = Date.Now;
                Priority = IssuePriorityEnums.Low;
                Status = IssueStatusEnums.Open;
                Type = IssueTypeEnums.Bug;
                new Task(this) { Description = "Do something with this issue..." };
            }
        }

        public void Open()
        {
            if (Status != IssueStatusEnums.Open)
            {
                Status = IssueStatusEnums.Open;
            }
        }

        public void Close()
        {
            if (Status != IssueStatusEnums.Closed)
            {
                Tasks.ForEach(task => task.Status = TaskStatusEnums.Closed);
                Status = IssueStatusEnums.Closed;
            }
        }

        public List<Task> Tasks
        {
            get
            {
                //Note: Load() will resolve based on database and in memory changes. 
                //So any unsaved tasks will still be loaded(if they match the filter criteria)
                return Task.Load(Task.PropertyIssueID == IssueID);
            }
        }

        public List<IssueDocument> Documents
        {
            get
            {
                return IssueDocument.Load(IssueDocument.PropertyIssueID == IssueID);
            }
        }

        public List<IssueHistory> Histories
        {
            get
            {
                return IssueHistory.Load(IssueHistory.PropertyIssueID == IssueID);
            }
        }

        protected override void EventBeforeUpdated(BeforeUpdatedArgs args)
        {
            //This is an example of pro-active validation. It can be used to prevent setting the 
            //object into an invalid state. Any errors for a property will prevent it from being updated. 
            //Errors for type or nullability checking will be handled automatically.
            if (args.Property == PropertyStepsToReproduce)
            {
                if (args.ProposedStringValue != null && Type != IssueTypeEnums.Bug)
                {
                    args.AddError("Cannot set if type is not '" + IssueTypeEnums.Bug.Name + "'.");
                }
            }
        }

        /// <summary>
        /// This is triggered when a property is updated. 
        /// Properties are only updated if they pass type and nullability checks,  are different than the current
        /// value, and pass any validations added in EventBeforeUpdated().
        /// </summary>
        protected override void EventUpdated(UpdatedArgs args)
        {
            if (args.Property == PropertyTypeID)
            {
                StepsToReproduce = null;
            }

            UpdateIssueHistoryRecord();
        }

        /// <summary>
        /// This is triggered on save, before anything is persisted. 
        /// If any validation for any object fails no objects will be persisted.
        /// </summary>
        protected override void EventValidated(ValidatedArgs args)
        {
            //This is an example of reactive validation. The object is allowed to be in an invalid state 
            //but cannot be persisted until there are no more errors. 
            if (Type == IssueTypeEnums.Bug && StepsToReproduce == null)
            {
                args.AddError(PropertyStepsToReproduce, "Required if type is '" + IssueTypeEnums.Bug.Name + "'.");
            }

            if (Status == IssueStatusEnums.Open && Task.Load(Task.PropertyIssueID == IssueID & Task.PropertyStatusID[Lookup.PropertyCode] != TaskStatusEnums.CODE_CLOSED).Count == 0)
            {//Issue is open but all tasks are closed

                args.AddError(IssueStatusEnums.Open.Name + " Issues require at least one Task that is not " + TaskStatusEnums.Closed.Name + ".");
            }
        }

        protected override void EventBeforeDeleted(BeforeDeletedArgs args)
        {
            //When deleting an object it will check for related objects, that have not been deleted, similar to a foreign key constraint in the database.
            //If there are any that aren't handled it will return an error and deletion of the object will not take place.
            //This will explicity indicate that we will handle deletion of these objects ourselves(in EventDeleted)
            args.AddHandledType(Task.PropertyIssueID);
            args.AddHandledType(IssueDocument.PropertyIssueID);
            args.AddHandledType(IssueHistory.PropertyIssueID);
        }

        protected override void EventDeleted(DeletedArgs args)
        {
            //delete any related objects explicitly. This is required once there is generated code.
            Tasks.ForEach(task => task.Delete());
            Documents.ForEach(document => document.Delete());
            Histories.ForEach(history => history.Delete());
        }

        /// <summary>
        /// Property accessibility can be set dynamically. This allows overriding of the defaults created at design time
        /// </summary>
        protected override void EventGetPropertyAccessibility(PropertyAccessibilityArgs args)
        {
            //Make all fields readonly if the issue is closed.
            if (Status == IssueStatusEnums.Closed)
            {
                args.Accessibility = PropertyAccessibility.PublicReadOnly;
            }
        }

        private void UpdateIssueHistoryRecord()
        {
            BusinessObjectChanges changes = GetChanges();

            //new records have a negative primary key value so this will load any history records for this issue that are new.
            List<IssueHistory> currentHistoryRecord = IssueHistory.Load(IssueHistory.PropertyIssueID == IssueID & IssueHistory.PropertyIssueHistoryID < 0);

            if (currentHistoryRecord.Count == 1 && changes.ChangedProperties.Count != 0)
            {//record exists and needs to be updated

                currentHistoryRecord[0].UpdateChangesString(changes.ToString());
            }
            else if (currentHistoryRecord.Count == 1 && changes.ChangedProperties.Count == 0)
            {//record exists but there are no longer changes

                currentHistoryRecord[0].Delete();
            }
            else if (currentHistoryRecord.Count == 0 && changes.ChangedProperties.Count != 0)
            {//no record exists and there are some changes

                new IssueHistory(this, changes.ToString());
            }
        }
    }
}
