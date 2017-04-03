using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;

namespace EIDSS.FlexibleForms.Helpers
{
    /// <summary>
    /// Работа с боковиком
    /// </summary>
    public static class StubHelper
    {
        /// <summary>
        /// Величина смещения по индексам из-за боковика
        /// </summary>
        private const int DeltaStub = 50;

        /// <summary>
        /// Обработка боковика в случае его использования (предустановленные боковики)
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplateTarget">Шаблон, в который нужно вставить боковик</param>
        /// <param name="listStubInfo">Лист пар AggregateCaseSection - Version</param>
        /// <returns></returns>
        public static int IncludeStub(this DbService mainDbService, long idfsFormTemplateTarget, List<StubInfo> listStubInfo)
        {
            //вспомогательный список для регистрации столбцов боковика
            var stubColumns = new List<long>();
            if (listStubInfo.Count == 0) return 0;

            #region Обработка предустановленного боковика

            var versions = listStubInfo.Select(stubInfo => stubInfo.IdfVersion).ToList();
            //старая запись
            //foreach (var stubInfo in listStubInfo)
            //{
            //    versions.Add(stubInfo.IdfVersion);
            //}

            mainDbService.LoadPredefinedStub(listStubInfo[0].IdfsSectionTable, versions);

            foreach (var stubInfo in listStubInfo)
            {
                //табличная секция верхнего уровня, куда помещается содержимое боковика и тела таблицы
                //если на шаблоне присутствует указанная секция, то выстраиваем на ней предустановленный боковик
                //секция ещё не построена (строится в RestoreSections), потому нельзя использовать коллекцию быстрого доступа
                //TODO возможно, нужно выдать ошибку, если не найдена табличная секция
                mainDbService.SetStubLoaded(stubInfo.IdfsFormTemplate, stubInfo.IdfsSectionTable);
                //также поставим метку состоявшейся загрузки у боковика целевого шаблона
                if (!stubInfo.IdfsFormTemplate.Equals(idfsFormTemplateTarget))
                {
                    mainDbService.SetStubLoaded(idfsFormTemplateTarget, stubInfo.IdfsSectionTable);
                }
            }

            //будем проставлять отрицательные значения параметрам боковика. Установим, что параметров может быть не больше deltaStub.
            //TODO рассчитывать это значение
            //колонки боковика будут идти в порядке появления параметров, а порядок расти на единицу с каждым добавленным параметром,
            //чтобы при сортировке параметров по возрастанию боковик всегда был слева
            //у параметров, постоянно присутствующих в шаблоне, порядок всегда положительный
            int intOrder = -DeltaStub;
            //используем все загруженные столбцы для построения боковика. Дублирующиеся столбцы и строки отбрасываем.
            
            foreach (FlexibleFormsDS.PredefinedStubRow stubRow in mainDbService.MainDataSet.PredefinedStub.Rows)
            {
                //отыщем параметр. Он должен обязательно присутствовать в загруженных параметрах, потому что по правилам он находится в этом же типе формы
                //TODO давать ошибку, если это не так
                var parametersRow = mainDbService.GetParameterRow(stubRow.idfsParameter);
                //если такой параметр уже присутствует в шаблоне, то не добавляем его вторично
                //это штатная ситуация, поскольку PredefinedStub предусматривает повторение параметров
                
                if (!stubColumns.Contains(parametersRow.idfsParameter)) stubColumns.Add(parametersRow.idfsParameter); 
                if (mainDbService.GetParameterTemplateRow(parametersRow.idfsParameter, idfsFormTemplateTarget) != null) continue;

                //укажем, что параметр нужно разместить в конкретной табличной секции
                parametersRow.idfsSection = stubRow.idfsSection;
                parametersRow.idfsFormTemplate = idfsFormTemplateTarget;
                parametersRow.intOrder = intOrder;
                //создаём на основе найденного параметра объект в шаблоне (координаты не важны, потому что параметр будет помещён в табличную секцию)
                mainDbService.CreateParameterTemplateRow(parametersRow, idfsFormTemplateTarget);
                intOrder++;                
            }

            #endregion

            return stubColumns.Count;
        }

        /// <summary>
        /// Обработка боковика в случае его использования (предустановленные боковики)
        /// </summary>
        /// <param name="presetStubs"></param>
        /// <param name="mainDbService"></param>
        /// <param name="idfVersion"></param>
        /// <param name="idfsFormTemplate">Шаблон, в котором нужно отыскивать секции для построения боковика, и в который нужно вставить боковик</param>
        public static int IncludeStub(this IEnumerable<AggregateCaseSection> presetStubs, DbService mainDbService, long idfsFormTemplate, long idfVersion)
        {
            return mainDbService.IncludeStub(idfsFormTemplate, GetStubInfo(presetStubs, idfsFormTemplate, idfVersion));
        }

        /// <summary>
        /// Производит преобразование листов из AggregateCaseSection в StubInfo
        /// </summary>
        /// <param name="presetStubs"></param>
        /// <returns></returns>
        public static List<StubInfo> GetStubInfo(this IEnumerable<AggregateCaseSection> presetStubs)
        {
            return presetStubs.GetStubInfo(null, null);
        }

