using System.ComponentModel.DataAnnotations;

public class Shift
{
    public int ShiftId { get; set; }

    [Display(Name = "Start tidspunkt")]
    public DateTime StartTime { get; set; }

    [Display(Name = "Slut tidspunkt")]
    public DateTime EndTime { get; set; }

    [Display(Name = "Job type")]
    public string TypeofJob { get; set; }

    [Display(Name = "Adresse")]
    public string Location { get; set; }

    public int? MedarbejderLønNr { get; set; }

    
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
