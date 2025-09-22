<Query Kind="Statements">
  <Connection>
    <ID>26ee86b4-398b-421b-8d05-ed2423d12260</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>MSI</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

// Question 1
ClubActivities.Where(x => x.StartDate.Value >= new DateTime(2025, 1, 1) && x.CampusVenue.Location != "Scheduled Room" && x.Name != "BTech Club Meeting")
	.OrderBy(x => x.StartDate)
	.Select(x => new
	{
		StartDate = x.StartDate,
		Location = x.CampusVenue.Location,
		Club = x.Club.ClubName,
		Activity = x.Name
	})
	.Dump();
	
// Question 2

// Question 3

// Question 4
Employees.Where(x => x.Position.Description == "Instructor" && x.ReleaseDate == null && x.ClassOfferings.Count() > 0)
	.OrderByDescending(x => x.ClassOfferings.Count())
	.ThenBy(x => x.LastName)
	.Select( x => new
	{
		ProgramName = x.Program.ProgramName,
		FullName = x.FirstName + " " + x.LastName,
		// I used values of 9 and 25 here due to the wording of the requirements
		// More than 24 and more than 8
		Workload = x.ClassOfferings.Count() < 9 ? "Low" : x.ClassOfferings.Count() < 25 ? "Med" : "High"
	})	
	.Dump();


// Question 5
Clubs.OrderByDescending(x => x.ClubMembers.Count())
.Select(x => new
{
	Supervisor = x.EmployeeID == null ? "Unkown" : x.Employee.FirstName + " " + x.Employee.LastName,
	Club = x.ClubName,
	MemberCount = x.ClubMembers.Count(),
	Activities = x.ClubActivities.Count() == 0 ? "None Schedule" : x.ClubActivities.Count().ToString()
})
.Dump();