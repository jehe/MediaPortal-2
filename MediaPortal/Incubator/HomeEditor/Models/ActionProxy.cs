using HomeEditor.Groups;
using MediaPortal.Common;
using MediaPortal.UI.Presentation.DataObjects;
using MediaPortal.UI.Presentation.Workflow;
using MediaPortal.UiComponents.SkinBase.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPortal.Common.General;

namespace HomeEditor.Models
{
  public class ActionProxy
  {
    public static readonly Guid HOME_STATE_ID = new Guid("7F702D9C-F2DD-42da-9ED8-0BA92F07787F");

    protected AbstractProperty _displayNameProperty = new WProperty(typeof(string), null);
    protected AbstractProperty _actionIdProperty = new WProperty(typeof(Guid), Guid.Empty);
    protected HomeMenuAction _action;
    protected ItemsList _actionItems = new ItemsList();

    public ActionProxy(HomeMenuAction action)
    {
      _action = action;
      if (_action != null)
      {
        DisplayName = _action.DisplayName;
        ActionId = _action.ActionId;
      }
      UpdateActions();
    }

    public HomeMenuAction GroupAction
    {
      get { return _action; }
    }

    public AbstractProperty DisplayNameProperty
    {
      get { return _displayNameProperty; }
    }

    public string DisplayName
    {
      get { return (string)_displayNameProperty.GetValue(); }
      set { _displayNameProperty.SetValue(value); }
    }

    public AbstractProperty ActionIdProperty
    {
      get { return _actionIdProperty; }
    }

    public Guid ActionId
    {
      get { return (Guid)_actionIdProperty.GetValue(); }
      set { _actionIdProperty.SetValue(value); }
    }

    public ItemsList ActionItems
    {
      get { return _actionItems; }
    }

    protected void UpdateActions()
    {
      var wf = ServiceRegistration.Get<IWorkflowManager>();
      List<WorkflowAction> actions = new List<WorkflowAction>(wf.MenuStateActions.Values);
      _actionItems.Clear();
      AddSubItems(HOME_STATE_ID, actions, _actionItems, true);
      _actionItems.FireChange();
    }

    protected void AddSubItems(Guid targetStateId, List<WorkflowAction> actions, ItemsList items, bool allowNullSource)
    {
      Guid currentActionId = ActionId;
      for (int i = 0; i < actions.Count; i++)
      {
        WorkflowAction action = actions[i];
        if (!IsActionValid(action, targetStateId, allowNullSource))
          continue;

        ListItem item = new ListItem(Consts.KEY_NAME, action.DisplayTitle ?? action.HelpText);
        item.AdditionalProperties[Consts.KEY_ITEM_ACTION] = action;
        if (action.ActionId == currentActionId)
          item.Selected = true;
        item.SelectedProperty.Attach(OnActionItemSelected);
        items.Add(item);
        PushNavigationTransition navigation = action as PushNavigationTransition;
        if (navigation != null)
          AddSubItems(navigation.TargetStateId, actions, items, false);
      }
    }

    protected bool IsActionValid(WorkflowAction action, Guid targetStateId, bool allowNullSource)
    {
      if (action.DisplayTitle == null || string.IsNullOrEmpty(action.DisplayTitle.Evaluate()))
        return false;
      if (action.SourceStateIds == null)
        return allowNullSource;
      return action.SourceStateIds.Contains(targetStateId);
    }

    protected void OnActionItemSelected(AbstractProperty property, object oldValue)
    {
      WorkflowAction selectedAction = _actionItems.Where(a => a.Selected).Select(i => (WorkflowAction)i.AdditionalProperties[Consts.KEY_ITEM_ACTION]).FirstOrDefault();
      if (selectedAction != null)
      {
        DisplayName = selectedAction.DisplayTitle.Evaluate();
        ActionId = selectedAction.ActionId;
      }
    }
  }
}