        /// <summary>
        /// Производит преобразование листов из AggregateCaseSection в StubInfo
        /// </summary>
        /// <param name="presetStubs"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfVersion"></param>
        /// <returns></returns>
        public static List<StubInfo> GetStubInfo(this IEnumerable<AggregateCaseSection> presetStubs, long? idfsFormTemplate, long? idfVersion)
        {
            var result = new List<StubInfo>();

            foreach (var stub in presetStubs)
            {
                var stubInfo = new StubInfo {IdfsSectionTable = (long) stub};
                if (idfsFormTemplate.HasValue) stubInfo.IdfsFormTemplate = idfsFormTemplate.Value; //из этого же шаблона брать и туда же вставлять боковик
                if (idfVersion.HasValue) stubInfo.IdfVersion = idfVersion.Value;
                result.Add(stubInfo);
            }
            return result;
        }




        /// <summary>
        /// Постобработка боковика
        /// </summary>
        /// <param name="listAggregateCaseSection"></param>
        /// <param name="sectionTableList"></param>
        /// <param name="stubLength"></param>
        public static void PostProcessingStub(this List<AggregateCaseSection> listAggregateCaseSection, Dictionary<long, SectionTable> sectionTableList, int stubLength)
        {
            var listStubInfo = listAggregateCaseSection.GetStubInfo(null, null);
            PostProcessingStub(listStubInfo, sectionTableList, stubLength);
        }

        /// <summary>
        /// Постобработка боковика
        /// </summary>
        /// <param name="sectionTableList"></param>
        /// <param name="listStubInfo"></param>
        /// <param name="stubLength"></param>
        public static void PostProcessingStub(this List<StubInfo> listStubInfo, Dictionary<long, SectionTable> sectionTableList, int stubLength)
        {
            if (listStubInfo.Count == 0) return;
            foreach (var stubInfo in listStubInfo)
            {
                var rootSectionTable = sectionTableList[stubInfo.IdfsSectionTable];
                //блокируем возможность добавления новых строк
                rootSectionTable.GridViewMain.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
                rootSectionTable.GridViewMain.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                //параметры (столбцы) боковика являются не редактируемыми. Они всегда стоят слева.
                for (int i = 0; i < stubLength; i++)
                {
                    //столбцы боковика нельзя редактировать
                    foreach (GridColumn column in rootSectionTable.GridViewMain.Bands[i].Columns)
                    {
                        column.OptionsColumn.AllowEdit = false;
                        //последний столбец фиксируем, чтобы не было промотки
                        if (i == stubLength - 1) column.Fixed = FixedStyle.Left;
                    }
                }
            }
        }

        /// <summary>
        /// Помещает в таблицу пользовательских данных данные боковика
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templateID"></param>
        /// <param name="observationID"></param>
        /// <param name="versionMatrixStub"></param>
        /// <param name="predefinedStubRows">Содержимое боковика</param>
        public static void IncludeStubDataInUserData(this DbServiceUserData mainDbService, long? templateID, long? observationID, long? versionMatrixStub, out FlexibleFormsDS.PredefinedStubRow[] predefinedStubRows)
        {
            predefinedStubRows = null;
            if (!templateID.HasValue || !observationID.HasValue) return;

            //очистим старый боковик (на случай смены версии боковика в одном сеансе работы для одного observation
            mainDbService.DeleteStubData(templateID.Value, observationID.Value);
            predefinedStubRows =
                versionMatrixStub.HasValue
                    ? mainDbService.GetPredefinedStubRows(versionMatrixStub.Value)
                    : (FlexibleFormsDS.PredefinedStubRow[])mainDbService.MainDataSet.PredefinedStub.Select();
            //данные по боковику уже должны быть загружены, поскольку по ним он визуализировался
            foreach (var predefinedStubRow in predefinedStubRows)
            {
                //перенумеруем строки данных в соответствии с новыми номерами строк боковика
                //это на случай, если данные уже были загружены и пронумерованы, а потом изменился боковик
                mainDbService.MainDataSet.ActivityParameters.RenumActivityParameters(predefinedStubRow, observationID.Value);

                //выставим данные по боковику
                mainDbService.ChangeValue(observationID.Value, templateID.Value, predefinedStubRow.idfsParameter, predefinedStubRow.idfRow, predefinedStubRow.NumRow, predefinedStubRow.idfsParameterValue, predefinedStubRow.strNameValue);
            }
        }
    }


    /// <summary>
    /// Вспомогательная структура для использования в слиянии боковиков
    /// </summary>
    public class StubInfo
    {
        /// <summary>
        /// Шаблон, в котором находится табличная секция с искомым боковиком
        /// </summary>
        public long IdfsFormTemplate { get; set; }
        /// <summary>
        /// Табличная секция, в котором находится боковик
        /// </summary>
        public long IdfsSectionTable { get; set; }
        /// <summary>
        /// Версия боковика
        /// </summary>
        public long IdfVersion { get; set; }
        /// <summary>
        /// Observation, к которому относится боковик
        /// </summary>
        public long IdfObservation { get; set; }
    }

}
