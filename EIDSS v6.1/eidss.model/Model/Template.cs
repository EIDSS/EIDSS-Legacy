using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.common.Core;
using eidss.model.Enums;
using eidss.model.Model.FlexibleForms.Helpers;

namespace eidss.model.Schema
{
    public partial class Template
    {
        public void RulesCheckRoutines(List<Rule> rules, FFPresenterModel ff, out List<Rule> executedRules, out List<Rule> enablingRules)
        {
            //правила, которые выполнились
            executedRules = new List<Rule>();
            //правила, которые не выполнились, но по которым надо разблокировать контролы
            enablingRules = new List<Rule>();

            if (!ff.CurrentObservation.HasValue) return;
            var idObservation = ff.CurrentObservation.Value;
            foreach (var rule in rules)
            {
                //получаем значение параметра
                //если значение не задано, то правило игнорируется
                //TODO обработать табличные значения
                var value1 = ff.ActivityParameters.GetActivityParameter(false, idObservation, rule.ParametersLookup[0].idfsParameter);
                //if ((rule.idfsRuleFunction != (long)FFRuleFunctions.Empty || rule.idfsRuleFunction != (long)FFRuleFunctions.Value) && (Utils.IsEmpty(value1) || Utils.IsEmpty(value1.varValue))) return;
                if (Utils.IsEmpty(value1) || Utils.IsEmpty(value1.varValue))
                {
                    if (!(
                             (rule.idfsRuleFunction == (long) FFRuleFunctions.Empty)
                             || (rule.idfsRuleFunction == (long) FFRuleFunctions.Value)
                         )) return;
                }
                
                ActivityParameter value2 = null;
                if (rule.intNumberOfParameters == 2)
                {
                    value2 = ff.ActivityParameters.GetActivityParameter(false, idObservation, rule.ParametersLookup[1].idfsParameter);
                    if (Utils.IsEmpty(value2) || Utils.IsEmpty(value2.varValue)) return;
                }
                //метка того, что условия для срабатывания правила выполнились
                var conditionsDone = false; //изначально не соблюдены
                //выполняем действия в зависимости от типа правила
                switch (rule.idfsRuleFunction)
                {
                    case (long)FFRuleFunctions.CurrentDate:
                        var dt = ((DateTime)value1.varValue).Date;
                        if (dt <= DateTime.Now.Date) conditionsDone = true;
                        break;
                    case (long)FFRuleFunctions.Empty:
                        if (Utils.IsEmpty(value1) || Utils.IsEmpty(value1.varValue)) conditionsDone = true;
                        break;
                    case (long)FFRuleFunctions.Value:
                        //если есть константы, с которыми надо сравнивать, то сравним с каждой из них
                        foreach (var constant in rule.ConstantsLookup)
                        {
                            if (Utils.IsEmpty(constant.varConstant) || constant.varConstant.ToString() == "-1")
                            {
                                if (value1 == null || Utils.IsEmpty(value1.varValue))
                                {
                                    conditionsDone = true;
                                    break;
                                }
                            }
                            else if (value1 != null && value1.varValue != null)
                            {
                                //сравним как строки
                                if (constant.varConstant.ToString().Equals(value1.varValue.ToString()))
                                {
                                    conditionsDone = true;
                                    break;
                                }
                            }
                        }
                        break;
                    case (long)FFRuleFunctions.Greater:
                        double d1;
                        double d2;
                        DateTime dt1;
                        DateTime dt2;

                        if (value2 != null)
                        {
                            var p1 = value1.varValue.ToString();
                            var p2 = value2.varValue.ToString();

                            if (Double.TryParse(p1, out d1) &&
                                Double.TryParse(p2, out d2))
                            {
                                if (d1 > d2) conditionsDone = true;
                            }
                            else if (DateTime.TryParse(p1, out dt1) &&
                                     DateTime.TryParse(p2, out dt2))
                            {
                                if (dt1 > dt2) conditionsDone = true;
                            }
                        }
                        break;
                    case (long)FFRuleFunctions.GreaterEqual:
                        if (value2 != null)
                        {
                            var p1 = value1.varValue.ToString();
                            var p2 = value2.varValue.ToString();

                            if (Double.TryParse(p1, out d1) &&
                                Double.TryParse(p2, out d2))
                            {
                                if (d1 >= d2) conditionsDone = true;
                            }
                            else if (DateTime.TryParse(p1, out dt1) &&
                                     DateTime.TryParse(p2, out dt2))
                            {
                                if (dt1 >= dt2) conditionsDone = true;
                            }
                        }
                        break;
                }
                //накладываем условие отрицания, если оно есть
                if (rule.blnNot) conditionsDone = !conditionsDone;
                if (conditionsDone)
                {
                    executedRules.Add(rule);
                }
                else if (rule.ActionsLookup.Any(c => c.idfsRuleAction == (long)FFRuleActions.Disabled))
                {
                    enablingRules.Add(rule);
                }
            }
        }

        /// <summary>
        /// ИД корневого объекта, которому принадлежит ФФ (например, Human Case, Vet Case, Vs Session)
        /// </summary>
        //public long RootKeyID { get; set; }

