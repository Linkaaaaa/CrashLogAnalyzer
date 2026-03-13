using System.Text.RegularExpressions;

namespace CrashLogAnalyzer;

public class ExceptionInfo
{
    public string Code { get; set; } = "";
    public string StatusCode { get; set; } = "";
    public string Address { get; set; } = "";
    public string Flags { get; set; } = "";
    public string Parameter0 { get; set; } = "";
    public string Parameter1 { get; set; } = "";
    public string Text { get; set; } = "";

    public static readonly Dictionary<string, string> ExceptionStatusCodes = new()
    {
        { "00000000", "STATUS_WAIT_0"},
        { "00000080", "STATUS_ABANDONED_WAIT_0"},
        { "000000C0", "STATUS_USER_APC"},
        { "00000102", "STATUS_TIMEOUT"},
        { "00000103", "STATUS_PENDING"},
        { "00010001", "DBG_EXCEPTION_HANDLED"},
        { "00010002", "DBG_CONTINUE"},
        { "40000005", "STATUS_SEGMENT_NOTIFICATION"},
        { "40000015", "STATUS_FATAL_APP_EXIT"},
        { "40010001", "DBG_REPLY_LATER"},
        { "40010003", "DBG_TERMINATE_THREAD"},
        { "40010004", "DBG_TERMINATE_PROCESS"},
        { "40010005", "DBG_CONTROL_C"},
        { "40010006", "DBG_PRINTEXCEPTION_C"},
        { "40010007", "DBG_RIPEXCEPTION"},
        { "40010008", "DBG_CONTROL_BREAK"},
        { "40010009", "DBG_COMMAND_EXCEPTION"},
        { "4001000A", "DBG_PRINTEXCEPTION_WIDE_C"},
        { "80000001", "STATUS_GUARD_PAGE_VIOLATION"},
        { "80000002", "STATUS_DATATYPE_MISALIGNMENT"},
        { "80000003", "STATUS_BREAKPOINT"},
        { "80000004", "STATUS_SINGLE_STEP"},
        { "80000026", "STATUS_LONGJUMP"},
        { "80000029", "STATUS_UNWIND_CONSOLIDATE"},
        { "80010001", "DBG_EXCEPTION_NOT_HANDLED"},
        { "C0000005", "STATUS_ACCESS_VIOLATION"},
        { "C0000006", "STATUS_IN_PAGE_ERROR"},
        { "C0000008", "STATUS_INVALID_HANDLE"},
        { "C000000D", "STATUS_INVALID_PARAMETER"},
        { "C0000017", "STATUS_NO_MEMORY"},
        { "C000001D", "STATUS_ILLEGAL_INSTRUCTION"},
        { "C0000025", "STATUS_NONCONTINUABLE_EXCEPTION"},
        { "C0000026", "STATUS_INVALID_DISPOSITION"},
        { "C000008C", "STATUS_ARRAY_BOUNDS_EXCEEDED"},
        { "C000008D", "STATUS_FLOAT_DENORMAL_OPERAND"},
        { "C000008E", "STATUS_FLOAT_DIVIDE_BY_ZERO"},
        { "C000008F", "STATUS_FLOAT_INEXACT_RESULT"},
        { "C0000090", "STATUS_FLOAT_INVALID_OPERATION"},
        { "C0000091", "STATUS_FLOAT_OVERFLOW"},
        { "C0000092", "STATUS_FLOAT_STACK_CHECK"},
        { "C0000093", "STATUS_FLOAT_UNDERFLOW"},
        { "C0000094", "STATUS_INTEGER_DIVIDE_BY_ZERO"},
        { "C0000095", "STATUS_INTEGER_OVERFLOW"},
        { "C0000096", "STATUS_PRIVILEGED_INSTRUCTION"},
        { "C00000FD", "STATUS_STACK_OVERFLOW"},
        { "C0000135", "STATUS_DLL_NOT_FOUND"},
        { "C0000138", "STATUS_ORDINAL_NOT_FOUND"},
        { "C0000139", "STATUS_ENTRYPOINT_NOT_FOUND"},
        { "C000013A", "STATUS_CONTROL_C_EXIT"},
        { "C0000142", "STATUS_DLL_INIT_FAILED"},
        { "C00001B2", "STATUS_CONTROL_STACK_VIOLATION"},
        { "C00002B4", "STATUS_FLOAT_MULTIPLE_FAULTS"},
        { "C00002B5", "STATUS_FLOAT_MULTIPLE_TRAPS"},
        { "C00002C9", "STATUS_REG_NAT_CONSUMPTION"},
        { "C0000374", "STATUS_HEAP_CORRUPTION"},
        { "C0000409", "STATUS_STACK_BUFFER_OVERRUN"},
        { "C0000417", "STATUS_INVALID_CRUNTIME_PARAMETER"},
        { "C0000420", "STATUS_ASSERTION_FAILURE"},
        { "C00004A2", "STATUS_ENCLAVE_VIOLATION"},
        { "C0000515", "STATUS_INTERRUPTED"},
        { "C0000516", "STATUS_THREAD_NOT_RUNNING"},
        { "C0000718", "STATUS_ALREADY_REGISTERED"},
        { "C015000F", "STATUS_SXS_EARLY_DEACTIVATION"},
        { "C0150010", "STATUS_SXS_INVALID_DEACTIVATION" },
    };
}
