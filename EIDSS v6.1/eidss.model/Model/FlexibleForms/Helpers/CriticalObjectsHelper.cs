using System.Collections.Generic;

namespace eidss.model.Model.FlexibleForms.Helpers
{
    /// <summary>
    /// Описание критического объекта
    /// </summary>
    public class CriticalObject
    {
        public long ID { get; set; }
        public bool CanAddToTemplate { get; set; }

        public CriticalObject(long id, bool canAddToTemplate)
        {
            ID = id;
            CanAddToTemplate = canAddToTemplate;
        }
    }

    /// <summary>
    /// Перечень критических объектов
    /// </summary>
    public static class CriticalObjectsHelper
    {
        public static Dictionary<long, CriticalObject> Parameters { get; set; }
        public static Dictionary<long, CriticalObject> Sections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static CriticalObjectsHelper()
        {
            Parameters = new Dictionary<long, CriticalObject>
                             {
                                 {226890000000, new CriticalObject(226890000000, false)},
                                 {229630000000, new CriticalObject(229630000000, false)},
                                 {226910000000, new CriticalObject(226910000000, false)},
                                 {234410000000, new CriticalObject(234410000000, false)},
                                 {239010000000, new CriticalObject(239010000000, false)},
                                 {233150000000, new CriticalObject(233150000000, false)},
                                 {233190000000, new CriticalObject(233190000000, false)},
                                 {226930000000, new CriticalObject(226930000000, false)},
                                 {231670000000, new CriticalObject(231670000000, false)},
                                 {234430000000, new CriticalObject(234430000000, false)},
                                 {239030000000, new CriticalObject(239030000000, false)},
                                 {226950000000, new CriticalObject(226950000000, false)},
                                 {233170000000, new CriticalObject(233170000000, false)},
                                 {245270000000, new CriticalObject(245270000000, false)},
                                 {234450000000, new CriticalObject(234450000000, false)},
                                 {239050000000, new CriticalObject(239050000000, false)}
                             };

            Sections = new Dictionary<long, CriticalObject>
                           {
                               {71190000000, new CriticalObject(71190000000, true)},
                               {71260000000, new CriticalObject(71260000000, true)},
                               {71090000000, new CriticalObject(71090000000, true)},
                               {71460000000, new CriticalObject(71460000000, true)},
                               {71300000000, new CriticalObject(71300000000, true)}
                           };
        }
    }
}
