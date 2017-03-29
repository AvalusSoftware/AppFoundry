using AppFoundry.Core;
using AppFoundry.Forms;
using IssueTracker.Business;
using IssueTracker.Business.Enums;

namespace IssueTracker.Forms
{
    public partial class IssueDetailsController<BUSINESS_OBJECT>
    {
        protected override void EventInitialize()
        {
            _ButtonOpenIssue.OnClick += ButtonOpenIssue_OnClick;
            _ButtonCloseIssue.OnClick += ButtonCloseIssue_OnClick;
            _ComboBoxTypeID.OnValueChanged += ComboBoxTypeID_OnValueChanged;
            _ComboBoxStatusID.OnValueChanged += ComboBoxStatusID_OnValueChanged;

            SetStepsToReproduceDisplayState();
            SetButtonOpenDisplayState();
            SetButtonCloseDisplayState();
        }

        protected override void EventBusinessObjectUpdated(DetailsBusinessObjectUpdatedArgs args)
        {
            //When issues are updated they can sometimes affect data for tasks or history objects. Make sure the related summaries show these changes.
            IssueHistorySummaryController.Refresh();
            TaskSummaryController.Refresh();
        }

        private void SetStepsToReproduceDisplayState()
        {
            if (_ComboBoxTypeID.Value == IssueTypeEnums.Bug)
            {
                _PanelStepsToReproduce.IsVisible = true;
            }
            else
            {
                _PanelStepsToReproduce.IsVisible = false;
            }
        }

        private void SetButtonOpenDisplayState()
        {
            if (BusinessObject.State == State.Unchanged && _ComboBoxStatusID.Value != IssueStatusEnums.Open)
            {
                _PanelOpenIssue.IsVisible = true;
            }
            else
            {
                _PanelOpenIssue.IsVisible = false;
            }
        }

        private void SetButtonCloseDisplayState()
        {
            if (BusinessObject.State == State.Unchanged && _ComboBoxStatusID.Value != IssueStatusEnums.Closed)
            {
                _PanelCloseIssue.IsVisible = true;
            }
            else
            {
                _PanelCloseIssue.IsVisible = false;
            }
        }

        private void ComboBoxTypeID_OnValueChanged(BusinessObjectComboBoxControlValueChangedArgs<IssueType> args)
        {
            SetStepsToReproduceDisplayState();
        }

        private void ComboBoxStatusID_OnValueChanged(BusinessObjectComboBoxControlValueChangedArgs<IssueStatus> args)
        {
            SetButtonOpenDisplayState();
            SetButtonCloseDisplayState();
        }

        private void ButtonCloseIssue_OnClick(ButtonClickArgs args)
        {
            BusinessObject.Close();
        }

        private void ButtonOpenIssue_OnClick(ButtonClickArgs args)
        {
            BusinessObject.Open();
        }
    }
}