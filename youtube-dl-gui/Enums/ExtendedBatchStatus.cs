namespace youtube_dl_gui;
/// <summary>
/// Represents an enumeration of batch statuses for certain forms.
/// </summary>
internal enum ExtendedBatchStatus {
    /// <summary>
    /// The batch form is idle.
    /// </summary>
    Waiting,
    /// <summary>
    /// The batch form is gathering required information for an item being enqueued.
    /// </summary>
    GatheringInformation,
    /// <summary>
    /// The batch form is executing the actions on the queued items.
    /// </summary>
    ExecutingQueue,
    /// <summary>
    /// The batch form is aborting the execution.
    /// </summary>
    Aborting,
    /// <summary>
    /// The batch form is finished.
    /// </summary>
    Finished,
    /// <summary>
    /// The batch exeuction was aborted.
    /// </summary>
    Aborted,
    /// <summary>
    /// The batch execution was errored.
    /// </summary>
    Errored
}