        public void RulesCheck(EditableList<ActivityParameter> activityParameters
            , long idObservation
            , long idParameter
            , long idRow
            , FFRuleCheckPointType checkPointType
            , out List<Rule> executedRules, out List<Rule> enablingRules
            )
        {
            //правила, которые выполнились
            executedRules = new List<Rule>();
            //правила, которые не выполнились, но по которым надо разблокировать контролы
            enablingRules = new List<Rule>();

            if (idParameter == 0) return;
            
            var rules = RulesLookup.Where(c => c.idfsCheckPoint.HasValue && (c.idfsCheckPoint.Value == (long)checkPointType)).ToList();
            //отбираем те правила, где фигурирует нужный параметр
            //правила без действий не могут быть выполнены
            for (var i = rules.Count - 1; i >= 0; i--)
            {
                var rule = rules[i];
                if (rule.ParametersLookup.All(c => c.idfsParameter != idParameter))
                {
                    rules.Remove(rule);
                }
                else if (rule.ActionsLookup.Count == 0)
                {
                    rules.Remove(rule);
                }
                else if (!rule.idfsCheckPoint.HasValue){
                    rules.Remove(rule);
                }
            }
            if (rules.Count == 0) return;

            foreach (var rule in rules)
            {
                //получаем значение параметра
                //если значение не задано, то правило игнорируется
                //TODO обработать табличные значения
                var value1 = activityParameters.GetActivityParameter(false, idObservation, idParameter, idRow);
                if (Utils.IsEmpty(value1) || Utils.IsEmpty(value1.varValue))
                {
                    if (!(
                             (rule.idfsRuleFunction == (long) FFRuleFunctions.Empty)
                             || (rule.idfsRuleFunction == (long) FFRuleFunctions.Value)
                         )) return;
                }
                ActivityParameter value2 = null;
                if (rule.intNumberOfParameters == 2)
                {
                    value2 = activityParameters.GetActivityParameter(false, idObservation, idParameter, idRow);
                    if (Utils.IsEmpty(value2) || Utils.IsEmpty(value2.varValue)) return;
                }
                //метка того, что условия для срабатывания правила выполнились
                var conditionsDone = false; //изначально не соблюдены
                //выполняем действия в зависимости от типа правила
                switch (rule.idfsRuleFunction)
                {
                    case (long) FFRuleFunctions.CurrentDate:
                        var dt = ((DateTime) value1.varValue).Date;
                        if (dt <= DateTime.Now.Date) conditionsDone = true;
                        break;
                    case (long) FFRuleFunctions.Empty:
                        if (Utils.IsEmpty(value1) || Utils.IsEmpty(value1.varValue)) conditionsDone = true;
                        break;
                    case (long) FFRuleFunctions.Value:
                        //если есть константы, с которыми надо сравнивать, то сравним с каждой из них
                        foreach (var constant in rule.ConstantsLookup)
                        {
                            if (Utils.IsEmpty(constant.varConstant))
                            {
                                if (Utils.IsEmpty(value1.varValue))
                                {
                                    conditionsDone = true;
                                    break;
                                }
                            }
                            else if (!Utils.IsEmpty(value1.varValue))
                            {
                                //сравним как строки
                                if (constant.varConstant.ToString().Equals(value1.varValue.ToString()))
                                {
                                    conditionsDone = true;
                                    break;
                                }
                            }
                        }
                        break;
                    case (long) FFRuleFunctions.Greater:
                        double d1;
                        double d2;
                        DateTime dt1;
                        DateTime dt2;

                        if (value2 != null)
                        {
                            var p1 = value1.varValue.ToString();
                            var p2 = value2.varValue.ToString();

                            if (Double.TryParse(p1, out d1) &&
                                Double.TryParse(p2, out d2))
                            {
                                if (d1 > d2) conditionsDone = true;
                            }
                            else if (DateTime.TryParse(p1, out dt1) &&
                                     DateTime.TryParse(p2, out dt2))
                            {
                                if (dt1 > dt2) conditionsDone = true;
                            }
                        }
                        break;
                    case (long) FFRuleFunctions.GreaterEqual:
                        if (value2 != null)
                        {
                            var p1 = value1.varValue.ToString();
                            var p2 = value2.varValue.ToString();

                            if (Double.TryParse(p1, out d1) &&
                                Double.TryParse(p2, out d2))
                            {
                                if (d1 >= d2) conditionsDone = true;
                            }
                            else if (DateTime.TryParse(p1, out dt1) &&
                                     DateTime.TryParse(p2, out dt2))
                            {
                                if (dt1 >= dt2) conditionsDone = true;
                            }
                        }
                        break;
                }
                //накладываем условие отрицания, если оно есть
                if (rule.blnNot) conditionsDone = !conditionsDone;
                if (conditionsDone)
                {
                    executedRules.Add(rule);
                }
                else if (rule.ActionsLookup.Any(c => c.idfsRuleAction == (long)FFRuleActions.Disabled))
                {
                    enablingRules.Add(rule);
                }
            }
        }
    }
}
