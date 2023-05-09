public class Shift
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeofJob { get; set; }
    public string Location { get; set; }

    
    public Shift(int shiftId, DateTime startTime, DateTime endTime, string typeofJob, string location)
    {
        ShiftId = shiftId;
        StartTime = startTime;
        EndTime = endTime;
        TypeofJob = typeofJob;
        Location = location;
    }

    
    public Shift()
    {

    }


}
