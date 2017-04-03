using System;

namespace bv.common.Enums
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    ///     Defines the type of the data posting raised by <i>BaseDbService.Post</i> method
    /// </summary>
    /// <remarks>
    ///     The <i>FinalPosting</i> flag is passed to the <i>BaseDbService.Post</i> method
    ///     when user press OK button on the detail form.
    ///     Use <i>IntermediatePosting</i> flag to save data in the intermediate state before child object creation.
    ///     <i>PerformAdditionalPosting</i> flag can be used to inform <i>BaseDbService.Post</i> method that some additional
    ///     actions should be applied to business object except standard data saving.
    /// </remarks>
    /// <history>
    ///     [Mike]	27.03.2006	Created
    ///     [Ivan]	11.11.2013	Moved from bv.common and translated from vb to C#
    /// </history>
    /// -----------------------------------------------------------------------------
    [Flags]
    public enum PostType
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Identifies that object is saved to database in the intermediate state.
        /// </summary>
        /// <remarks>
        ///     Usually this flag is used to save data in the intermediate state before child object creation.
        /// </remarks>
        /// <history>
        ///     [Mike]	27.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        IntermediatePosting = 1,

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Identifies that the object is saved to database in its final state.
        /// </summary>
        /// <remarks>
        ///     Usually the <i>FinalPosting</i> flag is passed to the <i>BaseDbService.Post</i> method
        ///     when user press OK button on the detail form.
        /// </remarks>
        /// <history>
        ///     [Mike]	27.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        FinalPosting = 2,

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Informs <i>BaseDbService.Post</i> method that some additional actions should be performed with the saved object.
        /// </summary>
        /// <remarks>
        ///     Use this flag if there is some non standard action that requires not only object saving but performing some
        ///     additional action too.
        ///     Usually this flag is passed to the <i>BaseDbService.Post</i> method when some special button on the Form is
        ///     pressed.
        /// </remarks>
        /// <history>
        ///     [Mike]	27.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PerformAdditionalPosting = 4,
    }
}