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
